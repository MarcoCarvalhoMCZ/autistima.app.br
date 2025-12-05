using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;

namespace AUTistima.Areas.Governo.Controllers;

[Area("Governo")]
[Authorize]
public class GovernoController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public GovernoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsGoverno()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Governo;
    }

    // GET: Governo
    public async Task<IActionResult> Index()
    {
        if (!await IsGoverno())
            return RedirectToAction("Index", "Home", new { area = "" });

        // Estatísticas gerais para dashboard do governo
        ViewBag.TotalMaes = await _context.Users.CountAsync(u => u.TipoPerfil == TipoPerfil.Mae);
        ViewBag.TotalTriagens = await _context.ScreeningRequests.CountAsync();
        ViewBag.TriagensPendentes = await _context.ScreeningRequests
            .CountAsync(t => t.Status == StatusTriagem.Pendente);
        ViewBag.TotalEscolas = await _context.Schools.CountAsync();
        ViewBag.TotalServicos = await _context.Services.CountAsync();
        
        // Triagens por status
        ViewBag.TriagensRealizadas = await _context.ScreeningRequests
            .CountAsync(t => t.Status == StatusTriagem.Concluido);
        ViewBag.EncaminhadasSaude = await _context.ScreeningRequests
            .CountAsync(t => t.Status == StatusTriagem.Encaminhado);
        
        return View();
    }

    // GET: Governo/Estatisticas
    public async Task<IActionResult> Estatisticas()
    {
        if (!await IsGoverno())
            return RedirectToAction("Index", "Home", new { area = "" });

        // Dados para relatórios
        ViewBag.TriagensPorMes = await _context.ScreeningRequests
            .GroupBy(t => new { t.DataSolicitacao.Year, t.DataSolicitacao.Month })
            .Select(g => new { 
                Periodo = $"{g.Key.Month:D2}/{g.Key.Year}", 
                Total = g.Count() 
            })
            .OrderByDescending(x => x.Periodo)
            .Take(12)
            .ToListAsync();

        ViewBag.EscolasPorCidade = await _context.Schools
            .Where(e => e.Cidade != null)
            .GroupBy(e => e.Cidade)
            .Select(g => new { Cidade = g.Key, Total = g.Count() })
            .OrderByDescending(x => x.Total)
            .Take(10)
            .ToListAsync();

        ViewBag.ServicosPorEspecialidade = await _context.Services
            .GroupBy(s => s.Especialidade)
            .Select(g => new { Especialidade = g.Key.ToString(), Total = g.Count() })
            .ToListAsync();

        return View();
    }

    // GET: Governo/Triagens
    public async Task<IActionResult> Triagens(StatusTriagem? status, int pagina = 1)
    {
        if (!await IsGoverno())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.ScreeningRequests
            .Include(t => t.Escola)
            .AsQueryable();

        if (status.HasValue)
            query = query.Where(t => t.Status == status.Value);

        var totalItens = await query.CountAsync();
        var itensPorPagina = 20;
        var totalPaginas = (int)Math.Ceiling(totalItens / (double)itensPorPagina);

        var triagens = await query
            .OrderByDescending(t => t.DataSolicitacao)
            .Skip((pagina - 1) * itensPorPagina)
            .Take(itensPorPagina)
            .ToListAsync();

        ViewBag.Status = status;
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = totalPaginas;

        return View(triagens);
    }

    // GET: Governo/Escolas
    public async Task<IActionResult> Escolas(string? cidade, int pagina = 1)
    {
        if (!await IsGoverno())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.Schools.AsQueryable();

        if (!string.IsNullOrEmpty(cidade))
            query = query.Where(e => e.Cidade != null && e.Cidade.Contains(cidade));

        var totalItens = await query.CountAsync();
        var itensPorPagina = 20;
        var totalPaginas = (int)Math.Ceiling(totalItens / (double)itensPorPagina);

        var escolas = await query
            .OrderBy(e => e.Nome)
            .Skip((pagina - 1) * itensPorPagina)
            .Take(itensPorPagina)
            .ToListAsync();

        ViewBag.Cidade = cidade;
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = totalPaginas;

        return View(escolas);
    }
}
