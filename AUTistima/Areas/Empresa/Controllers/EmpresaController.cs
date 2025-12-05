using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AUTistima.Data;
using AUTistima.Models;
using AUTistima.Models.Enums;

namespace AUTistima.Areas.Empresa.Controllers;

[Area("Empresa")]
[Authorize]
public class EmpresaController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public EmpresaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsEmpresa()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.TipoPerfil == TipoPerfil.Empresa;
    }

    // GET: Empresa
    public async Task<IActionResult> Index()
    {
        if (!await IsEmpresa())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        
        ViewBag.TotalOportunidades = await _context.Opportunities.CountAsync(o => o.UserId == user!.Id);
        ViewBag.OportunidadesAtivas = await _context.Opportunities.CountAsync(o => o.UserId == user!.Id && o.Ativo);
        
        return View();
    }

    // GET: Empresa/MinhasOportunidades
    public async Task<IActionResult> MinhasOportunidades()
    {
        if (!await IsEmpresa())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        
        var oportunidades = await _context.Opportunities
            .Where(o => o.UserId == user!.Id)
            .OrderByDescending(o => o.DataCriacao)
            .ToListAsync();

        return View(oportunidades);
    }

    // GET: Empresa/NovaOportunidade
    public async Task<IActionResult> NovaOportunidade()
    {
        if (!await IsEmpresa())
            return RedirectToAction("Index", "Home", new { area = "" });

        return View(new Opportunity());
    }

    // POST: Empresa/NovaOportunidade
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> NovaOportunidade(Opportunity oportunidade)
    {
        if (!await IsEmpresa())
            return RedirectToAction("Index", "Home", new { area = "" });

        ModelState.Remove("Id");
        ModelState.Remove("UserId");
        ModelState.Remove("Criador");

        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            oportunidade.UserId = user!.Id;
            oportunidade.DataCriacao = DateTime.UtcNow;
            oportunidade.Ativo = true;

            _context.Opportunities.Add(oportunidade);
            await _context.SaveChangesAsync();
            
            TempData["Mensagem"] = "Oportunidade criada com sucesso!";
            return RedirectToAction(nameof(MinhasOportunidades));
        }

        return View(oportunidade);
    }

    // GET: Empresa/EditarOportunidade/5
    public async Task<IActionResult> EditarOportunidade(int id)
    {
        if (!await IsEmpresa())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        var oportunidade = await _context.Opportunities
            .FirstOrDefaultAsync(o => o.Id == id && o.UserId == user!.Id);

        if (oportunidade == null)
            return NotFound();

        return View(oportunidade);
    }

    // POST: Empresa/EditarOportunidade/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditarOportunidade(int id, Opportunity oportunidade)
    {
        if (!await IsEmpresa())
            return RedirectToAction("Index", "Home", new { area = "" });

        if (id != oportunidade.Id)
            return NotFound();

        var user = await _userManager.GetUserAsync(User);
        var existing = await _context.Opportunities
            .FirstOrDefaultAsync(o => o.Id == id && o.UserId == user!.Id);

        if (existing == null)
            return NotFound();

        ModelState.Remove("UserId");
        ModelState.Remove("Criador");

        existing.Titulo = oportunidade.Titulo;
        existing.Descricao = oportunidade.Descricao;
        existing.Tipo = oportunidade.Tipo;
        existing.Requisitos = oportunidade.Requisitos;
        existing.Beneficios = oportunidade.Beneficios;
        existing.ValorSalario = oportunidade.ValorSalario;
        existing.PermiteHomeOffice = oportunidade.PermiteHomeOffice;
        existing.HorarioFlexivel = oportunidade.HorarioFlexivel;
        existing.Cidade = oportunidade.Cidade;
        existing.Estado = oportunidade.Estado;
        existing.Contato = oportunidade.Contato;
        existing.LinkExterno = oportunidade.LinkExterno;
        existing.DataExpiracao = oportunidade.DataExpiracao;
        existing.Ativo = oportunidade.Ativo;

        await _context.SaveChangesAsync();
        TempData["Mensagem"] = "Oportunidade atualizada com sucesso!";
        return RedirectToAction(nameof(MinhasOportunidades));
    }

    // POST: Empresa/ExcluirOportunidade/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ExcluirOportunidade(int id)
    {
        if (!await IsEmpresa())
            return RedirectToAction("Index", "Home", new { area = "" });

        var user = await _userManager.GetUserAsync(User);
        var oportunidade = await _context.Opportunities
            .FirstOrDefaultAsync(o => o.Id == id && o.UserId == user!.Id);

        if (oportunidade != null)
        {
            _context.Opportunities.Remove(oportunidade);
            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Oportunidade excluída com sucesso!";
        }

        return RedirectToAction(nameof(MinhasOportunidades));
    }
}
