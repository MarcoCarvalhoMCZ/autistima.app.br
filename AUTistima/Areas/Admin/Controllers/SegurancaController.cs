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
public class SegurancaController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public SegurancaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    public async Task<IActionResult> Index(TipoAtividade? tipo, string? searchUser)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.UserActivities
            .Include(a => a.Usuario)
            .AsQueryable();

        // Filtro padrão: Mostrar ataques se nenhum filtro for selecionado, ou permitir ver tudo?
        // O usuário pediu "analisar esses ataques". Vamos focar neles, mas permitir ver outros.
        if (tipo.HasValue)
        {
            query = query.Where(a => a.TipoAtividade == tipo.Value);
        }
        else
        {
            // Se não especificado, mostra ataques por padrão para facilitar a verificação
            query = query.Where(a => a.TipoAtividade == TipoAtividade.TentativaAtaque);
             // Salvar no ViewBag para o filtro na view saber que é o padrão
             ViewBag.TipoSelecionado = TipoAtividade.TentativaAtaque;
        }

        if (!string.IsNullOrEmpty(searchUser))
        {
            query = query.Where(a => a.Usuario.UserName.Contains(searchUser) || a.Usuario.Email.Contains(searchUser));
        }

        var logs = await query
            .OrderByDescending(a => a.DataHora)
            .Take(100)
            .ToListAsync();

        if (tipo.HasValue) ViewBag.TipoSelecionado = tipo.Value;

        return View(logs);
    }

    public async Task<IActionResult> Details(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var log = await _context.UserActivities
            .Include(a => a.Usuario)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (log == null)
            return NotFound();

        return View(log);
    }
}
