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
public class ManejosController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ManejosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/Manejos
    public async Task<IActionResult> Index(CategoriaManejo? categoria, bool? aprovado, int pagina = 1)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.Manejos.Include(m => m.Autor).AsQueryable();

        if (categoria.HasValue)
            query = query.Where(m => m.Categoria == categoria.Value);

        if (aprovado.HasValue)
            query = query.Where(m => m.ValidadoPorEspecialista == aprovado.Value);

        var totalItens = await query.CountAsync();
        var itensPorPagina = 20;
        var totalPaginas = (int)Math.Ceiling(totalItens / (double)itensPorPagina);

        var manejos = await query
            .OrderByDescending(m => m.DataCriacao)
            .Skip((pagina - 1) * itensPorPagina)
            .Take(itensPorPagina)
            .ToListAsync();

        ViewBag.Categoria = categoria;
        ViewBag.Aprovado = aprovado;
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = totalPaginas;

        return View(manejos);
    }

    // POST: Admin/Manejos/Aprovar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Aprovar(int id)
    {
        if (!await IsAdmin())
            return Json(new { success = false });

        var manejo = await _context.Manejos.FindAsync(id);
        if (manejo == null)
            return Json(new { success = false });

        var currentUser = await _userManager.GetUserAsync(User);
        manejo.ValidadoPorEspecialista = true;
        manejo.DataAtualizacao = DateTime.UtcNow;
        manejo.EspecialistaValidadorId = currentUser?.Id;
        
        await _context.SaveChangesAsync();

        return Json(new { success = true });
    }

    // POST: Admin/Manejos/Reprovar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reprovar(int id)
    {
        if (!await IsAdmin())
            return Json(new { success = false });

        var manejo = await _context.Manejos.FindAsync(id);
        if (manejo == null)
            return Json(new { success = false });

        manejo.ValidadoPorEspecialista = false;
        manejo.DataAtualizacao = DateTime.UtcNow;
        manejo.EspecialistaValidadorId = null;
        
        await _context.SaveChangesAsync();

        return Json(new { success = true });
    }

    // POST: Admin/Manejos/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var manejo = await _context.Manejos.FindAsync(id);
        if (manejo != null)
        {
            _context.Manejos.Remove(manejo);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Manejo excluído com sucesso!";
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: Admin/Manejos/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var manejo = await _context.Manejos.FindAsync(id);
        if (manejo == null)
            return NotFound();

        return View(manejo);
    }

    // POST: Admin/Manejos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Manejo model)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        if (id != model.Id)
            return NotFound();

        var manejo = await _context.Manejos.FindAsync(id);
        if (manejo == null)
            return NotFound();

        manejo.Titulo = model.Titulo;
        manejo.Descricao = model.Descricao;
        manejo.Categoria = model.Categoria;
        manejo.FaixaEtariaIndicada = model.FaixaEtariaIndicada;
        manejo.ValidadoPorEspecialista = model.ValidadoPorEspecialista;

        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Manejo atualizado com sucesso!";
        return RedirectToAction(nameof(Index));
    }
}
