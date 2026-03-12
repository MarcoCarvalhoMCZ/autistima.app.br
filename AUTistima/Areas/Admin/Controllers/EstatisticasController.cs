using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;
using AUTistima.Services;
using AUTistima.Extensions;
using System.Text;
using System.Text.Json;

namespace AUTistima.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class EstatisticasController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IStatisticsService _statisticsService;
    private readonly ILogger<EstatisticasController> _logger;

    public EstatisticasController(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        IStatisticsService statisticsService,
        ILogger<EstatisticasController> logger)
    {
        _context = context;
        _userManager = userManager;
        _statisticsService = statisticsService;
        _logger = logger;
    }

    private async Task<bool> IsAdmin()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Administrador;
    }

    // GET: Admin/Estatisticas
    public async Task<IActionResult> Index()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var metrics = await _statisticsService.ObterMetricasDashboard();
        return View(metrics);
    }

    // GET: Admin/Estatisticas/Engajamento
    public async Task<IActionResult> Engajamento(int dias = 30)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var dataInicio = DateTime.UtcNow.AddDays(-dias);
        var metrics = await _statisticsService.ObterMetricasEngajamento(dataInicio);
        ViewBag.DiasAnalise = dias;
        return View(metrics);
    }

    // GET: Admin/Estatisticas/Usuarios
    public async Task<IActionResult> Usuarios(int dias = 30)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var dataInicio = DateTime.UtcNow.AddDays(-dias);
        var metrics = await _statisticsService.ObterMetricasUsuarios(dataInicio);
        ViewBag.DiasAnalise = dias;
        return View(metrics);
    }

    // GET: Admin/Estatisticas/Conteudo
    public async Task<IActionResult> Conteudo(int dias = 30)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var dataInicio = DateTime.UtcNow.AddDays(-dias);
        var metrics = await _statisticsService.ObterMetricasConteudo(dataInicio);
        ViewBag.DiasAnalise = dias;
        return View(metrics);
    }

    // GET: Admin/Estatisticas/Triagens
    public async Task<IActionResult> Triagens(int dias = 90)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var dataInicio = DateTime.UtcNow.AddDays(-dias);
        var metrics = await _statisticsService.ObterMetricasTriagens(dataInicio);
        ViewBag.DiasAnalise = dias;
        return View(metrics);
    }

    // GET: Admin/Estatisticas/Historico
    public async Task<IActionResult> Historico(int dias = 30)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var snapshots = await _statisticsService.ObterHistoricoSnapshots(dias);
        ViewBag.DiasAnalise = dias;
        return View(snapshots);
    }

    // GET: Admin/Estatisticas/Atividades
    public async Task<IActionResult> Atividades(int pagina = 1)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var itensPorPagina = 50;
        var totalItens = await _context.UserActivities.CountAsync();
        var totalPaginas = (int)Math.Ceiling(totalItens / (double)itensPorPagina);

        var atividades = await _context.UserActivities
            .Include(a => a.Usuario)
            .OrderByDescending(a => a.DataHora)
            .Skip((pagina - 1) * itensPorPagina)
            .Take(itensPorPagina)
            .ToListAsync();

        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = totalPaginas;
        ViewBag.TotalItens = totalItens;

        return View(atividades);
    }

    // POST: Admin/Estatisticas/GerarSnapshot
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> GerarSnapshot()
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        try
        {
            await _statisticsService.GerarSnapshotDiario();
            TempData["Mensagem"] = "Snapshot de estatísticas gerado com sucesso! 📊";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao gerar snapshot de estatísticas");
            TempData["Erro"] = "Erro ao gerar snapshot. Tente novamente. 😔";
        }

        return RedirectToAction(nameof(Historico));
    }

    // API Endpoints para gráficos
    [HttpGet]
    public async Task<IActionResult> ApiDadosGrafico(string metrica, int dias = 30)
    {
        if (!await IsAdmin())
            return Unauthorized();

        var dados = await _statisticsService.ObterDadosGraficoTemporal(metrica, dias);
        return Json(dados);
    }

    [HttpGet]
    public async Task<IActionResult> ApiMetricasDashboard()
    {
        if (!await IsAdmin())
            return Unauthorized();

        var metrics = await _statisticsService.ObterMetricasDashboard();
        return Json(metrics);
    }

    [HttpGet]
    public async Task<IActionResult> ApiEngajamentoPorPerfil(int dias = 30)
    {
        if (!await IsAdmin())
            return Unauthorized();

        var dataInicio = DateTime.UtcNow.AddDays(-dias);
        var metrics = await _statisticsService.ObterMetricasEngajamento(dataInicio);
        return Json(metrics.EngajamentoPorPerfil.Select(x => new { perfil = x.Key.GetDisplayName(), total = x.Value }));
    }

    // GET: Admin/Estatisticas/Exportar
    public async Task<IActionResult> Exportar(string formato = "csv", int dias = 30)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var dataInicio = DateTime.UtcNow.AddDays(-dias);
        var dashboard = await _statisticsService.ObterMetricasDashboard();
        var engajamento = await _statisticsService.ObterMetricasEngajamento(dataInicio);
        var usuarios = await _statisticsService.ObterMetricasUsuarios(dataInicio);

        if (formato.ToLower() == "csv")
        {
            var csv = new StringBuilder();
            csv.AppendLine("RELATÓRIO ESTATÍSTICO AUTISTIMA");
            csv.AppendLine($"Período: Últimos {dias} dias");
            csv.AppendLine($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm}");
            csv.AppendLine();
            
            csv.AppendLine("=== TOTAIS ===");
            csv.AppendLine($"Total de Usuários;{dashboard.TotalUsuarios}");
            csv.AppendLine($"Mães Cadastradas;{dashboard.TotalMaes}");
            csv.AppendLine($"Profissionais de Saúde;{dashboard.TotalProfissionaisSaude}");
            csv.AppendLine($"Profissionais de Educação;{dashboard.TotalProfissionaisEducacao}");
            csv.AppendLine($"Empresas;{dashboard.TotalEmpresas}");
            csv.AppendLine($"Governo;{dashboard.TotalGoverno}");
            csv.AppendLine();
            
            csv.AppendLine("=== NOVOS CADASTROS ===");
            csv.AppendLine($"Novos este mês;{dashboard.NovosUsuariosMes}");
            csv.AppendLine($"Novos esta semana;{dashboard.NovosUsuariosSemana}");
            csv.AppendLine($"Novos hoje;{dashboard.NovosUsuariosHoje}");
            csv.AppendLine();
            
            csv.AppendLine("=== CONTEÚDO ===");
            csv.AppendLine($"Total de Posts;{dashboard.TotalPosts}");
            csv.AppendLine($"Total de Manejos;{dashboard.TotalManejos}");
            csv.AppendLine($"Total de Oportunidades;{dashboard.TotalOportunidades}");
            csv.AppendLine($"Total de Triagens;{dashboard.TotalTriagens}");
            csv.AppendLine();
            
            csv.AppendLine("=== ENGAJAMENTO ===");
            csv.AppendLine($"Usuários Ativos no Período;{engajamento.UsuariosAtivos}");
            csv.AppendLine($"Taxa de Engajamento;{engajamento.TaxaEngajamento}%");
            csv.AppendLine($"Posts Criados no Período;{engajamento.PostsCriados}");
            csv.AppendLine($"Acolhimentos no Período;{engajamento.TotalAcolhimentos}");
            csv.AppendLine($"Comentários no Período;{engajamento.TotalComentarios}");
            csv.AppendLine($"Média Acolhimentos/Post;{engajamento.MediaAcolhimentosPorPost}");
            csv.AppendLine();
            
            csv.AppendLine("=== ESTRUTURA ===");
            csv.AppendLine($"Total de Escolas;{dashboard.TotalEscolas}");
            csv.AppendLine($"Total de Serviços;{dashboard.TotalServicos}");
            csv.AppendLine($"Filhos Cadastrados;{dashboard.TotalFilhosCadastrados}");

            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", $"relatorio_autistima_{DateTime.Now:yyyyMMdd}.csv");
        }
        else // JSON
        {
            var relatorio = new
            {
                periodo = new { dias, dataInicio = dataInicio.ToString("dd/MM/yyyy"), dataFim = DateTime.UtcNow.ToString("dd/MM/yyyy") },
                dashboard,
                engajamento,
                usuarios,
                geradoEm = DateTime.Now
            };

            var json = JsonSerializer.Serialize(relatorio, new JsonSerializerOptions { WriteIndented = true });
            var bytes = Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", $"relatorio_autistima_{DateTime.Now:yyyyMMdd}.json");
        }
    }

    // GET: Admin/Estatisticas/Estudantes
    public async Task<IActionResult> Estudantes(int dias = 90)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var dataInicio = DateTime.UtcNow.AddDays(-dias);
        var metrics = await _statisticsService.ObterRelatorioEstudantes(dataInicio);
        ViewBag.DiasAnalise = dias;
        ViewBag.Escolas = await _context.Schools
            .Where(s => s.Ativo)
            .OrderBy(s => s.Nome)
            .Select(s => new { s.Id, Nome = s.Nome })
            .ToListAsync<object>();
        return View(metrics);
    }

    // GET: Admin/Estatisticas/ExportarEstudantesCSV
    public async Task<IActionResult> ExportarEstudantesCSV(int? escolaId = null)
    {
        if (!await IsAdmin())
            return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.Children
            .Include(c => c.Usuario)          // mãe/responsável
            .Include(c => c.Escola)            // escola vinculada
            .AsQueryable();

        if (escolaId.HasValue)
            query = query.Where(c => c.EscolaId == escolaId.Value);

        var estudantes = await query
            .OrderBy(c => c.EscolaNome)
            .ThenBy(c => c.Nome)
            .ToListAsync();

        var sb = new StringBuilder();
        // Cabeçalho
        sb.AppendLine("Código;Nome do Estudante;Data de Nascimento;Escola;Nível de Suporte;" +
                      "Diagnóstico;Data Diagnóstico;PAE;Comorbidades;Outras Condições;" +
                      "Responsável;E-mail Responsável;Telefone Responsável;Data de Cadastro");

        foreach (var e in estudantes)
        {
            var comorbLabels = Enum.GetValues(typeof(TipoComorbidade))
                .Cast<TipoComorbidade>()
                .Where(c => c != TipoComorbidade.Nenhuma && e.Comorbidades.HasFlag(c))
                .Select(c => c.GetDisplayName());

            sb.AppendLine(string.Join(";",
                Csv(e.CodigoUnico),
                Csv(e.Nome),
                e.DataNascimento?.ToString("dd/MM/yyyy") ?? "",
                Csv(e.EscolaNome),
                Csv(e.NivelSuporte?.GetDisplayName()),
                e.PossuiDiagnostico ? "Sim" : "Não",
                e.DataDiagnostico?.ToString("dd/MM/yyyy") ?? "",
                e.PossuiPAE ? "Sim" : "Não",
                Csv(string.Join(" | ", comorbLabels)),
                Csv(e.OutrasCondicoes),
                Csv(e.Usuario?.NomeCompleto),
                Csv(e.Usuario?.Email),
                Csv(e.Usuario?.PhoneNumber),
                e.DataCadastro.ToString("dd/MM/yyyy")
            ));
        }

        var bytes = Encoding.UTF8.GetPreamble().Concat(Encoding.UTF8.GetBytes(sb.ToString())).ToArray();
        var sufixoEscola = escolaId.HasValue ? $"_escola{escolaId}" : "_todas";
        var nomeArquivo = $"estudantes_semed{sufixoEscola}_{DateTime.Now:yyyyMMdd_HHmm}.csv";
        return File(bytes, "text/csv; charset=utf-8", nomeArquivo);
    }

    // Escapa valor para CSV (envolve em aspas se contém ponto-e-vírgula ou aspas)
    private static string Csv(string? valor)
    {
        if (string.IsNullOrEmpty(valor)) return string.Empty;
        if (valor.Contains(';') || valor.Contains('"') || valor.Contains('\n'))
            return $"\"{ valor.Replace("\"", "\"\"") }\"";
        return valor;
    }
}
