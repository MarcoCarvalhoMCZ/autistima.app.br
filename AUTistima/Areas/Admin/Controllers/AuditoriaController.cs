using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;

namespace AUTistima.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class AuditoriaController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuditoriaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/Auditoria
    public async Task<IActionResult> Index(string? userId, string? acao, int pagina = 1)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        const int tamanhoPagina = 50;

        var query = _context.AuditEvents.AsQueryable();

        if (!string.IsNullOrWhiteSpace(userId))
            query = query.Where(e => e.UserId == userId);

        if (!string.IsNullOrWhiteSpace(acao))
            query = query.Where(e => e.Acao.Contains(acao));

        var total = await query.CountAsync();
        var eventos = await query
            .OrderByDescending(e => e.Data)
            .Skip((pagina - 1) * tamanhoPagina)
            .Take(tamanhoPagina)
            .ToListAsync();

        ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / tamanhoPagina);
        ViewBag.PaginaAtual = pagina;
        ViewBag.UserId = userId;
        ViewBag.Acao = acao;
        ViewBag.Total = total;

        return View(eventos);
    }

    // GET: Admin/Auditoria/Solicitacoes
    public async Task<IActionResult> Solicitacoes()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var exportacoes = await _context.DataExportRequests
            .Include(e => e.Usuario)
            .OrderByDescending(e => e.RequestedAt)
            .ToListAsync();

        var exclusoes = await _context.DataDeletionRequests
            .Include(e => e.Usuario)
            .OrderByDescending(e => e.RequestedAt)
            .ToListAsync();

        ViewBag.Exportacoes = exportacoes;
        ViewBag.Exclusoes = exclusoes;

        return View();
    }

    // POST: Admin/Auditoria/ProcessarExclusao
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProcessarExclusao(int id, string decisao, string? observacao)
    {
        if (!await IsAdmin())
            return Forbid();

        var solicitacao = await _context.DataDeletionRequests
            .Include(d => d.Usuario)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (solicitacao == null)
            return NotFound();

        var adminUser = await _userManager.GetUserAsync(User);

        if (decisao == "aprovar")
        {
            solicitacao.Status = StatusRequisicaoLGPD.Concluido;
            solicitacao.ProcessedAt = DateTime.UtcNow;
            solicitacao.ObsAdmin = observacao;

            // Anonimizar dados do usuário
            if (solicitacao.Usuario != null)
            {
                var usuario = solicitacao.Usuario;
                usuario.NomeCompleto = "Usuário Removido";
                usuario.PhoneNumber = null;
                usuario.Email = $"removido_{usuario.Id}@anonimo.local";
                usuario.UserName = $"removido_{usuario.Id}";
                usuario.NormalizedEmail = usuario.Email.ToUpperInvariant();
                usuario.NormalizedUserName = usuario.UserName.ToUpperInvariant();
                usuario.Ativo = false;
                await _userManager.UpdateAsync(usuario);
            }
        }
        else
        {
            solicitacao.Status = StatusRequisicaoLGPD.Rejeitado;
            solicitacao.ProcessedAt = DateTime.UtcNow;
            solicitacao.ObsAdmin = observacao;
        }

        await _context.SaveChangesAsync();

        _context.AuditEvents.Add(new AuditEvent
        {
            UserId = adminUser?.Id ?? "sistema",
            Acao = $"LGPD_EXCLUSAO_{decisao.ToUpper()}",
            Recurso = $"DataDeletionRequest/{id}",
            IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
            Detalhes = $"Solicitação #{id} - {decisao} pelo admin {adminUser?.Email}"
        });
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = $"Solicitação #{id} {(decisao == "aprovar" ? "aprovada e dados anonimizados" : "rejeitada")}.";
        return RedirectToAction(nameof(Solicitacoes));
    }
}
