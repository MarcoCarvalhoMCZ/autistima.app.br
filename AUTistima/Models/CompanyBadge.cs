using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>Selo "Empresa Amiga do Autismo" conquistado por empresa.</summary>
public class CompanyBadge
{
    public int Id { get; set; }

    [Required]
    public string EmpresaId { get; set; } = string.Empty;

    [ForeignKey("EmpresaId")]
    public virtual ApplicationUser? Empresa { get; set; }

    [Required, MaxLength(50)]
    public string Nivel { get; set; } = "Bronze"; // Bronze, Prata, Ouro

    [MaxLength(200)]
    public string? Justificativa { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime ConquistadoEm { get; set; } = DateTime.UtcNow;
}
