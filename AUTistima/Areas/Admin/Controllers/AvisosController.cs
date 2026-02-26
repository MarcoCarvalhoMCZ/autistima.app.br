using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;
using AUTistima.Services;
using AUTistima.ViewModels;

namespace AUTistima.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class AvisosController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IPushNotificationService _pushService;
    private readonly ILogger<AvisosController> _logger;

    public AvisosController(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        IPushNotificationService pushService,
        ILogger<AvisosController> logger)
    {
        _context = context;
        _userManager = userManager;
        _pushService = pushService;
        _logger = logger;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/Avisos
    public async Task<IActionResult> Index()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var vm = await MontarViewModelAsync();
        return View(vm);
    }

    // POST: Admin/Avisos/Enviar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Enviar(EnviarAvisoViewModel formulario)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        if (!ModelState.IsValid)
        {
            var vmErro = await MontarViewModelAsync(formulario);
            return View("Index", vmErro);
        }

        // Validações de destino
        if (formulario.TipoDestino == "Perfil" && formulario.PerfilDestino == null)
        {
            ModelState.AddModelError("formulario.PerfilDestino", "Selecione o perfil de destino.");
            var vmErro = await MontarViewModelAsync(formulario);
            return View("Index", vmErro);
        }

        if (formulario.TipoDestino == "Selecionados" && formulario.UsuariosSelecionados.Count == 0)
        {
            ModelState.AddModelError("formulario.UsuariosSelecionados", "Selecione ao menos um usuário.");
            var vmErro = await MontarViewModelAsync(formulario);
            return View("Index", vmErro);
        }

        // Obter destinatários
        var destinatarios = await ObterDestinatariosAsync(formulario);

        if (destinatarios.Count == 0)
        {
            TempData["Erro"] = "Nenhum usuário encontrado para os critérios selecionados.";
            var vmErro = await MontarViewModelAsync(formulario);
            return View("Index", vmErro);
        }

        var adminUser = await _userManager.GetUserAsync(User);
        var link = string.IsNullOrWhiteSpace(formulario.Link) ? null : formulario.Link.Trim();

        // Criar notificações individuais + push
        int enviados = 0;
        foreach (var usuario in destinatarios)
        {
            try
            {
                await _pushService.EnviarComPushAsync(
                    _context,
                    usuario.Id,
                    formulario.Titulo,
                    formulario.Mensagem,
                    TipoNotificacao.Sistema,
                    link);
                enviados++;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Falha ao enviar aviso para usuário {UserId}", usuario.Id);
            }
        }

        // Registrar o broadcast
        var broadcast = new BroadcastMessage
        {
            Titulo = formulario.Titulo,
            Mensagem = formulario.Mensagem,
            Link = link,
            TipoDestino = formulario.TipoDestino,
            PerfilDestino = formulario.PerfilDestino.HasValue ? (int)formulario.PerfilDestino.Value : null,
            TotalDestinatarios = enviados,
            RemetenteId = adminUser!.Id,
            DataEnvio = DateTime.UtcNow
        };

        _context.BroadcastMessages.Add(broadcast);
        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Admin {AdminId} enviou aviso '{Titulo}' para {Total} usuário(s). TipoDestino={TipoDestino}",
            adminUser.Id, formulario.Titulo, enviados, formulario.TipoDestino);

        TempData["Sucesso"] = $"✅ Aviso enviado para {enviados} usuário(s) com sucesso!";
        return RedirectToAction(nameof(Index));
    }

    // POST: Admin/Avisos/Excluir/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Excluir(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var broadcast = await _context.BroadcastMessages.FindAsync(id);
        if (broadcast != null)
        {
            _context.BroadcastMessages.Remove(broadcast);
            await _context.SaveChangesAsync();
        }

        TempData["Sucesso"] = "🗑️ Registro removido do histórico.";
        return RedirectToAction(nameof(Index));
    }

    // --- Helpers ---

    private async Task<List<ApplicationUser>> ObterDestinatariosAsync(EnviarAvisoViewModel formulario)
    {
        var query = _context.Users.Where(u => u.Ativo);

        return formulario.TipoDestino switch
        {
            "Todos" => await query.ToListAsync(),

            "Perfil" when formulario.PerfilDestino.HasValue =>
                await query.Where(u => u.TipoPerfil == formulario.PerfilDestino.Value).ToListAsync(),

            "Selecionados" when formulario.UsuariosSelecionados.Count > 0 =>
                await query.Where(u => formulario.UsuariosSelecionados.Contains(u.Id)).ToListAsync(),

            _ => []
        };
    }

    private async Task<AvisosIndexViewModel> MontarViewModelAsync(EnviarAvisoViewModel? formulario = null)
    {
        var historico = await _context.BroadcastMessages
            .Include(b => b.Remetente)
            .OrderByDescending(b => b.DataEnvio)
            .Take(50)
            .ToListAsync();

        var usuarios = await _context.Users
            .Where(u => u.Ativo)
            .OrderBy(u => u.NomeCompleto)
            .ToListAsync();

        var contagemPorPerfil = usuarios
            .GroupBy(u => u.TipoPerfil)
            .ToDictionary(g => g.Key, g => g.Count());

        var usuariosSelectList = usuarios.Select(u => new SelectListItem(
            $"{u.NomeCompleto} ({u.TipoPerfil.ToString().Replace("Profissional", "Prof.")})",
            u.Id
        )).ToList();

        return new AvisosIndexViewModel
        {
            Historico = historico,
            Formulario = formulario ?? new EnviarAvisoViewModel(),
            UsuariosDisponiveis = usuariosSelectList,
            ContagemPorPerfil = contagemPorPerfil,
            TotalUsuariosAtivos = usuarios.Count
        };
    }
}
