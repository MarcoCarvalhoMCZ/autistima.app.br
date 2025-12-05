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
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Verificar se é admin
    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/Dashboard
    public async Task<IActionResult> Index()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        ViewBag.TotalUsuarios = await _context.Users.CountAsync();
        ViewBag.TotalMaes = await _context.Users.CountAsync(u => u.TipoPerfil == TipoPerfil.Mae);
        ViewBag.TotalProfissionaisSaude = await _context.Users.CountAsync(u => u.TipoPerfil == TipoPerfil.ProfissionalSaude);
        ViewBag.TotalProfissionaisEducacao = await _context.Users.CountAsync(u => u.TipoPerfil == TipoPerfil.ProfissionalEducacao);
        ViewBag.TotalEmpresas = await _context.Users.CountAsync(u => u.TipoPerfil == TipoPerfil.Empresa);
        ViewBag.TotalFilhos = await _context.Children.CountAsync();
        ViewBag.TotalEscolas = await _context.Schools.CountAsync();
        ViewBag.TotalManejos = await _context.Manejos.CountAsync();
        ViewBag.TotalPosts = await _context.Posts.CountAsync();
        ViewBag.TotalOportunidades = await _context.Opportunities.CountAsync();
        ViewBag.TotalServicos = await _context.Services.CountAsync();
        ViewBag.TotalGlossario = await _context.GlossaryTerms.CountAsync();
        ViewBag.TotalTriagens = await _context.ScreeningRequests.CountAsync();

        return View();
    }
}
