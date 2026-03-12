using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AUTistima.Models.Enums;

namespace AUTistima.Models;

/// <summary>Vaga de emprego inclusiva cadastrada por empresa.</summary>
public class InclusiveJob
{
    public int Id { get; set; }

    [Required]
    public string EmpresaId { get; set; } = string.Empty;

    [ForeignKey("EmpresaId")]
    public virtual ApplicationUser? Empresa { get; set; }

    [Required, MaxLength(150)]
    public string Titulo { get; set; } = string.Empty;

    [Required, MaxLength(3000)]
    public string Descricao { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Acomodacoes { get; set; }

    [MaxLength(200)]
    public string? Localizacao { get; set; }

    [MaxLength(100)]
    public string? Regime { get; set; }

    public decimal? SalarioMin { get; set; }

    public decimal? SalarioMax { get; set; }

    public StatusInclusiveJob Status { get; set; } = StatusInclusiveJob.Ativa;

    public bool Ativo { get; set; } = true;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
