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
public class GlossarioController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public GlossarioController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/Glossario
    public async Task<IActionResult> Index()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var termos = await _context.GlossaryTerms
            .OrderBy(t => t.TermoTecnico)
            .ToListAsync();

        return View(termos);
    }

    // GET: Admin/Glossario/Create
    public async Task<IActionResult> Create()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        return View();
    }

    // POST: Admin/Glossario/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GlossaryTerm termo)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        ModelState.Remove("Id");

        if (ModelState.IsValid)
        {
            _context.GlossaryTerms.Add(termo);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Termo adicionado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        return View(termo);
    }

    // GET: Admin/Glossario/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var termo = await _context.GlossaryTerms.FindAsync(id);
        if (termo == null)
            return NotFound();

        return View(termo);
    }

    // POST: Admin/Glossario/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, GlossaryTerm termo)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        if (id != termo.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(termo);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Termo atualizado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        return View(termo);
    }

    // POST: Admin/Glossario/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var termo = await _context.GlossaryTerms.FindAsync(id);
        if (termo != null)
        {
            _context.GlossaryTerms.Remove(termo);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Termo excluído com sucesso!";
        }

        return RedirectToAction(nameof(Index));
    }
}
