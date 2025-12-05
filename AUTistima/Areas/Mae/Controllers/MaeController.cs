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
public class MaeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public MaeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsMae()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Mae;
    }

    // GET: Mae - Dashboard pessoal
    public async Task<IActionResult> Index()
    {
        if (!await IsMae())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        
        // Estatísticas pessoais
        ViewBag.TotalFilhos = await _context.Children.CountAsync(c => c.UserId == user!.Id);
        ViewBag.TotalManejos = await _context.Manejos.CountAsync(m => m.UserId == user!.Id && m.Ativo);
        ViewBag.TotalPosts = await _context.Posts.CountAsync(p => p.UserId == user!.Id && p.Ativo);
        ViewBag.TotalAcolhimentosRecebidos = await _context.PostAcolhimentos
            .CountAsync(a => _context.Posts.Any(p => p.Id == a.PostId && p.UserId == user!.Id));

        // Últimos posts
        ViewBag.UltimosPosts = await _context.Posts
            .Include(p => p.Acolhimentos)
            .Where(p => p.UserId == user!.Id && p.Ativo)
            .OrderByDescending(p => p.DataCriacao)
            .Take(3)
            .ToListAsync();

        return View(user);
    }

    // GET: Mae/MeusFilhos
    public async Task<IActionResult> MeusFilhos()
    {
        if (!await IsMae())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        var filhos = await _context.Children
            .Include(c => c.Escola)
            .Where(c => c.UserId == user!.Id)
            .OrderBy(c => c.Nome)
            .ToListAsync();

        return View(filhos);
    }

    // GET: Mae/MeusManejos
    public async Task<IActionResult> MeusManejos()
    {
        if (!await IsMae())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        var manejos = await _context.Manejos
            .Where(m => m.UserId == user!.Id)
            .OrderByDescending(m => m.DataCriacao)
            .ToListAsync();

        return View(manejos);
    }

    // GET: Mae/MeusPosts
    public async Task<IActionResult> MeusPosts()
    {
        if (!await IsMae())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        var posts = await _context.Posts
            .Include(p => p.Acolhimentos)
            .Include(p => p.Comentarios)
            .Where(p => p.UserId == user!.Id)
            .OrderByDescending(p => p.DataCriacao)
            .ToListAsync();

        return View(posts);
    }

    // GET: Mae/Perfil
    public async Task<IActionResult> Perfil()
    {
        if (!await IsMae())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        return View(user);
    }

    // POST: Mae/AtualizarPerfil
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AtualizarPerfil(string nomeCompleto, string? sobreMim, string? cidade, string? estado, string? bairro)
    {
        if (!await IsMae())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound();

        user.NomeCompleto = nomeCompleto;
        user.SobreMim = sobreMim;
        user.Cidade = cidade;
        user.Estado = estado;
        user.Bairro = bairro;

        await _userManager.UpdateAsync(user);
        TempData["Mensagem"] = "Perfil atualizado com sucesso! 💕";

        return RedirectToAction(nameof(Perfil));
    }
}
