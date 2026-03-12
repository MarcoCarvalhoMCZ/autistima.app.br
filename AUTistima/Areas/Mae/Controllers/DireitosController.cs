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
public class DireitosController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public DireitosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<ApplicationUser?> GetUser() => await _userManager.GetUserAsync(User);

    // GET: /Mae/Direitos
    public async Task<IActionResult> Index()
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var elegibilidades = await _context.BenefitEligibilities
            .Where(e => e.UserId == user.Id)
            .OrderByDescending(e => e.Data)
            .ToListAsync();

        var checklistItems = await _context.BenefitChecklistItems
            .Where(c => c.UserId == user.Id)
            .OrderBy(c => c.TipoBeneficio)
            .ThenBy(c => c.Item)
            .ToListAsync();

        ViewBag.Elegibilidades = elegibilidades;
        ViewBag.ChecklistItems = checklistItems;

        return View();
    }

    // GET: /Mae/Direitos/Triagem
    public IActionResult Triagem()
    {
        return View();
    }

    // POST: /Mae/Direitos/Triagem
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Triagem(
        bool temFilhoAutista,
        bool temLaudoMedico,
        bool rendaBPC,
        bool frequentaEscola,
        bool precisaTerapia)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var resultados = new List<(string, bool, string)>();

        // BPC/LOAS — Benefício de Prestação Continuada
        bool elegiBPC = temFilhoAutista && rendaBPC;
        resultados.Add(("BPC/LOAS", elegiBPC,
            elegiBPC
                ? "Provável elegibilidade ao BPC. Renda familiar per capita até 1/4 do salário mínimo e pessoa com deficiência comprovada."
                : "Critérios de renda ou laudo podem não estar atendidos para o BPC. Verifique junto ao INSS."));

        // Passe Livre
        bool elegiPasseLivre = temFilhoAutista && temLaudoMedico;
        resultados.Add(("Passe Livre Interestadual", elegiPasseLivre,
            elegiPasseLivre
                ? "Pessoa com TEA com laudo pode ter direito ao passe livre em transportes interestaduais (Lei 8.899/94)."
                : "Necessário laudo médico confirmando deficiência para solicitar o passe livre."));

        // Educação inclusiva
        bool elegiEscola = temFilhoAutista && frequentaEscola;
        resultados.Add(("AEE — Atendimento Educacional Especializado", elegiEscola,
            elegiEscola
                ? "Crianças autistas têm direito ao AEE na escola regular (LDB, Lei 12.764/2012)."
                : "Matricule seu filho em escola regular para ter acesso ao AEE."));

        // Plano de saúde — terapias
        bool elegiTerapia = temFilhoAutista && precisaTerapia && temLaudoMedico;
        resultados.Add(("Cobertura de Terapias pelo Plano", elegiTerapia,
            elegiTerapia
                ? "Planos privados são obrigados a cobrir TCC, ABA, fonoaudiologia e TO para TEA (Resolução ANS 539/2022)."
                : "Verifique com seu plano de saúde a cobertura prevista para TEA."));

        // Gravar resultados
        foreach (var (tipo, elegivel, justificativa) in resultados)
        {
            var existente = await _context.BenefitEligibilities
                .FirstOrDefaultAsync(e => e.UserId == user.Id && e.TipoBeneficio == tipo);

            if (existente != null)
            {
                existente.Elegivel = elegivel;
                existente.Justificativa = justificativa;
                existente.Data = DateTime.UtcNow;
            }
            else
            {
                _context.BenefitEligibilities.Add(new BenefitEligibility
                {
                    UserId = user.Id,
                    TipoBeneficio = tipo,
                    Elegivel = elegivel,
                    Justificativa = justificativa
                });
            }
        }

        // Criar checklist automático de documentos
        var documentosNecessarios = new List<(string, string)>
        {
            ("BPC/LOAS", "CPF e RG da pessoa com deficiência"),
            ("BPC/LOAS", "Laudo médico com CID-10"),
            ("BPC/LOAS", "Comprovante de renda familiar"),
            ("Passe Livre Interestadual", "Laudo médico com CID-10"),
            ("Passe Livre Interestadual", "RG e CPF"),
            ("AEE — Atendimento Educacional Especializado", "Laudo médico ou relatório escolar"),
            ("Cobertura de Terapias pelo Plano", "Prescrição médica de terapia"),
            ("Cobertura de Terapias pelo Plano", "Cartão do plano de saúde")
        };

        foreach (var (tipo, item) in documentosNecessarios)
        {
            var existente = await _context.BenefitChecklistItems
                .AnyAsync(c => c.UserId == user.Id && c.TipoBeneficio == tipo && c.Item == item);

            if (!existente)
            {
                _context.BenefitChecklistItems.Add(new BenefitChecklistItem
                {
                    UserId = user.Id,
                    TipoBeneficio = tipo,
                    Item = item,
                    Concluido = false
                });
            }
        }

        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Triagem concluída! Veja seus direitos abaixo.";
        return RedirectToAction(nameof(Index));
    }

    // POST: /Mae/Direitos/ToggleChecklist/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleChecklist(int id)
    {
        var user = await GetUser();
        if (user == null) return Challenge();

        var item = await _context.BenefitChecklistItems.FirstOrDefaultAsync(c => c.Id == id && c.UserId == user.Id);
        if (item != null)
        {
            item.Concluido = !item.Concluido;
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
