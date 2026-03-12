using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;

namespace AUTistima.Areas.Profissional.Controllers;

[Area("Profissional")]
[Authorize]
public class AtendimentoController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AtendimentoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsProfissional()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.ProfissionalSaude ||
               user?.TipoPerfil == TipoPerfil.ProfissionalEducacao;
    }

    // GET: /Profissional/Atendimento
    public async Task<IActionResult> Index(StatusServiceRequest? status)
    {
        if (!await IsProfissional())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.ServiceRequests
            .Include(s => s.Solicitante)
            .Include(s => s.Servico)
            .Include(s => s.Filho)
            .Include(s => s.Agendamentos)
            .Where(s => s.Ativo);

        if (status.HasValue)
            query = query.Where(s => s.Status == status.Value);

        var solicitacoes = await query
            .OrderByDescending(s => s.Prioridade)
            .ThenByDescending(s => s.CriadoEm)
            .ToListAsync();

        ViewBag.StatusFiltro = status;
        return View(solicitacoes);
    }

    // POST: /Profissional/Atendimento/Agendar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Agendar(int id, DateTime dataHora, string? local, string? linkTeleatendimento, string? canal)
    {
        if (!await IsProfissional())
            return Forbid();

        var solicitacao = await _context.ServiceRequests
            .FirstOrDefaultAsync(s => s.Id == id && s.Ativo);

        if (solicitacao == null) return NotFound();

        var agendamento = new ServiceAppointment
        {
            RequestId = id,
            DataHora = dataHora,
            Local = local,
            Canal = canal ?? "Presencial",
            LinkTeleatendimento = linkTeleatendimento,
            CriadoEm = DateTime.UtcNow
        };

        _context.ServiceAppointments.Add(agendamento);

        solicitacao.Status = StatusServiceRequest.Agendado;
        solicitacao.RespondidoEm = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        TempData["Sucesso"] = $"Agendamento confirmado para {dataHora:dd/MM/yyyy HH:mm}.";
        return RedirectToAction(nameof(Index));
    }

    // POST: /Profissional/Atendimento/Concluir/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Concluir(int id, string? resposta)
    {
        if (!await IsProfissional())
            return Forbid();

        var solicitacao = await _context.ServiceRequests.FirstOrDefaultAsync(s => s.Id == id && s.Ativo);
        if (solicitacao == null) return NotFound();

        solicitacao.Status = StatusServiceRequest.Concluido;
        solicitacao.RespondidoEm = DateTime.UtcNow;
        solicitacao.RespostaServico = resposta;

        await _context.SaveChangesAsync();
        TempData["Sucesso"] = "Atendimento marcado como concluído.";
        return RedirectToAction(nameof(Index));
    }
}
