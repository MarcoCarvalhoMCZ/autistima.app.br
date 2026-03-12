using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;
using AUTistima.Services;

namespace AUTistima.Areas.Escola.Controllers;

[Area("Escola")]
[Authorize]
public class EscolaController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IPushNotificationService _push;
    private readonly ILogger<EscolaController> _logger;

    public EscolaController(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        IPushNotificationService push,
        ILogger<EscolaController> logger)
    {
        _context = context;
        _userManager = userManager;
        _push = push;
        _logger = logger;
    }

    private async Task<ApplicationUser?> GetEscolaUser()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Escola ? user : null;
    }

    // GET: Escola
    public async Task<IActionResult> Index()
    {
        var user = await GetEscolaUser();
        if (user == null) return RedirectToAction("Index", "Home", new { area = "" });

        var escola = user.EscolaVinculadaId.HasValue
            ? await _context.Schools.FindAsync(user.EscolaVinculadaId.Value)
            : null;

        ViewBag.TotalEstudantes = await _context.Children
            .CountAsync(c => c.EscolaId == user.EscolaVinculadaId || c.CadastradoPorEscolaUserId == user.Id);

        ViewBag.TotalRegistros = await _context.RegistrosEstudante
            .CountAsync(r => r.AutorId == user.Id && r.Ativo);

        ViewBag.SolicitacoesPendentes = await _context.SolicitacoesAcessoPerfil
            .CountAsync(s => s.Status == StatusSolicitacaoAcesso.Pendente
                          && _context.Children.Any(c => c.Id == s.ChildId
                              && (c.EscolaId == user.EscolaVinculadaId || c.CadastradoPorEscolaUserId == user.Id)));

        ViewBag.UltimosRegistros = await _context.RegistrosEstudante
            .Include(r => r.Estudante)
            .Where(r => r.AutorId == user.Id && r.Ativo)
            .OrderByDescending(r => r.DataRegistro)
            .Take(5)
            .ToListAsync();

        ViewBag.Escola = escola;
        return View(user);
    }

    // GET: Escola/MeusEstudantes
    public async Task<IActionResult> MeusEstudantes(string? busca, TipoComorbidade? comorbidade, int pagina = 1)
    {
        var user = await GetEscolaUser();
        if (user == null) return RedirectToAction("Index", "Home", new { area = "" });

        var query = _context.Children
            .Include(c => c.Usuario)
            .Where(c => c.EscolaId == user.EscolaVinculadaId || c.CadastradoPorEscolaUserId == user.Id);

        if (!string.IsNullOrWhiteSpace(busca))
            query = query.Where(c => c.Nome.Contains(busca) || c.CodigoUnico!.Contains(busca));

        if (comorbidade.HasValue && comorbidade.Value != TipoComorbidade.Nenhuma)
            query = query.Where(c => (c.Comorbidades & comorbidade.Value) == comorbidade.Value);

        var total = await query.CountAsync();
        var porPagina = 20;

        var estudantes = await query
            .OrderBy(c => c.Nome)
            .Skip((pagina - 1) * porPagina)
            .Take(porPagina)
            .ToListAsync();

        ViewBag.Busca = busca;
        ViewBag.Comorbidade = comorbidade;
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = (int)Math.Ceiling(total / (double)porPagina);
        ViewBag.Total = total;
        return View(estudantes);
    }

    // GET: Escola/CadastrarEstudante
    public async Task<IActionResult> CadastrarEstudante()
    {
        var user = await GetEscolaUser();
        if (user == null) return RedirectToAction("Index", "Home", new { area = "" });

        ViewBag.Escolas = await _context.Schools.Where(e => e.Ativo).OrderBy(e => e.Nome).ToListAsync();
        ViewBag.EscolaVinculadaId = user.EscolaVinculadaId;
        return View(new CadastrarEstudanteViewModel());
    }

    // POST: Escola/CadastrarEstudante
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CadastrarEstudante(CadastrarEstudanteViewModel vm)
    {
        var user = await GetEscolaUser();
        if (user == null) return RedirectToAction("Index", "Home", new { area = "" });

        if (!ModelState.IsValid)
        {
            ViewBag.Escolas = await _context.Schools.Where(e => e.Ativo).OrderBy(e => e.Nome).ToListAsync();
            ViewBag.EscolaVinculadaId = user.EscolaVinculadaId;
            return View(vm);
        }

        // 1. Verificar ou criar a conta da mãe/responsável
        var cpfNormalizado = vm.ResponsavelCPF?.Replace(".", "").Replace("-", "").Trim();
        ApplicationUser? mae = null;

        if (!string.IsNullOrEmpty(cpfNormalizado))
            mae = await _context.Users.FirstOrDefaultAsync(u => u.CPF == cpfNormalizado);

        string senhaGerada = string.Empty;
        bool criouMae = false;

        if (mae == null)
        {
            // Gerar email a partir do CPF e senha aleatória
            var emailMae = $"mae.{cpfNormalizado}@autistima.app.br";
            senhaGerada = GerarSenhaAleatoria();

            mae = new ApplicationUser
            {
                UserName = emailMae,
                Email = emailMae,
                NomeCompleto = vm.ResponsavelNome,
                CPF = cpfNormalizado,
                PhoneNumber = vm.ResponsavelTelefone,
                TipoPerfil = TipoPerfil.Mae,
                Ativo = true,
                EmailConfirmed = true,
                TermoConsentimentoAceito = false,
                DataCadastro = DateTime.UtcNow
            };

            var resultado = await _userManager.CreateAsync(mae, senhaGerada);
            if (!resultado.Succeeded)
            {
                foreach (var e in resultado.Errors)
                    ModelState.AddModelError("", e.Description);
                ViewBag.Escolas = await _context.Schools.Where(e => e.Ativo).OrderBy(e => e.Nome).ToListAsync();
                ViewBag.EscolaVinculadaId = user.EscolaVinculadaId;
                return View(vm);
            }
            criouMae = true;
        }

        // 2. Gerar código único do estudante
        var ano = DateTime.UtcNow.Year;
        var ultimoId = await _context.Children.MaxAsync(c => (int?)c.Id) ?? 0;
        var codigoUnico = $"ALU-{ano}-{(ultimoId + 1):D6}";

        // 3. Cadastrar o estudante
        var child = new Child
        {
            Nome = vm.NomeEstudante,
            DataNascimento = vm.DataNascimento,
            CodigoUnico = codigoUnico,
            EscolaId = vm.EscolaId ?? user.EscolaVinculadaId,
            EscolaNome = vm.EscolaNome,
            NivelSuporte = vm.NivelSuporte,
            PossuiDiagnostico = vm.PossuiDiagnostico,
            DataDiagnostico = vm.DataDiagnostico,
            PossuiPAE = vm.PossuiPAE,
            Comorbidades = vm.Comorbidades,
            OutrasCondicoes = vm.OutrasCondicoes,
            Observacoes = vm.Observacoes,
            UserId = mae.Id,
            CadastradoPorEscolaUserId = user.Id,
            DataCadastro = DateTime.UtcNow
        };

        _context.Children.Add(child);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Estudante {Nome} cadastrado pela escola {EscolaUserId}. Código: {Codigo}",
            child.Nome, user.Id, codigoUnico);

        // 4. Notificar a mãe/responsável via push
        string nomeEscola = "a escola";
        if (user.EscolaVinculadaId.HasValue)
        {
            var escolaDb = await _context.Schools.FindAsync(user.EscolaVinculadaId.Value);
            if (escolaDb != null) nomeEscola = escolaDb.Nome;
        }
        if (criouMae)
        {
            TempData["SenhaMae"] = senhaGerada;
            TempData["EmailMae"] = mae.Email;
            // Mãe recém-criada: push de boas-vindas com credenciais no app
            await _push.EnviarParaUsuarioAsync(
                mae.Id,
                "Bem-vinda ao AUTistima! 🌟",
                $"{child.Nome} foi cadastrado(a) por {nomeEscola}. " +
                $"Seu código de estudante é {codigoUnico}. Acesse com o e-mail: {mae.Email}",
                url: "/Mae/Filhos/Index"
            );
        }
        else
        {
            // Mãe já existia: push informativo sobre novo cadastro/vínculo escolar
            await _push.EnviarParaUsuarioAsync(
                mae.Id,
                "Estudante vinculado à escola 🏫",
                $"{child.Nome} foi vinculado(a) a {nomeEscola}. Código: {codigoUnico}.",
                url: "/Mae/Filhos/Index"
            );
        }

        TempData["Sucesso"] = $"Estudante {child.Nome} cadastrado com sucesso. Código: {codigoUnico}";
        TempData["CodigoEstudante"] = codigoUnico;
        return RedirectToAction(nameof(ProntuarioEstudante), new { id = child.Id });
    }

    // GET: Escola/ProntuarioEstudante/5
    public async Task<IActionResult> ProntuarioEstudante(int id)
    {
        var user = await GetEscolaUser();
        if (user == null) return RedirectToAction("Index", "Home", new { area = "" });

        var estudante = await _context.Children
            .Include(c => c.Escola)
            .Include(c => c.Usuario)
            .Include(c => c.Registros.Where(r => r.Ativo))
                .ThenInclude(r => r.Autor)
            .FirstOrDefaultAsync(c => c.Id == id
                && (c.EscolaId == user.EscolaVinculadaId || c.CadastradoPorEscolaUserId == user.Id));

        if (estudante == null)
            return NotFound();

        return View(estudante);
    }

    // GET: Escola/AdicionarRegistro/5
    public async Task<IActionResult> AdicionarRegistro(int id)
    {
        var user = await GetEscolaUser();
        if (user == null) return RedirectToAction("Index", "Home", new { area = "" });

        var estudante = await _context.Children
            .FirstOrDefaultAsync(c => c.Id == id
                && (c.EscolaId == user.EscolaVinculadaId || c.CadastradoPorEscolaUserId == user.Id));

        if (estudante == null) return NotFound();

        ViewBag.Estudante = estudante;
        return View(new RegistroEstudante { ChildId = id });
    }

    // POST: Escola/AdicionarRegistro
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdicionarRegistro(RegistroEstudante registro)
    {
        var user = await GetEscolaUser();
        if (user == null) return RedirectToAction("Index", "Home", new { area = "" });

        // Verificar que o estudante pertence a esta escola
        var estudante = await _context.Children
            .FirstOrDefaultAsync(c => c.Id == registro.ChildId
                && (c.EscolaId == user.EscolaVinculadaId || c.CadastradoPorEscolaUserId == user.Id));

        if (estudante == null) return NotFound();

        ModelState.Remove("Estudante");
        ModelState.Remove("Autor");

        if (!ModelState.IsValid)
        {
            ViewBag.Estudante = estudante;
            return View(registro);
        }

        registro.AutorId = user.Id;
        registro.DataRegistro = DateTime.UtcNow;
        registro.Ativo = true;

        _context.RegistrosEstudante.Add(registro);
        await _context.SaveChangesAsync();

        // Notificar mãe/responsável sobre novo registro no prontuário
        if (!string.IsNullOrEmpty(estudante.UserId))
        {
            var nomeAutor = user.NomeCompleto ?? user.Email ?? "Escola";
            await _push.EnviarParaUsuarioAsync(
                estudante.UserId,
                "Novo registro no prontuário 📋",
                $"{nomeAutor} adicionou um registro no prontuário de {estudante.Nome}.",
                url: "/Mae"
            );
        }

        TempData["Sucesso"] = "Registro adicionado ao prontuário com sucesso.";
        return RedirectToAction(nameof(ProntuarioEstudante), new { id = registro.ChildId });
    }

    // GET: Escola/EditarEstudante/5
    public async Task<IActionResult> EditarEstudante(int id)
    {
        var user = await GetEscolaUser();
        if (user == null) return RedirectToAction("Index", "Home", new { area = "" });

        var estudante = await _context.Children
            .FirstOrDefaultAsync(c => c.Id == id
                && (c.EscolaId == user.EscolaVinculadaId || c.CadastradoPorEscolaUserId == user.Id));

        if (estudante == null) return NotFound();

        var vm = new EditarEstudanteViewModel
        {
            Id              = estudante.Id,
            NomeEstudante   = estudante.Nome,
            DataNascimento  = estudante.DataNascimento,
            EscolaId        = estudante.EscolaId,
            EscolaNome      = estudante.EscolaNome,
            NivelSuporte    = estudante.NivelSuporte,
            PossuiDiagnostico = estudante.PossuiDiagnostico,
            DataDiagnostico = estudante.DataDiagnostico,
            PossuiPAE       = estudante.PossuiPAE,
            Comorbidades    = estudante.Comorbidades,
            OutrasCondicoes = estudante.OutrasCondicoes,
            EstrategiasCrise = estudante.EstrategiasCrise,
            Observacoes     = estudante.Observacoes
        };

        ViewBag.Escolas = await _context.Schools.Where(e => e.Ativo).OrderBy(e => e.Nome).ToListAsync();
        return View(vm);
    }

    // POST: Escola/EditarEstudante/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditarEstudante(int id, EditarEstudanteViewModel vm)
    {
        var user = await GetEscolaUser();
        if (user == null) return RedirectToAction("Index", "Home", new { area = "" });

        if (id != vm.Id) return BadRequest();

        var estudante = await _context.Children
            .FirstOrDefaultAsync(c => c.Id == id
                && (c.EscolaId == user.EscolaVinculadaId || c.CadastradoPorEscolaUserId == user.Id));

        if (estudante == null) return NotFound();

        if (!ModelState.IsValid)
        {
            ViewBag.Escolas = await _context.Schools.Where(e => e.Ativo).OrderBy(e => e.Nome).ToListAsync();
            return View(vm);
        }

        estudante.Nome            = vm.NomeEstudante;
        estudante.DataNascimento  = vm.DataNascimento;
        estudante.EscolaId        = vm.EscolaId;
        estudante.EscolaNome      = vm.EscolaNome;
        estudante.NivelSuporte    = vm.NivelSuporte;
        estudante.PossuiDiagnostico = vm.PossuiDiagnostico;
        estudante.DataDiagnostico = vm.DataDiagnostico;
        estudante.PossuiPAE       = vm.PossuiPAE;
        estudante.Comorbidades    = vm.Comorbidades;
        estudante.OutrasCondicoes = vm.OutrasCondicoes;
        estudante.EstrategiasCrise = vm.EstrategiasCrise;
        estudante.Observacoes     = vm.Observacoes;

        _context.Children.Update(estudante);
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Dados do estudante atualizados com sucesso.";
        return RedirectToAction(nameof(ProntuarioEstudante), new { id = estudante.Id });
    }

    private static string GerarSenhaAleatoria()
    {
        const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz23456789@#$!";
        using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
        var bytes = new byte[10];
        rng.GetBytes(bytes);
        return new string(bytes.Select(b => chars[b % chars.Length]).ToArray());
    }
}

/// <summary>ViewModel para cadastro de estudante pela escola</summary>
public class CadastrarEstudanteViewModel
{
    [Required(ErrorMessage = "Informe o nome do estudante.")]
    [StringLength(100)]
    [Display(Name = "Nome do Estudante")]
    public string NomeEstudante { get; set; } = string.Empty;

    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime? DataNascimento { get; set; }

    [Display(Name = "Escola")]
    public int? EscolaId { get; set; }

    [StringLength(200)]
    [Display(Name = "Nome da Escola")]
    public string? EscolaNome { get; set; }

    [Display(Name = "Nível de Suporte (TEA)")]
    public NivelSuporte? NivelSuporte { get; set; }

    [Display(Name = "Possui Diagnóstico Formal?")]
    public bool PossuiDiagnostico { get; set; }

    [Display(Name = "Data do Diagnóstico")]
    [DataType(DataType.Date)]
    public DateTime? DataDiagnostico { get; set; }

    [Display(Name = "Possui PAE?")]
    public bool PossuiPAE { get; set; }

    [Display(Name = "Comorbidades")]
    public TipoComorbidade Comorbidades { get; set; } = TipoComorbidade.Nenhuma;

    [StringLength(500)]
    [Display(Name = "Outras Condições")]
    public string? OutrasCondicoes { get; set; }

    [StringLength(1000)]
    [Display(Name = "Observações")]
    public string? Observacoes { get; set; }

    // Dados do responsável
    [Required(ErrorMessage = "Informe o nome do responsável.")]
    [StringLength(150)]
    [Display(Name = "Nome do Responsável")]
    public string ResponsavelNome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o CPF do responsável.")]
    [StringLength(14)]
    [Display(Name = "CPF do Responsável")]
    public string ResponsavelCPF { get; set; } = string.Empty;

    [StringLength(20)]
    [Display(Name = "Telefone do Responsável")]
    public string? ResponsavelTelefone { get; set; }
}

/// <summary>ViewModel para edição de estudante pela escola</summary>
public class EditarEstudanteViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome do estudante.")]
    [StringLength(100)]
    [Display(Name = "Nome do Estudante")]
    public string NomeEstudante { get; set; } = string.Empty;

    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime? DataNascimento { get; set; }

    [Display(Name = "Escola")]
    public int? EscolaId { get; set; }

    [StringLength(200)]
    [Display(Name = "Nome da Escola")]
    public string? EscolaNome { get; set; }

    [Display(Name = "Nível de Suporte (TEA)")]
    public NivelSuporte? NivelSuporte { get; set; }

    [Display(Name = "Possui Diagnóstico Formal?")]
    public bool PossuiDiagnostico { get; set; }

    [Display(Name = "Data do Diagnóstico")]
    [DataType(DataType.Date)]
    public DateTime? DataDiagnostico { get; set; }

    [Display(Name = "Possui PAE?")]
    public bool PossuiPAE { get; set; }

    [Display(Name = "Comorbidades")]
    public TipoComorbidade Comorbidades { get; set; } = TipoComorbidade.Nenhuma;

    [StringLength(500)]
    [Display(Name = "Outras Condições")]
    public string? OutrasCondicoes { get; set; }

    [StringLength(2000)]
    [Display(Name = "Estratégias para Crises")]
    public string? EstrategiasCrise { get; set; }

    [StringLength(1000)]
    [Display(Name = "Observações")]
    public string? Observacoes { get; set; }
}
