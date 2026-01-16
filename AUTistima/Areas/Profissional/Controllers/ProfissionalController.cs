using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;

namespace AUTistima.Areas.Profissional.Controllers;

[Area("Profissional")]
[Authorize]
public class ProfissionalController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ProfissionalController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsProfissional()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.ProfissionalSaude || 
               user?.TipoPerfil == TipoPerfil.ProfissionalEducacao;
    }

    // GET: Profissional
    public async Task<IActionResult> Index()
    {
        if (!await IsProfissional())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        
        // Estatísticas do profissional
        if (user?.TipoPerfil == TipoPerfil.ProfissionalSaude)
        {
            ViewBag.TotalServicos = await _context.Services.CountAsync(s => s.UserId == user.Id);
            ViewBag.TriagensPendentes = await _context.ScreeningRequests
                .CountAsync(s => s.Status == StatusTriagem.Pendente);
        }
        else if (user?.TipoPerfil == TipoPerfil.ProfissionalEducacao)
        {
            ViewBag.TriagensCriadas = await _context.ScreeningRequests
                .CountAsync(s => s.ProfessorSolicitanteId == user.Id);
            ViewBag.TotalEscolas = await _context.Schools.CountAsync();
        }
        
        ViewBag.TipoProfissional = user?.TipoPerfil;
        
        return View();
    }

    // GET: Profissional/MeusServicos
    public async Task<IActionResult> MeusServicos()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user?.TipoPerfil != TipoPerfil.ProfissionalSaude)
            return RedirectToAction(nameof(Index));

        var servicos = await _context.Services
            .Where(s => s.UserId == user.Id)
            .Include(s => s.Especialidade)
            .OrderByDescending(s => s.DataCadastro)
            .ToListAsync();

        return View(servicos);
    }

    // GET: Profissional/Triagens
    public async Task<IActionResult> Triagens()
    {
        if (!await IsProfissional())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        
        IQueryable<ScreeningRequest> query = _context.ScreeningRequests
            .Include(s => s.Escola);

        if (user?.TipoPerfil == TipoPerfil.ProfissionalEducacao)
        {
            // Educador vê as triagens que criou
            query = query.Where(s => s.ProfessorSolicitanteId == user.Id);
        }
        else
        {
            // Profissional de saúde vê triagens pendentes de avaliação
            query = query.Where(s => s.Status == StatusTriagem.Pendente);
        }

        var triagens = await query.OrderByDescending(s => s.DataSolicitacao).ToListAsync();

        return View(triagens);
    }
}
