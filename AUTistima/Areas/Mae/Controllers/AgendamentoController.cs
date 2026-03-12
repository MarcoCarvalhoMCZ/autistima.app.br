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
public class AgendamentoController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AgendamentoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<ApplicationUser?> GetUser() => await _userManager.GetUserAsync(User);

    // GET: /Mae/Agendamento
    public async Task<IActionResult> Index()
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var solicitacoes = await _context.ServiceRequests
            .Include(s => s.Servico)
            .Include(s => s.Filho)
            .Include(s => s.Agendamentos)
            .Where(s => s.UserId == user.Id && s.Ativo)
            .OrderByDescending(s => s.CriadoEm)
            .ToListAsync();

        return View(solicitacoes);
    }

    // GET: /Mae/Agendamento/Solicitar?serviceId=1
    public async Task<IActionResult> Solicitar(int? serviceId)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var servicos = await _context.Services
            .Where(s => s.Ativo)
            .OrderBy(s => s.NomeProfissional)
            .ToListAsync();

        var filhos = await _context.Children
            .Where(c => c.UserId == user.Id)
            .OrderBy(c => c.Nome)
            .ToListAsync();

        ViewBag.Servicos = servicos;
        ViewBag.Filhos = filhos;
        ViewBag.ServiceIdPreSelecionado = serviceId;

        return View(new ServiceRequest());
    }

    // POST: /Mae/Agendamento/Solicitar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Solicitar(ServiceRequest model)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        if (!ModelState.IsValid)
        {
            ViewBag.Servicos = await _context.Services.Where(s => s.Ativo).ToListAsync();
            ViewBag.Filhos = await _context.Children.Where(c => c.UserId == user.Id).ToListAsync();
            return View(model);
        }

        model.UserId = user.Id;
        model.CriadoEm = DateTime.UtcNow;
        model.Status = StatusServiceRequest.Pendente;

        _context.ServiceRequests.Add(model);
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Solicitação enviada com sucesso! Você será notificado sobre o andamento.";
        return RedirectToAction(nameof(Index));
    }

    // POST: /Mae/Agendamento/Cancelar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancelar(int id)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var solicitacao = await _context.ServiceRequests
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == user.Id);

        if (solicitacao != null && solicitacao.Status == StatusServiceRequest.Pendente)
        {
            solicitacao.Status = StatusServiceRequest.Cancelado;
            solicitacao.RespondidoEm = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            TempData["Sucesso"] = "Solicitação cancelada.";
        }

        return RedirectToAction(nameof(Index));
    }
}
