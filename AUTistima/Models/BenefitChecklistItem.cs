using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>Item de checklist de documentos para benefícios.</summary>
public class BenefitChecklistItem
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Usuario { get; set; }

    [Required, MaxLength(200)]
    public string Item { get; set; } = string.Empty;

    [MaxLength(100)]
    public string TipoBeneficio { get; set; } = string.Empty;

    public bool Concluido { get; set; } = false;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public DateTime? ConcluidoEm { get; set; }
}
