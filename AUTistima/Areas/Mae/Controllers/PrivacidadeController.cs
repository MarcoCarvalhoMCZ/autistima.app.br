using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;
using AUTistima.Services;

namespace AUTistima.Areas.Mae.Controllers;

[Area("Mae")]
[Authorize]
public class PrivacidadeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAuditService _audit;

    public PrivacidadeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuditService audit)
    {
        _context = context;
        _userManager = userManager;
        _audit = audit;
    }

    // GET: /Mae/Privacidade
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Index", "Home", new { area = "" });

        var consentimentos = await _context.ConsentLogs
            .Where(c => c.UserId == user.Id)
            .OrderByDescending(c => c.Data)
            .ToListAsync();

        var exportRequests = await _context.DataExportRequests
            .Where(e => e.UserId == user.Id)
            .OrderByDescending(e => e.RequestedAt)
            .Take(5)
            .ToListAsync();

        var deletionRequests = await _context.DataDeletionRequests
            .Where(d => d.UserId == user.Id)
            .OrderByDescending(d => d.RequestedAt)
            .Take(3)
            .ToListAsync();

        ViewBag.Consentimentos = consentimentos;
        ViewBag.ExportRequests = exportRequests;
        ViewBag.DeletionRequests = deletionRequests;
        return View(user);
    }

    // POST: /Mae/Privacidade/RegistrarConsentimento
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> RegistrarConsentimento(string tipoConsentimento, bool aceite)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Forbid();

        var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
        var log = new ConsentLog
        {
            UserId = user.Id,
            TipoConsentimento = tipoConsentimento,
            Aceite = aceite,
            Data = DateTime.UtcNow,
            IpAddress = ip
        };
        _context.ConsentLogs.Add(log);
        await _context.SaveChangesAsync();

        await _audit.RegistrarAsync(user.Id, aceite ? "ConsentimentoAceito" : "ConsentimentoRevogado",
            tipoConsentimento, ip);

        TempData["Sucesso"] = aceite ? $"Consentimento '{tipoConsentimento}' registrado." : $"Consentimento '{tipoConsentimento}' revogado.";
        return RedirectToAction(nameof(Index));
    }

    // POST: /Mae/Privacidade/SolicitarExportacao
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> SolicitarExportacao()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Forbid();

        var solAtiva = await _context.DataExportRequests
            .AnyAsync(e => e.UserId == user.Id && e.Status == StatusRequisicaoLGPD.Pendente);
        if (solAtiva)
        {
            TempData["Aviso"] = "Já existe uma solicitação de exportação pendente.";
            return RedirectToAction(nameof(Index));
        }

        _context.DataExportRequests.Add(new DataExportRequest { UserId = user.Id });
        await _context.SaveChangesAsync();
        await _audit.RegistrarAsync(user.Id, "SolicitacaoExportacaoDados", "DataExportRequest",
            HttpContext.Connection.RemoteIpAddress?.ToString());

        TempData["Sucesso"] = "Solicitação de exportação registrada. Em até 5 dias úteis, você receberá seus dados.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Mae/Privacidade/ExportarDadosJSON — exportação direta
    public async Task<IActionResult> ExportarDadosJSON()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Forbid();

        var filhos = await _context.Children
            .Where(c => c.UserId == user.Id)
            .Select(c => new { c.Nome, c.DataNascimento, c.CodigoUnico })
            .ToListAsync();

        var dados = new
        {
            NomeCompleto = user.NomeCompleto,
            Email = user.Email,
            Cidade = user.Cidade,
            Estado = user.Estado,
            DataCadastro = user.DataCadastro,
            Filhos = filhos,
            ExportadoEm = DateTime.UtcNow
        };

        await _audit.RegistrarAsync(user.Id, "ExportacaoDadosJSON", "Perfil",
            HttpContext.Connection.RemoteIpAddress?.ToString());

        var json = JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true });
        var bytes = Encoding.UTF8.GetBytes(json);
        return File(bytes, "application/json", $"autistima_dados_{user.Id[..8]}.json");
    }

    // GET: /Mae/Privacidade/SolicitarExclusao
    public IActionResult SolicitarExclusao()
    {
        return View();
    }

    // POST: /Mae/Privacidade/SolicitarExclusao
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> SolicitarExclusao(string motivo)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Forbid();

        if (string.IsNullOrWhiteSpace(motivo))
        {
            ModelState.AddModelError("", "Informe o motivo.");
            return View();
        }

        var jaExiste = await _context.DataDeletionRequests
            .AnyAsync(d => d.UserId == user.Id && d.Status == StatusRequisicaoLGPD.Pendente);
        if (jaExiste)
        {
            TempData["Aviso"] = "Já existe uma solicitação de exclusão pendente em análise.";
            return RedirectToAction(nameof(Index));
        }

        _context.DataDeletionRequests.Add(new DataDeletionRequest
        {
            UserId = user.Id,
            Motivo = motivo
        });
        await _context.SaveChangesAsync();
        await _audit.RegistrarAsync(user.Id, "SolicitacaoExclusaoDados", "DataDeletionRequest",
            HttpContext.Connection.RemoteIpAddress?.ToString(), motivo);

        TempData["Sucesso"] = "Solicitação de exclusão enviada ao administrador. Retorno em até 15 dias úteis (LGPD Art. 18).";
        return RedirectToAction(nameof(Index));
    }
}
