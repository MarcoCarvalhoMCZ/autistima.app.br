using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;
using AUTistima.Services;

namespace AUTistima.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class AcessosEstudanteController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<AcessosEstudanteController> _logger;
    private readonly IPushNotificationService _push;

    public AcessosEstudanteController(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        ILogger<AcessosEstudanteController> logger,
        IPushNotificationService push)
    {
        _context = context;
        _userManager = userManager;
        _logger = logger;
        _push = push;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/AcessosEstudante
    public async Task<IActionResult> Index(StatusSolicitacaoAcesso? status, int pagina = 1)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.SolicitacoesAcessoPerfil
            .Include(s => s.Estudante)
            .Include(s => s.Profissional)
            .Include(s => s.AprovadoPorAdmin)
            .AsQueryable();

        if (status.HasValue)
            query = query.Where(s => s.Status == status.Value);
        else
            query = query.Where(s => s.Status == StatusSolicitacaoAcesso.Pendente);

        var total = await query.CountAsync();
        var porPagina = 20;

        var solicitacoes = await query
            .OrderByDescending(s => s.DataSolicitacao)
            .Skip((pagina - 1) * porPagina)
            .Take(porPagina)
            .ToListAsync();

        ViewBag.StatusFiltro = status ?? StatusSolicitacaoAcesso.Pendente;
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = (int)Math.Ceiling(total / (double)porPagina);
        ViewBag.Total = total;
        return View(solicitacoes);
    }

    // POST: Admin/AcessosEstudante/Aprovar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Aprovar(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var admin = await _userManager.GetUserAsync(User);
        var solicitacao = await _context.SolicitacoesAcessoPerfil
            .Include(s => s.Estudante)
            .FirstOrDefaultAsync(s => s.Id == id);
        if (solicitacao == null) return NotFound();

        solicitacao.Status = StatusSolicitacaoAcesso.Aprovado;
        solicitacao.DataDecisao = DateTime.UtcNow;
        solicitacao.AprovadoPorAdminId = admin!.Id;

        await _context.SaveChangesAsync();
        _logger.LogInformation("Solicitação {Id} aprovada pelo admin {AdminId}", id, admin.Id);

        // Notificar o profissional
        var nomeEstudante = solicitacao.Estudante?.Nome ?? "estudante";
        await _push.EnviarParaUsuarioAsync(
            solicitacao.ProfissionalId,
            "Acesso ao Prontuário Aprovado ✅",
            $"Seu acesso ao prontuário de {nomeEstudante} foi aprovado. Você já pode visualizar os registros.",
            url: "/Profissional/Prontuarios/Index"
        );

        TempData["Sucesso"] = "Acesso aprovado com sucesso.";
        return RedirectToAction(nameof(Index));
    }

    // POST: Admin/AcessosEstudante/Rejeitar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Rejeitar(int id, string motivo)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var admin = await _userManager.GetUserAsync(User);
        var solicitacao = await _context.SolicitacoesAcessoPerfil
            .Include(s => s.Estudante)
            .FirstOrDefaultAsync(s => s.Id == id);
        if (solicitacao == null) return NotFound();

        solicitacao.Status = StatusSolicitacaoAcesso.Rejeitado;
        solicitacao.MotivoRejeicao = motivo;
        solicitacao.DataDecisao = DateTime.UtcNow;
        solicitacao.AprovadoPorAdminId = admin!.Id;

        await _context.SaveChangesAsync();
        _logger.LogInformation("Solicitação {Id} rejeitada pelo admin {AdminId}", id, admin.Id);

        // Notificar o profissional
        var nomeEstudante = solicitacao.Estudante?.Nome ?? "estudante";
        await _push.EnviarParaUsuarioAsync(
            solicitacao.ProfissionalId,
            "Solicitação de Acesso ao Prontuário ⛔",
            $"Sua solicitação de acesso ao prontuário de {nomeEstudante} foi rejeitada. Motivo: {motivo}",
            url: "/Profissional/Prontuarios/SolicitarAcesso"
        );

        TempData["Aviso"] = "Solicitação rejeitada.";
        return RedirectToAction(nameof(Index));
    }

    // POST: Admin/AcessosEstudante/Revogar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Revogar(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var admin = await _userManager.GetUserAsync(User);
        var solicitacao = await _context.SolicitacoesAcessoPerfil
            .Include(s => s.Estudante)
            .FirstOrDefaultAsync(s => s.Id == id);
        if (solicitacao == null) return NotFound();

        if (solicitacao.Status != StatusSolicitacaoAcesso.Aprovado)
        {
            TempData["Aviso"] = "Somente acessos aprovados podem ser revogados.";
            return RedirectToAction(nameof(Index), new { status = StatusSolicitacaoAcesso.Aprovado });
        }

        solicitacao.Status = StatusSolicitacaoAcesso.Rejeitado;
        solicitacao.MotivoRejeicao = "Acesso revogado pelo administrador.";
        solicitacao.DataDecisao = DateTime.UtcNow;
        solicitacao.AprovadoPorAdminId = admin!.Id;

        await _context.SaveChangesAsync();
        _logger.LogInformation("Acesso {Id} revogado pelo admin {AdminId}", id, admin.Id);

        var nomeEstudante = solicitacao.Estudante?.Nome ?? "estudante";
        await _push.EnviarParaUsuarioAsync(
            solicitacao.ProfissionalId,
            "Acesso ao Prontuário Revogado ⛔",
            $"Seu acesso ao prontuário de {nomeEstudante} foi revogado pelo administrador.",
            url: "/Profissional/Prontuarios/SolicitarAcesso"
        );

        TempData["Aviso"] = "Acesso revogado com sucesso.";
        return RedirectToAction(nameof(Index), new { status = StatusSolicitacaoAcesso.Aprovado });
    }
}
