using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>Resultado de triagem de elegibilidade a benefícios.</summary>
public class BenefitEligibility
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Usuario { get; set; }

    [Required, MaxLength(100)]
    public string TipoBeneficio { get; set; } = string.Empty;

    public bool Elegivel { get; set; }

    [MaxLength(2000)]
    public string? Justificativa { get; set; }

    public DateTime Data { get; set; } = DateTime.UtcNow;
}
