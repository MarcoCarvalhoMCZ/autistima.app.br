using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;

namespace AUTistima.Areas.Mae.Controllers;

[Area("Mae")]
[Authorize]
public class PlanoController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public PlanoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<ApplicationUser?> GetUser() => await _userManager.GetUserAsync(User);

    // GET: /Mae/Plano
    public async Task<IActionResult> Index()
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var filhos = await _context.Children
            .Where(c => c.UserId == user.Id)
            .OrderBy(c => c.Nome)
            .ToListAsync();

        var planos = await _context.ChildCarePlans
            .Include(p => p.Filho)
            .Where(p => p.Filho!.UserId == user.Id && p.Ativo)
            .OrderByDescending(p => p.CriadoEm)
            .ToListAsync();

        ViewBag.Filhos = filhos;
        return View(planos);
    }

    // GET: /Mae/Plano/Criar?childId=1
    public async Task<IActionResult> Criar(int childId)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var filho = await _context.Children.FirstOrDefaultAsync(c => c.Id == childId && c.UserId == user.Id);
        if (filho == null) return NotFound();

        ViewBag.Filho = filho;
        return View(new ChildCarePlan { ChildId = childId });
    }

    // POST: /Mae/Plano/Criar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Criar(ChildCarePlan model)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var filho = await _context.Children.FirstOrDefaultAsync(c => c.Id == model.ChildId && c.UserId == user.Id);
        if (filho == null) return NotFound();

        if (!ModelState.IsValid)
        {
            ViewBag.Filho = filho;
            return View(model);
        }

        model.CriadoEm = DateTime.UtcNow;
        model.AtualizadoEm = DateTime.UtcNow;
        _context.ChildCarePlans.Add(model);
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Plano de cuidado criado com sucesso.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Mae/Plano/Editar/5
    public async Task<IActionResult> Editar(int id)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var plano = await _context.ChildCarePlans
            .Include(p => p.Filho)
            .FirstOrDefaultAsync(p => p.Id == id && p.Filho!.UserId == user.Id && p.Ativo);

        if (plano == null) return NotFound();

        ViewBag.Filho = plano.Filho;
        return View(plano);
    }

    // POST: /Mae/Plano/Editar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, ChildCarePlan model)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var plano = await _context.ChildCarePlans
            .Include(p => p.Filho)
            .FirstOrDefaultAsync(p => p.Id == id && p.Filho!.UserId == user.Id && p.Ativo);

        if (plano == null) return NotFound();

        if (!ModelState.IsValid)
        {
            ViewBag.Filho = plano.Filho;
            return View(model);
        }

        plano.Titulo = model.Titulo;
        plano.Objetivos = model.Objetivos;
        plano.Intervencoes = model.Intervencoes;
        plano.Terapias = model.Terapias;
        plano.DataInicio = model.DataInicio;
        plano.DataRevisao = model.DataRevisao;
        plano.AtualizadoEm = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        TempData["Sucesso"] = "Plano atualizado com sucesso.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Mae/Plano/Progresso/5 (childId)
    public async Task<IActionResult> Progresso(int childId)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var filho = await _context.Children.FirstOrDefaultAsync(c => c.Id == childId && c.UserId == user.Id);
        if (filho == null) return NotFound();

        var registros = await _context.ChildProgresses
            .Include(p => p.PlanoAssociado)
            .Where(p => p.ChildId == childId)
            .OrderByDescending(p => p.Data)
            .ToListAsync();

        var planos = await _context.ChildCarePlans
            .Where(p => p.ChildId == childId && p.Ativo)
            .OrderByDescending(p => p.CriadoEm)
            .ToListAsync();

        ViewBag.Filho = filho;
        ViewBag.Planos = planos;
        return View(registros);
    }

    // POST: /Mae/Plano/AdicionarProgresso
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdicionarProgresso(ChildProgress model)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var filho = await _context.Children.FirstOrDefaultAsync(c => c.Id == model.ChildId && c.UserId == user.Id);
        if (filho == null) return NotFound();

        model.Data = DateTime.UtcNow;
        _context.ChildProgresses.Add(model);
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Registro de progresso adicionado.";
        return RedirectToAction(nameof(Progresso), new { childId = model.ChildId });
    }

    // GET: /Mae/Plano/Lembretes
    public async Task<IActionResult> Lembretes()
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var filhos = await _context.Children.Where(c => c.UserId == user.Id).ToListAsync();

        var lembretes = await _context.AppointmentReminders
            .Include(r => r.Filho)
            .Where(r => r.UserId == user.Id)
            .OrderBy(r => r.DataHora)
            .ToListAsync();

        ViewBag.Filhos = filhos;
        return View(lembretes);
    }

    // POST: /Mae/Plano/AdicionarLembrete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdicionarLembrete(AppointmentReminder model)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        if (!ModelState.IsValid)
        {
            TempData["Erro"] = "Preencha todos os campos obrigatórios.";
            return RedirectToAction(nameof(Lembretes));
        }

        model.UserId = user.Id;
        model.CriadoEm = DateTime.UtcNow;
        _context.AppointmentReminders.Add(model);
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Lembrete adicionado com sucesso.";
        return RedirectToAction(nameof(Lembretes));
    }

    // POST: /Mae/Plano/RemoverLembrete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoverLembrete(int id)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var lembrete = await _context.AppointmentReminders.FirstOrDefaultAsync(r => r.Id == id && r.UserId == user.Id);
        if (lembrete != null)
        {
            _context.AppointmentReminders.Remove(lembrete);
            await _context.SaveChangesAsync();
        }

        TempData["Sucesso"] = "Lembrete removido.";
        return RedirectToAction(nameof(Lembretes));
    }
}
