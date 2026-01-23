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
public class UsuariosController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(
        ApplicationDbContext context, 
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ILogger<UsuariosController> logger)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/Usuarios
    public async Task<IActionResult> Index(string? busca, TipoPerfil? tipoPerfil, int pagina = 1)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.Users.AsQueryable();

        if (!string.IsNullOrEmpty(busca))
        {
            query = query.Where(u => u.NomeCompleto.Contains(busca) || u.Email!.Contains(busca));
        }

        if (tipoPerfil.HasValue)
        {
            query = query.Where(u => u.TipoPerfil == tipoPerfil.Value);
        }

        var totalItens = await query.CountAsync();
        var itensPorPagina = 20;
        var totalPaginas = (int)Math.Ceiling(totalItens / (double)itensPorPagina);

        var usuarios = await query
            .Include(u => u.Filhos)
            .OrderByDescending(u => u.DataCadastro)
            .Skip((pagina - 1) * itensPorPagina)
            .Take(itensPorPagina)
            .ToListAsync();

        ViewBag.Busca = busca;
        ViewBag.TipoPerfil = tipoPerfil;
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = totalPaginas;
        ViewBag.TotalItens = totalItens;

        return View(usuarios);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginComo(string id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            TempData["MensagemErro"] = "Usuário não encontrado.";
            return RedirectToAction(nameof(Index));
        }

        _logger.LogWarning($"ADMIN INTERVENÇÃO: Administrador {User.Identity?.Name} realizou login forçado como {user.Email} (ID: {user.Id}) para fins de suporte/teste.");

        // Logout do admin atual
        await _signInManager.SignOutAsync();
        
        // Login como o usuário alvo (sem senha)
        await _signInManager.SignInAsync(user, isPersistent: false);

        TempData["Mensagem"] = $"Você agora está logado como {user.NomeCompleto}.";
        return RedirectToAction("Index", "Home", new { area = "" });
    }

    // GET: Admin/Usuarios/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var usuario = await _context.Users
            .Include(u => u.Filhos)
            .Include(u => u.Posts)
            .Include(u => u.Manejos)
            .Include(u => u.Servicos)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (usuario == null)
            return NotFound();

        return View(usuario);
    }

    // GET: Admin/Usuarios/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var usuario = await _context.Users.FindAsync(id);
        if (usuario == null)
            return NotFound();

        ViewBag.Especialidades = await _context.EspecialidadesProfissionais
            .Where(e => e.Ativo)
            .OrderBy(e => e.Ordem)
            .ThenBy(e => e.Nome)
            .ToListAsync();

        return View(usuario);
    }

    // POST: Admin/Usuarios/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("Id,NomeCompleto,Email,TipoPerfil,Ativo,Cidade,Estado,Bairro,CNPJ,NomeEmpresa,RegistroProfissional,MatriculaProfissional,EspecialidadeId,EmpresaAmiga")] ApplicationUser model)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        if (id != model.Id)
            return NotFound();

        var usuario = await _context.Users.FindAsync(id);
        if (usuario == null)
            return NotFound();

        // Atualiza apenas os campos permitidos
        usuario.NomeCompleto = model.NomeCompleto;
        usuario.TipoPerfil = model.TipoPerfil;
        usuario.Ativo = model.Ativo;
        usuario.Cidade = model.Cidade;
        usuario.Estado = model.Estado;
        usuario.Bairro = model.Bairro;
        usuario.CNPJ = model.CNPJ;
        usuario.NomeEmpresa = model.NomeEmpresa;
        usuario.RegistroProfissional = model.RegistroProfissional;
        usuario.MatriculaProfissional = model.MatriculaProfissional;
        usuario.EspecialidadeId = model.EspecialidadeId;
        usuario.EmpresaAmiga = model.EmpresaAmiga;

        try
        {
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Usuário atualizado com sucesso!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar usuário {UserId}", id);
            ModelState.AddModelError("", "Erro ao salvar alterações.");
        }

        ViewBag.Especialidades = await _context.EspecialidadesProfissionais
            .Where(e => e.Ativo)
            .OrderBy(e => e.Ordem)
            .ThenBy(e => e.Nome)
            .ToListAsync();

        return View(usuario);
    }

    // POST: Admin/Usuarios/ToggleAtivo/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleAtivo(string id)
    {
        if (!await IsAdmin())
            return Json(new { success = false });

        var usuario = await _context.Users.FindAsync(id);
        if (usuario == null)
            return Json(new { success = false });

        usuario.Ativo = !usuario.Ativo;
        await _context.SaveChangesAsync();

        return Json(new { success = true, ativo = usuario.Ativo });
    }

    // POST: Admin/Usuarios/ResetSenha/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetSenha(string id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var usuario = await _userManager.FindByIdAsync(id);
        if (usuario == null)
            return NotFound();

        // Gera uma nova senha temporária
        var novaSenha = $"Temp@{DateTime.Now:yyyyMMdd}";
        var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
        var result = await _userManager.ResetPasswordAsync(usuario, token, novaSenha);

        if (result.Succeeded)
        {
            TempData["Mensagem"] = $"Senha resetada para: {novaSenha}";
        }
        else
        {
            TempData["Erro"] = "Erro ao resetar senha.";
        }

        return RedirectToAction(nameof(Details), new { id });
    }

    // GET: Admin/Usuarios/Create
    public async Task<IActionResult> Create()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        return View();
    }

    // POST: Admin/Usuarios/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ApplicationUser model, string senha)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        ModelState.Remove("Id");
        ModelState.Remove("UserName");
        ModelState.Remove("NormalizedUserName");
        ModelState.Remove("NormalizedEmail");
        ModelState.Remove("PasswordHash");
        ModelState.Remove("SecurityStamp");
        ModelState.Remove("ConcurrencyStamp");

        if (string.IsNullOrEmpty(senha) || senha.Length < 6)
        {
            ModelState.AddModelError("senha", "A senha deve ter no mínimo 6 caracteres.");
            return View(model);
        }

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            NomeCompleto = model.NomeCompleto,
            TipoPerfil = model.TipoPerfil,
            Ativo = true,
            DataCadastro = DateTime.UtcNow,
            EmailConfirmed = true,
            Cidade = model.Cidade,
            Estado = model.Estado,
            Bairro = model.Bairro
        };

        var result = await _userManager.CreateAsync(user, senha);

        if (result.Succeeded)
        {
            TempData["Mensagem"] = "Usuário criado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }

    // POST: Admin/Usuarios/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var usuario = await _context.Users.FindAsync(id);
        if (usuario == null)
            return NotFound();

        // Não permite excluir administradores
        if (usuario.TipoPerfil == TipoPerfil.Administrador)
        {
            TempData["Erro"] = "Não é possível excluir um administrador.";
            return RedirectToAction(nameof(Index));
        }

        // Soft Delete: apenas marcar como inativo
        usuario.Ativo = false;
        await _context.SaveChangesAsync();

        TempData["Mensagem"] = $"✅ Perfil de {usuario.NomeCompleto} foi desativado com sucesso. Os dados continuam registrados no sistema para fins de segurança.";
        return RedirectToAction(nameof(Index));
    }

    // POST: Admin/Usuarios/Aprovar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Aprovar(string id)
    {
        if (!await IsAdmin())
            return Json(new { success = false });

        var usuario = await _context.Users.FindAsync(id);
        if (usuario == null)
            return Json(new { success = false });

        usuario.StatusAprovacao = Models.Enums.StatusAprovacao.Aprovado;
        usuario.DataAprovacao = DateTime.UtcNow;
        usuario.AprovadoPorAdminId = _userManager.GetUserId(User);
        
        await _context.SaveChangesAsync();
        
        // Criar notificação diretamente
        var notificacao = new Models.Notification
        {
            UserId = usuario.Id,
            Titulo = "✅ Perfil Aprovado",
            Mensagem = "Parabéns! Seu perfil foi aprovado pela equipe AUTistima.",
            Tipo = Models.TipoNotificacao.Sistema,
            Link = "/Account/Profile",
            DataCriacao = DateTime.UtcNow
        };
        _context.Notifications.Add(notificacao);
        await _context.SaveChangesAsync();

        return Json(new { success = true });
    }

    // POST: Admin/Usuarios/Rejeitar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Rejeitar(string id, string motivo)
    {
        if (!await IsAdmin())
            return Json(new { success = false });

        var usuario = await _context.Users.FindAsync(id);
        if (usuario == null)
            return Json(new { success = false });

        usuario.StatusAprovacao = Models.Enums.StatusAprovacao.Rejeitado;
        usuario.MotivoRejeicao = motivo;
        
        await _context.SaveChangesAsync();
        
        // Criar notificação diretamente
        var notificacao = new Models.Notification
        {
            UserId = usuario.Id,
            Titulo = "❌ Perfil Rejeitado",
            Mensagem = $"Seu perfil não atendeu aos critérios de aprovação. Motivo: {motivo}",
            Tipo = Models.TipoNotificacao.Sistema,
            Link = "/Account/Profile",
            DataCriacao = DateTime.UtcNow
        };
        _context.Notifications.Add(notificacao);
        await _context.SaveChangesAsync();

        return Json(new { success = true });
    }
}
