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
public class ServicosController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ServicosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/Servicos
    public async Task<IActionResult> Index(int? especialidadeId, int pagina = 1)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.Services
            .Include(s => s.Profissional)
            .Include(s => s.Especialidade)
            .AsQueryable();

        if (especialidadeId.HasValue)
            query = query.Where(s => s.EspecialidadeId == especialidadeId.Value);

        var totalItens = await query.CountAsync();
        var itensPorPagina = 20;
        var totalPaginas = (int)Math.Ceiling(totalItens / (double)itensPorPagina);

        var servicos = await query
            .OrderBy(s => s.NomeProfissional)
            .Skip((pagina - 1) * itensPorPagina)
            .Take(itensPorPagina)
            .ToListAsync();

        ViewBag.Especialidade = especialidadeId;
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = totalPaginas;

        ViewBag.Especialidades = await _context.EspecialidadesProfissionais
            .Where(e => e.Ativo)
            .OrderBy(e => e.Ordem)
            .ThenBy(e => e.Nome)
            .ToListAsync();

        return View(servicos);
    }

    // GET: Admin/Servicos/Create
    public async Task<IActionResult> Create()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        ViewBag.Especialidades = await _context.EspecialidadesProfissionais
            .OrderBy(e => e.Ordem)
            .ThenBy(e => e.Nome)
            .ToListAsync();

        return View(new Service());
    }

    // POST: Admin/Servicos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Service servico)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        ModelState.Remove("UserId");
        ModelState.Remove("Profissional");

        if (ModelState.IsValid)
        {
            servico.DataCadastro = DateTime.UtcNow;
            servico.Ativo = true;
            _context.Services.Add(servico);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Serviço cadastrado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Especialidades = await _context.EspecialidadesProfissionais
            .OrderBy(e => e.Ordem)
            .ThenBy(e => e.Nome)
            .ToListAsync();
        return View(servico);
    }

    // GET: Admin/Servicos/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var servico = await _context.Services
            .Include(s => s.Especialidade)
            .FirstOrDefaultAsync(s => s.Id == id);
        if (servico == null)
            return NotFound();

        ViewBag.Especialidades = await _context.EspecialidadesProfissionais
            .OrderBy(e => e.Ordem)
            .ThenBy(e => e.Nome)
            .ToListAsync();

        return View(servico);
    }

    // POST: Admin/Servicos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Service servico)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        if (id != servico.Id)
            return NotFound();

        ModelState.Remove("UserId");
        ModelState.Remove("Profissional");

        var existing = await _context.Services.FindAsync(id);
        if (existing == null)
            return NotFound();

        if (!ModelState.IsValid)
        {
            ViewBag.Especialidades = await _context.EspecialidadesProfissionais
                .OrderBy(e => e.Ordem)
                .ThenBy(e => e.Nome)
                .ToListAsync();
            return View(servico);
        }

        existing.NomeProfissional = servico.NomeProfissional;
        existing.EspecialidadeId = servico.EspecialidadeId;
        existing.TipoAtendimento = servico.TipoAtendimento;
        existing.ValorConsulta = servico.ValorConsulta;
        existing.AtendeOnline = servico.AtendeOnline;
        existing.Cidade = servico.Cidade;
        existing.Estado = servico.Estado;
        existing.Descricao = servico.Descricao;
        existing.Ativo = servico.Ativo;

        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Serviço atualizado com sucesso!";
        return RedirectToAction(nameof(Index));
    }

    // POST: Admin/Servicos/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var servico = await _context.Services.FindAsync(id);
        if (servico != null)
        {
            _context.Services.Remove(servico);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Serviço excluído com sucesso!";
        }

        return RedirectToAction(nameof(Index));
    }

    // POST: Admin/Servicos/ToggleAtivo/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleAtivo(int id)
    {
        if (!await IsAdmin())
            return Json(new { success = false });

        var servico = await _context.Services.FindAsync(id);
        if (servico == null)
            return Json(new { success = false });

        servico.Ativo = !servico.Ativo;
        await _context.SaveChangesAsync();

        return Json(new { success = true, ativo = servico.Ativo });
    }
}
