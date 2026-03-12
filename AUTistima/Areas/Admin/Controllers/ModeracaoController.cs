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
public class ModeracaoController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ModeracaoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: /Admin/Moderacao
    public async Task<IActionResult> Index(StatusModeracao? status)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.Reports
            .Include(r => r.Denunciante)
            .Include(r => r.ResolvidoPor)
            .AsQueryable();

        if (status.HasValue)
            query = query.Where(r => r.Status == status.Value);

        var reports = await query
            .OrderByDescending(r => r.CriadoEm)
            .ToListAsync();

        ViewBag.StatusFiltro = status;
        return View(reports);
    }

    // POST: /Admin/Moderacao/Resolver/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Resolver(int id, string acao, string? observacao, bool removerConteudo = false)
    {
        if (!await IsAdmin())
            return Forbid();

        var report = await _context.Reports.FirstOrDefaultAsync(r => r.Id == id);
        if (report == null) return NotFound();

        var admin = await _userManager.GetUserAsync(User);

        report.Status = acao == "resolver" ? StatusModeracao.Resolvido : StatusModeracao.Arquivado;
        report.ResolvidoPorId = admin?.Id;
        report.ResolvidoEm = DateTime.UtcNow;
        report.ObsResolucao = observacao;

        // Remover conteúdo se solicitado
        if (removerConteudo)
        {
            if (report.TargetType == "Post")
            {
                var post = await _context.Posts.FindAsync(report.TargetId);
                if (post != null) post.Ativo = false;
            }
            else if (report.TargetType == "Comment")
            {
                var comment = await _context.PostComments.FindAsync(report.TargetId);
                if (comment != null) comment.Ativo = false;
            }
        }

        // Marcar outros reports do mesmo conteúdo como resolvidos também
        var outrosReports = await _context.Reports
            .Where(r => r.TargetType == report.TargetType && r.TargetId == report.TargetId
                       && r.Status == StatusModeracao.Pendente && r.Id != id)
            .ToListAsync();

        foreach (var outro in outrosReports)
        {
            outro.Status = StatusModeracao.Resolvido;
            outro.ResolvidoPorId = admin?.Id;
            outro.ResolvidoEm = DateTime.UtcNow;
            outro.ObsResolucao = "Resolvido junto com denúncia #" + id;
        }

        await _context.SaveChangesAsync();

        TempData["Sucesso"] = $"Denúncia #{id} {(acao == "resolver" ? "resolvida" : "arquivada")}.";
        return RedirectToAction(nameof(Index));
    }
}
