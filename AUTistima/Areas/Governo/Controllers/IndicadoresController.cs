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
public class IndicadoresController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public IndicadoresController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsAutorizado()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Governo || user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: /Governo/Indicadores
    public async Task<IActionResult> Index()
    {
        if (!await IsAutorizado())
            return RedirectToAction("Index", "Home", new { area = "" });

        var hoje = DateTime.UtcNow;
        var inicioMes = new DateTime(hoje.Year, hoje.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        var inicioAno = new DateTime(hoje.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Usuários por perfil (dados anônimos/agregados)
        var usuariosPorPerfil = await _context.Users
            .GroupBy(u => u.TipoPerfil)
            .Select(g => new { Perfil = g.Key, Total = g.Count() })
            .ToListAsync();

        // Total de crianças com TEA cadastradas
        ViewBag.TotalCriancas = await _context.Children.CountAsync();

        // Solicitações de serviço por status
        var solicitacoesPorStatus = await _context.ServiceRequests
            .GroupBy(s => s.Status)
            .Select(g => new { Status = g.Key, Total = g.Count() })
            .ToListAsync();

        // Serviços cadastrados ativos
        ViewBag.TotalServicos = await _context.Services.CountAsync(s => s.Ativo);

        // Posts da comunidade
        ViewBag.TotalPostsComunidade = await _context.Posts.CountAsync(p => p.Ativo);
        ViewBag.PostsEstesMes = await _context.Posts.CountAsync(p => p.Ativo && p.DataCriacao >= inicioMes);

        // Acolhimentos (curtidas de suporte)
        ViewBag.TotalAcolhimentos = await _context.PostAcolhimentos.CountAsync();

        // Usuários novos este mês
        ViewBag.UsuariosNovosMes = await _context.Users.CountAsync(u =>
            u.DataCadastro >= inicioMes);

        // Usuários novos este ano
        ViewBag.UsuariosNovosAno = await _context.Users.CountAsync(u =>
            u.DataCadastro >= inicioAno);

        // Denúncias pendentes
        ViewBag.DenunciasPendentes = await _context.Reports
            .CountAsync(r => r.Status == StatusModeracao.Pendente);

        // Planos de cuidado criados
        ViewBag.TotalPlanosCuidado = await _context.ChildCarePlans.CountAsync(p => p.Ativo);

        // Solicitações de agendamento este mês
        ViewBag.SolicitacoesMes = await _context.ServiceRequests
            .CountAsync(s => s.CriadoEm >= inicioMes);

        ViewBag.UsuariosPorPerfil = usuariosPorPerfil;
        ViewBag.SolicitacoesPorStatus = solicitacoesPorStatus;

        return View();
    }
}
