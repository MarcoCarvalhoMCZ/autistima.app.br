using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;

namespace AUTistima.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class PostsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public PostsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsAdmin()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _context.Users.FindAsync(userId);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/Posts
    public async Task<IActionResult> Index(string? busca, bool? ativo, StatusModeracaoPost? statusModeracao, 
        DateTime? dataInicio, DateTime? dataFim, int pagina = 1)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.Posts
            .Include(p => p.Autor)
            .Include(p => p.Comentarios)
            .AsQueryable();

        // Filtro por busca (conteúdo ou autor)
        if (!string.IsNullOrWhiteSpace(busca))
        {
            query = query.Where(p => p.Conteudo.Contains(busca) || (p.Autor != null && p.Autor.NomeCompleto.Contains(busca)));
        }

        // Filtro por status ativo/inativo
        if (ativo.HasValue)
        {
            query = query.Where(p => p.Ativo == ativo.Value);
        }

        // Filtro por status de moderação
        if (statusModeracao.HasValue)
        {
            query = query.Where(p => p.StatusModeracao == statusModeracao.Value);
        }

        // Filtro por intervalo de datas
        if (dataInicio.HasValue)
        {
            query = query.Where(p => p.DataCriacao >= dataInicio.Value);
        }

        if (dataFim.HasValue)
        {
            var dataFimAjustada = dataFim.Value.AddDays(1);
            query = query.Where(p => p.DataCriacao < dataFimAjustada);
        }

        const int itensPorPagina = 20;
        var totalItens = await query.CountAsync();
        var totalPaginas = (int)Math.Ceiling(totalItens / (double)itensPorPagina);

        var posts = await query
            .OrderByDescending(p => p.DataCriacao)
            .Skip((pagina - 1) * itensPorPagina)
            .Take(itensPorPagina)
            .ToListAsync();

        ViewBag.Busca = busca;
        ViewBag.Ativo = ativo;
        ViewBag.StatusModeracao = statusModeracao;
        ViewBag.DataInicio = dataInicio?.ToString("yyyy-MM-dd");
        ViewBag.DataFim = dataFim?.ToString("yyyy-MM-dd");
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = totalPaginas;
        ViewBag.TotalItens = totalItens;
        ViewBag.StatusModeracaoEnum = Enum.GetValues(typeof(StatusModeracaoPost));

        return View(posts);
    }

    // GET: Admin/Posts/Create
    public async Task<IActionResult> Create()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        return View();
    }

    // POST: Admin/Posts/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string conteudo, bool permitirComentarios = true,
        List<int>? perfisSelecionados = null)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        if (string.IsNullOrWhiteSpace(conteudo))
        {
            ModelState.AddModelError("conteudo", "O conteúdo não pode ser vazio.");
            return View();
        }

        if (conteudo.Length > 2000)
        {
            ModelState.AddModelError("conteudo", "Máximo de 2000 caracteres.");
            return View();
        }

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        // null = todos; caso contrário: "1,2" etc.
        string? perfilDestino = null;
        if (perfisSelecionados != null && perfisSelecionados.Count > 0)
            perfilDestino = string.Join(",", perfisSelecionados);

        var post = new Post
        {
            Conteudo = conteudo.Trim(),
            UserId = userId!,
            ModeradorId = userId,
            PermitirComentarios = permitirComentarios,
            Ativo = true,
            StatusModeracao = StatusModeracaoPost.Aprovado,
            PerfilDestino = perfilDestino,
            DataCriacao = DateTime.UtcNow,
            DataModeracao = DateTime.UtcNow
        };

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        var alvo = perfilDestino == null ? "todos os usuários" :
            string.Join(", ", perfisSelecionados!.Select(p => ((AUTistima.Models.Enums.TipoPerfil)p).ToString()));
        TempData["Mensagem"] = $"✅ Postagem publicada para {alvo} com sucesso!";
        return RedirectToAction(nameof(Index));
    }

    // GET: Admin/Posts/Details/5
    public async Task<IActionResult> Details(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var post = await _context.Posts
            .Include(p => p.Autor)
            .Include(p => p.Comentarios)
                .ThenInclude(c => c.Autor)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (post == null)
            return NotFound();

        return View(post);
    }

    // GET: Admin/Posts/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return NotFound();

        return View(post);
    }

    // POST: Admin/Posts/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, string conteudo, bool permitirComentarios)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return NotFound();

        post.Conteudo = conteudo;
        post.PermitirComentarios = permitirComentarios;
        post.DataAtualizacao = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Post atualizado com sucesso.";
        return RedirectToAction(nameof(Details), new { id });
    }

    // POST: Admin/Posts/Aprovar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Aprovar(int id)
    {
        if (!await IsAdmin())
            return Json(new { success = false });

        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return Json(new { success = false });

        var moderadorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        post.StatusModeracao = StatusModeracaoPost.Aprovado;
        post.FeedbackModeracao = null;
        post.DataModeracao = DateTime.UtcNow;
        post.ModeradorId = moderadorId;
        post.Ativo = true;

        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Post aprovado.";
        return Json(new { success = true });
    }

    // POST: Admin/Posts/Reprovar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reprovar(int id, string feedback)
    {
        if (!await IsAdmin())
            return Json(new { success = false });

        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return Json(new { success = false });

        var moderadorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        post.StatusModeracao = StatusModeracaoPost.Reprovado;
        post.FeedbackModeracao = feedback;
        post.DataModeracao = DateTime.UtcNow;
        post.ModeradorId = moderadorId;
        post.Ativo = false; // esconder do feed

        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Post reprovado e ocultado.";
        return Json(new { success = true });
    }

    // POST: Admin/Posts/ToggleAtivo/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleAtivo(int id)
    {
        if (!await IsAdmin())
            return Json(new { success = false });

        var post = await _context.Posts.FindAsync(id);
        if (post == null)
            return Json(new { success = false });

        post.Ativo = !post.Ativo;
        post.DataAtualizacao = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        TempData["Mensagem"] = post.Ativo ? "Post reativado." : "Post desativado.";
        return Json(new { success = true, ativo = post.Ativo });
    }

    // POST: Admin/Posts/DeleteComentario/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteComentario(int id, int postId)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var comentario = await _context.PostComments.FindAsync(id);
        if (comentario == null)
        {
            TempData["Erro"] = "Comentário não encontrado.";
            return RedirectToAction(nameof(Details), new { id = postId });
        }

        comentario.Ativo = false;
        await _context.SaveChangesAsync();

        TempData["Mensagem"] = "Comentário removido.";
        return RedirectToAction(nameof(Details), new { id = postId });
    }

    // POST: Admin/Posts/RestaurarComentario/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RestaurarComentario(int id, int postId)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var comentario = await _context.PostComments.FindAsync(id);
        if (comentario == null)
        {
            TempData["Erro"] = "Comentário não encontrado.";
            return RedirectToAction(nameof(Details), new { id = postId });
        }

        comentario.Ativo = true;
        await _context.SaveChangesAsync();

        TempData["Mensagem"] = "Comentário restaurado.";
        return RedirectToAction(nameof(Details), new { id = postId });
    }

    // POST: Admin/Posts/Delete/5 (hard delete)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var post = await _context.Posts
            .Include(p => p.Comentarios)
            .Include(p => p.Acolhimentos)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (post == null)
            return NotFound();

        _context.PostComments.RemoveRange(post.Comentarios);
        _context.PostAcolhimentos.RemoveRange(post.Acolhimentos);
        _context.Posts.Remove(post);

        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Post removido definitivamente.";
        return RedirectToAction(nameof(Index));
    }
}
