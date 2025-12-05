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
public class OportunidadesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public OportunidadesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/Oportunidades
    public async Task<IActionResult> Index(TipoOportunidade? tipo, int pagina = 1)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.Opportunities.Include(o => o.Criador).AsQueryable();

        if (tipo.HasValue)
            query = query.Where(o => o.Tipo == tipo.Value);

        var totalItens = await query.CountAsync();
        var itensPorPagina = 20;
        var totalPaginas = (int)Math.Ceiling(totalItens / (double)itensPorPagina);

        var oportunidades = await query
            .OrderByDescending(o => o.DataCriacao)
            .Skip((pagina - 1) * itensPorPagina)
            .Take(itensPorPagina)
            .ToListAsync();

        ViewBag.Tipo = tipo;
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = totalPaginas;

        return View(oportunidades);
    }

    // GET: Admin/Oportunidades/Create
    public async Task<IActionResult> Create()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        return View();
    }

    // POST: Admin/Oportunidades/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Opportunity oportunidade)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        ModelState.Remove("Id");
        ModelState.Remove("UserId");
        ModelState.Remove("Criador");

        if (ModelState.IsValid)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            oportunidade.UserId = currentUser!.Id;
            oportunidade.DataCriacao = DateTime.UtcNow;
            oportunidade.Ativo = true;

            _context.Opportunities.Add(oportunidade);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Oportunidade criada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        return View(oportunidade);
    }

    // GET: Admin/Oportunidades/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var oportunidade = await _context.Opportunities.FindAsync(id);
        if (oportunidade == null)
            return NotFound();

        return View(oportunidade);
    }

    // POST: Admin/Oportunidades/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Opportunity oportunidade)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        if (id != oportunidade.Id)
            return NotFound();

        ModelState.Remove("UserId");
        ModelState.Remove("Criador");

        var existing = await _context.Opportunities.FindAsync(id);
        if (existing == null)
            return NotFound();

        existing.Titulo = oportunidade.Titulo;
        existing.Descricao = oportunidade.Descricao;
        existing.Tipo = oportunidade.Tipo;
        existing.ValorSalario = oportunidade.ValorSalario;
        existing.PermiteHomeOffice = oportunidade.PermiteHomeOffice;
        existing.HorarioFlexivel = oportunidade.HorarioFlexivel;
        existing.Contato = oportunidade.Contato;
        existing.LinkExterno = oportunidade.LinkExterno;
        existing.DataExpiracao = oportunidade.DataExpiracao;
        existing.Ativo = oportunidade.Ativo;

        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Oportunidade atualizada com sucesso!";
        return RedirectToAction(nameof(Index));
    }

    // POST: Admin/Oportunidades/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var oportunidade = await _context.Opportunities.FindAsync(id);
        if (oportunidade != null)
        {
            _context.Opportunities.Remove(oportunidade);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Oportunidade excluída com sucesso!";
        }

        return RedirectToAction(nameof(Index));
    }

    // POST: Admin/Oportunidades/ToggleAtiva/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleAtiva(int id)
    {
        if (!await IsAdmin())
            return Json(new { success = false });

        var oportunidade = await _context.Opportunities.FindAsync(id);
        if (oportunidade == null)
            return Json(new { success = false });

        oportunidade.Ativo = !oportunidade.Ativo;
        await _context.SaveChangesAsync();

        return Json(new { success = true, ativa = oportunidade.Ativo });
    }
}
