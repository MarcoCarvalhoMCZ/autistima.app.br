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
public class SegurancaController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public SegurancaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<ApplicationUser?> GetUser() => await _userManager.GetUserAsync(User);

    // GET: /Mae/Seguranca
    public async Task<IActionResult> Index()
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var plano = await _context.SafetyPlans
            .FirstOrDefaultAsync(p => p.UserId == user.Id);

        var contatos = await _context.EmergencyContacts
            .Where(c => c.UserId == user.Id && c.Ativo)
            .OrderBy(c => c.Tipo)
            .ThenBy(c => c.Nome)
            .ToListAsync();

        ViewBag.Contatos = contatos;
        return View(plano);
    }

    // GET: /Mae/Seguranca/EditarPlano
    public async Task<IActionResult> EditarPlano()
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var plano = await _context.SafetyPlans.FirstOrDefaultAsync(p => p.UserId == user.Id);
        return View(plano ?? new SafetyPlan { UserId = user.Id });
    }

    // POST: /Mae/Seguranca/EditarPlano
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditarPlano(SafetyPlan model)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var existente = await _context.SafetyPlans.FirstOrDefaultAsync(p => p.UserId == user.Id);

        if (existente == null)
        {
            model.UserId = user.Id;
            model.AtualizadoEm = DateTime.UtcNow;
            _context.SafetyPlans.Add(model);
        }
        else
        {
            existente.SinaisAlerta = model.SinaisAlerta;
            existente.EstrategiasDesescalada = model.EstrategiasDesescalada;
            existente.RecursosLocais = model.RecursosLocais;
            existente.PlanoAposIntervencao = model.PlanoAposIntervencao;
            existente.AtualizadoEm = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
        TempData["Sucesso"] = "Plano de segurança atualizado.";
        return RedirectToAction(nameof(Index));
    }

    // POST: /Mae/Seguranca/AdicionarContato
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdicionarContato(string nome, string telefone, string tipo, string? observacoes)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone))
        {
            TempData["Erro"] = "Nome e telefone são obrigatórios.";
            return RedirectToAction(nameof(Index));
        }

        _context.EmergencyContacts.Add(new EmergencyContact
        {
            UserId = user.Id,
            Nome = nome.Trim(),
            Telefone = telefone.Trim(),
            Tipo = tipo ?? "Familiar",
            Observacoes = observacoes
        });

        await _context.SaveChangesAsync();
        TempData["Sucesso"] = "Contato adicionado.";
        return RedirectToAction(nameof(Index));
    }

    // POST: /Mae/Seguranca/RemoverContato/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoverContato(int id)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var contato = await _context.EmergencyContacts.FirstOrDefaultAsync(c => c.Id == id && c.UserId == user.Id);
        if (contato != null)
        {
            contato.Ativo = false;
            await _context.SaveChangesAsync();
        }

        TempData["Sucesso"] = "Contato removido.";
        return RedirectToAction(nameof(Index));
    }
}
