using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;

namespace AUTistima.Areas.Empresa.Controllers;

[Area("Empresa")]
[Authorize]
public class VagasController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public VagasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<ApplicationUser?> GetUser() => await _userManager.GetUserAsync(User);

    // GET: /Empresa/Vagas
    public async Task<IActionResult> Index()
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var vagas = await _context.InclusiveJobs
            .Where(v => v.EmpresaId == user.Id && v.Ativo)
            .OrderByDescending(v => v.CriadoEm)
            .ToListAsync();

        var selo = await _context.CompanyBadges
            .Where(b => b.EmpresaId == user.Id)
            .OrderByDescending(b => b.ConquistadoEm)
            .FirstOrDefaultAsync();

        ViewBag.Selo = selo;
        return View(vagas);
    }

    // GET: /Empresa/Vagas/Criar
    public IActionResult Criar()
    {
        return View(new InclusiveJob());
    }

    // POST: /Empresa/Vagas/Criar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Criar(InclusiveJob model)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        if (!ModelState.IsValid)
            return View(model);

        model.EmpresaId = user.Id;
        model.CriadoEm = DateTime.UtcNow;
        model.Status = StatusInclusiveJob.Ativa;

        _context.InclusiveJobs.Add(model);
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Vaga publicada com sucesso.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Empresa/Vagas/Editar/5
    public async Task<IActionResult> Editar(int id)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var vaga = await _context.InclusiveJobs.FirstOrDefaultAsync(v => v.Id == id && v.EmpresaId == user.Id && v.Ativo);
        if (vaga == null) return NotFound();

        return View(vaga);
    }

    // POST: /Empresa/Vagas/Editar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, InclusiveJob model)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var vaga = await _context.InclusiveJobs.FirstOrDefaultAsync(v => v.Id == id && v.EmpresaId == user.Id && v.Ativo);
        if (vaga == null) return NotFound();

        if (!ModelState.IsValid)
            return View(model);

        vaga.Titulo = model.Titulo;
        vaga.Descricao = model.Descricao;
        vaga.Acomodacoes = model.Acomodacoes;
        vaga.Localizacao = model.Localizacao;
        vaga.Regime = model.Regime;
        vaga.SalarioMin = model.SalarioMin;
        vaga.SalarioMax = model.SalarioMax;

        await _context.SaveChangesAsync();
        TempData["Sucesso"] = "Vaga atualizada.";
        return RedirectToAction(nameof(Index));
    }

    // POST: /Empresa/Vagas/AlterarStatus/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AlterarStatus(int id, StatusInclusiveJob status)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var vaga = await _context.InclusiveJobs.FirstOrDefaultAsync(v => v.Id == id && v.EmpresaId == user.Id);
        if (vaga != null)
        {
            vaga.Status = status;
            if (status == StatusInclusiveJob.Encerrada) vaga.Ativo = false;
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: /Empresa/Vagas/Publico (lista pública)
    [AllowAnonymous]
    public async Task<IActionResult> Publico(string? busca)
    {
        var query = _context.InclusiveJobs
            .Include(v => v.Empresa)
            .Where(v => v.Ativo && v.Status == StatusInclusiveJob.Ativa);

        if (!string.IsNullOrWhiteSpace(busca))
            query = query.Where(v => v.Titulo.Contains(busca) || v.Descricao.Contains(busca));

        var vagas = await query
            .OrderByDescending(v => v.CriadoEm)
            .ToListAsync();

        ViewBag.Busca = busca;
        return View(vagas);
    }
}
