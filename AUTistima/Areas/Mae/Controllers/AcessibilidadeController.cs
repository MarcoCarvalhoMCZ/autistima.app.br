using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;

namespace AUTistima.Areas.Mae.Controllers;

[Area("Mae")]
[Authorize]
public class AcessibilidadeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AcessibilidadeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<ApplicationUser?> GetUser() => await _userManager.GetUserAsync(User);

    // GET: /Mae/Acessibilidade
    public async Task<IActionResult> Index()
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var prefs = await _context.AccessibilityPreferences.FirstOrDefaultAsync(p => p.UserId == user.Id)
            ?? new AccessibilityPreference { UserId = user.Id };

        return View(prefs);
    }

    // POST: /Mae/Acessibilidade/Salvar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Salvar(bool modoLeituraFacil, bool altoContraste, string tamanhoFonte,
        bool audioDescricao, bool usarPictogramas)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var existente = await _context.AccessibilityPreferences.FirstOrDefaultAsync(p => p.UserId == user.Id);

        if (existente == null)
        {
            _context.AccessibilityPreferences.Add(new AccessibilityPreference
            {
                UserId = user.Id,
                ModoLeituraFacil = modoLeituraFacil,
                AltoContraste = altoContraste,
                TamanhoFonte = tamanhoFonte ?? "normal",
                AudioDescricao = audioDescricao,
                UsarPictogramas = usarPictogramas,
                AtualizadoEm = DateTime.UtcNow
            });
        }
        else
        {
            existente.ModoLeituraFacil = modoLeituraFacil;
            existente.AltoContraste = altoContraste;
            existente.TamanhoFonte = tamanhoFonte ?? "normal";
            existente.AudioDescricao = audioDescricao;
            existente.UsarPictogramas = usarPictogramas;
            existente.AtualizadoEm = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();

        // Salvar preferências em cookie para aplicar no layout
        var cookieOptions = new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddYears(1),
            HttpOnly = false,
            SameSite = SameSiteMode.Lax,
            Secure = Request.IsHttps
        };
        Response.Cookies.Append("a11y_contraste", altoContraste ? "1" : "0", cookieOptions);
        Response.Cookies.Append("a11y_leitura", modoLeituraFacil ? "1" : "0", cookieOptions);
        Response.Cookies.Append("a11y_fonte", tamanhoFonte ?? "normal", cookieOptions);

        TempData["Sucesso"] = "Preferências de acessibilidade salvas.";
        return RedirectToAction(nameof(Index));
    }
}
