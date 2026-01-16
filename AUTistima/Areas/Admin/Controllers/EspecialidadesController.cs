using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;
using System.Security.Claims;

namespace AUTistima.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class EspecialidadesController : Controller
{
    private readonly ApplicationDbContext _context;

    public EspecialidadesController(ApplicationDbContext context)
    {
        _context = context;
    }

    private async Task<bool> UsuarioEhAdminAsync()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return false;

        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    public async Task<IActionResult> Index()
    {
        if (!await UsuarioEhAdminAsync())
            return RedirectToAction("Index", "Home", new { area = "" });

        var lista = await _context.EspecialidadesProfissionais
            .OrderBy(e => e.Ordem)
            .ThenBy(e => e.Nome)
            .ToListAsync();

        return View(lista);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nome,Descricao,Ordem,Ativo")] EspecialidadeProfissional especialidade)
    {
        if (!await UsuarioEhAdminAsync())
            return RedirectToAction("Index", "Home", new { area = "" });

        if (!ModelState.IsValid)
        {
            var lista = await _context.EspecialidadesProfissionais
                .OrderBy(e => e.Ordem)
                .ThenBy(e => e.Nome)
                .ToListAsync();
            return View("Index", lista);
        }

        _context.EspecialidadesProfissionais.Add(especialidade);
        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Especialidade criada com sucesso.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        if (!await UsuarioEhAdminAsync())
            return RedirectToAction("Index", "Home", new { area = "" });

        var especialidade = await _context.EspecialidadesProfissionais.FindAsync(id);
        if (especialidade == null)
            return NotFound();

        return View(especialidade);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EspecialidadeProfissional especialidade)
    {
        if (!await UsuarioEhAdminAsync())
            return RedirectToAction("Index", "Home", new { area = "" });

        if (id != especialidade.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(especialidade);

        var existing = await _context.EspecialidadesProfissionais.FindAsync(id);
        if (existing == null)
            return NotFound();

        existing.Nome = especialidade.Nome;
        existing.Descricao = especialidade.Descricao;
        existing.Ordem = especialidade.Ordem;
        existing.Ativo = especialidade.Ativo;

        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Especialidade atualizada.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Toggle(int id)
    {
        if (!await UsuarioEhAdminAsync())
            return RedirectToAction("Index", "Home", new { area = "" });

        var especialidade = await _context.EspecialidadesProfissionais.FindAsync(id);
        if (especialidade == null)
            return NotFound();

        especialidade.Ativo = !especialidade.Ativo;
        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Status atualizado.";
        return RedirectToAction(nameof(Index));
    }
}
