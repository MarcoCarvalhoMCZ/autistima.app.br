using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AUTistima.Models;
using AUTistima.Data;
using Microsoft.EntityFrameworkCore;

namespace AUTistima.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Estatísticas para a landing page
        ViewBag.TotalMaes = await _context.Users.CountAsync(u => u.TipoPerfil == Models.Enums.TipoPerfil.Mae);
        ViewBag.TotalManejos = await _context.Manejos.CountAsync(m => m.Ativo);
        ViewBag.TotalAcolhimentos = await _context.PostAcolhimentos.CountAsync();
        ViewBag.TotalProfissionais = await _context.Services.CountAsync(s => s.Ativo);
        
        // Se autenticado, redirecionar para a área apropriada do perfil
        if (User.Identity?.IsAuthenticated == true)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user != null)
            {
                return user.TipoPerfil switch
                {
                    Models.Enums.TipoPerfil.Administrador => RedirectToAction("Index", "Admin", new { area = "Admin" }),
                    Models.Enums.TipoPerfil.Mae => RedirectToAction("Index", "Mae", new { area = "Mae" }),
                    Models.Enums.TipoPerfil.ProfissionalSaude => RedirectToAction("Index", "Profissional", new { area = "Profissional" }),
                    Models.Enums.TipoPerfil.ProfissionalEducacao => RedirectToAction("Index", "Profissional", new { area = "Profissional" }),
                    Models.Enums.TipoPerfil.Empresa => RedirectToAction("Index", "Empresa", new { area = "Empresa" }),
                    Models.Enums.TipoPerfil.Governo => RedirectToAction("Index", "Governo", new { area = "Governo" }),
                    _ => View()
                };
            }
        }
        
        return View();
    }

    public IActionResult Sobre()
    {
        return View();
    }

    public IActionResult Contato()
    {
        return View();
    }

    public IActionResult Privacidade()
    {
        return View();
    }

    public IActionResult Termos()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return RedirectToAction(nameof(Privacidade));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
