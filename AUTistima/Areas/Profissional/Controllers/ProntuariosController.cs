using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;

namespace AUTistima.Areas.Profissional.Controllers;

[Area("Profissional")]
[Authorize]
public class ProntuariosController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<ProntuariosController> _logger;

    public ProntuariosController(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        ILogger<ProntuariosController> logger)
    {
        _context = context;
        _userManager = userManager;
        _logger = logger;
    }

    private async Task<ApplicationUser?> GetProfissional()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return null;
        return user.TipoPerfil is TipoPerfil.ProfissionalSaude or TipoPerfil.ProfissionalEducacao ? user : null;
    }

    // GET: Profissional/Prontuarios — lista de estudantes com acesso aprovado
    public async Task<IActionResult> Index()
    {
        var prof = await GetProfissional();
        if (prof == null) return RedirectToAction("Index", "Home", new { area = "" });

        var acessos = await _context.SolicitacoesAcessoPerfil
            .Include(s => s.Estudante).ThenInclude(c => c!.Escola)
            .Where(s => s.ProfissionalId == prof.Id && s.Status == StatusSolicitacaoAcesso.Aprovado)
            .OrderBy(s => s.Estudante!.Nome)
            .ToListAsync();

        return View(acessos);
    }

    // GET: Profissional/Prontuarios/SolicitarAcesso
    public IActionResult SolicitarAcesso()
    {
        return View();
    }

    // POST: Profissional/Prontuarios/SolicitarAcesso
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SolicitarAcesso(string codigoEstudante)
    {
        var prof = await GetProfissional();
        if (prof == null) return RedirectToAction("Index", "Home", new { area = "" });

        if (string.IsNullOrWhiteSpace(codigoEstudante))
        {
            ModelState.AddModelError("", "Informe o código do estudante.");
            return View();
        }

        var codigo = codigoEstudante.Trim().ToUpper();
        var estudante = await _context.Children
            .FirstOrDefaultAsync(c => c.CodigoUnico == codigo);

        if (estudante == null)
        {
            ModelState.AddModelError("", "Código não encontrado. Verifique o código informado.");
            return View();
        }

        // Verificar se já existe solicitação desse profissional para esse estudante
        var existe = await _context.SolicitacoesAcessoPerfil
            .AnyAsync(s => s.ProfissionalId == prof.Id && s.ChildId == estudante.Id);

        if (existe)
        {
            ModelState.AddModelError("", "Já existe uma solicitação para este estudante. Aguarde a aprovação ou verifique o status.");
            return View();
        }

        var solicitacao = new SolicitacaoAcessoPerfil
        {
            ChildId = estudante.Id,
            ProfissionalId = prof.Id,
            CodigoEstudanteInformado = codigo,
            Status = StatusSolicitacaoAcesso.Pendente,
            DataSolicitacao = DateTime.UtcNow
        };

        _context.SolicitacoesAcessoPerfil.Add(solicitacao);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Profissional {ProfId} solicitou acesso ao estudante {Codigo}", prof.Id, codigo);
        TempData["Sucesso"] = $"Solicitação enviada! Você será notificado quando a administração aprovar o acesso ao prontuário de {estudante.Nome}.";
        return RedirectToAction(nameof(Index));
    }

    // GET: Profissional/Prontuarios/VerProntuario/5
    public async Task<IActionResult> VerProntuario(int id)
    {
        var prof = await GetProfissional();
        if (prof == null) return RedirectToAction("Index", "Home", new { area = "" });

        // Verificar que há acesso aprovado
        var acesso = await _context.SolicitacoesAcessoPerfil
            .AnyAsync(s => s.ProfissionalId == prof.Id
                        && s.ChildId == id
                        && s.Status == StatusSolicitacaoAcesso.Aprovado);

        if (!acesso) return Forbid();

        var estudante = await _context.Children
            .Include(c => c.Escola)
            .Include(c => c.Usuario)
            .Include(c => c.Registros.Where(r => r.Ativo))
                .ThenInclude(r => r.Autor)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (estudante == null) return NotFound();
        return View(estudante);
    }

    // POST: Profissional/Prontuarios/AdicionarRegistro
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdicionarRegistro(RegistroEstudante registro)
    {
        var prof = await GetProfissional();
        if (prof == null) return RedirectToAction("Index", "Home", new { area = "" });

        // Verificar acesso aprovado
        var acesso = await _context.SolicitacoesAcessoPerfil
            .AnyAsync(s => s.ProfissionalId == prof.Id
                        && s.ChildId == registro.ChildId
                        && s.Status == StatusSolicitacaoAcesso.Aprovado);

        if (!acesso) return Forbid();

        ModelState.Remove("Estudante");
        ModelState.Remove("Autor");

        if (!ModelState.IsValid)
        {
            var estudante = await _context.Children.FindAsync(registro.ChildId);
            ViewBag.Estudante = estudante;
            return View(registro);
        }

        registro.AutorId = prof.Id;
        registro.DataRegistro = DateTime.UtcNow;
        registro.Ativo = true;

        _context.RegistrosEstudante.Add(registro);
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Registro adicionado ao prontuário.";
        return RedirectToAction(nameof(VerProntuario), new { id = registro.ChildId });
    }

    // GET: Profissional/Prontuarios/AdicionarRegistro/5
    public async Task<IActionResult> AdicionarRegistro(int id)
    {
        var prof = await GetProfissional();
        if (prof == null) return RedirectToAction("Index", "Home", new { area = "" });

        var acesso = await _context.SolicitacoesAcessoPerfil
            .AnyAsync(s => s.ProfissionalId == prof.Id
                        && s.ChildId == id
                        && s.Status == StatusSolicitacaoAcesso.Aprovado);

        if (!acesso) return Forbid();

        var estudante = await _context.Children.FindAsync(id);
        if (estudante == null) return NotFound();

        ViewBag.Estudante = estudante;
        return View(new RegistroEstudante { ChildId = id });
    }
}
