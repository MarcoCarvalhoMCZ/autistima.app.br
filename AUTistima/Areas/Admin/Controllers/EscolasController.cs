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
public class EscolasController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public EscolasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/Escolas
    public async Task<IActionResult> Index(string? busca, int pagina = 1)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.Schools.AsQueryable();

        if (!string.IsNullOrEmpty(busca))
        {
            query = query.Where(e => e.Nome.Contains(busca) || e.Cidade.Contains(busca));
        }

        var totalItens = await query.CountAsync();
        var itensPorPagina = 20;
        var totalPaginas = (int)Math.Ceiling(totalItens / (double)itensPorPagina);

        var escolas = await query
            .Include(e => e.Alunos)
            .OrderBy(e => e.Nome)
            .Skip((pagina - 1) * itensPorPagina)
            .Take(itensPorPagina)
            .ToListAsync();

        ViewBag.Busca = busca;
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = totalPaginas;

        return View(escolas);
    }

    // GET: Admin/Escolas/Create
    public async Task<IActionResult> Create()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        return View();
    }

    // POST: Admin/Escolas/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(School escola)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        ModelState.Remove("Id");

        if (ModelState.IsValid)
        {
            escola.DataCadastro = DateTime.UtcNow;
            _context.Schools.Add(escola);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Escola cadastrada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        return View(escola);
    }

    // GET: Admin/Escolas/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var escola = await _context.Schools.FindAsync(id);
        if (escola == null)
            return NotFound();

        return View(escola);
    }

    // POST: Admin/Escolas/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, School escola)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        if (id != escola.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(escola);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Escola atualizada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        return View(escola);
    }

    // POST: Admin/Escolas/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var escola = await _context.Schools.FindAsync(id);
        if (escola != null)
        {
            _context.Schools.Remove(escola);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Escola excluída com sucesso!";
        }

        return RedirectToAction(nameof(Index));
    }
}
