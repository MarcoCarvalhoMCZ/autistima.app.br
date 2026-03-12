using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>Registro de consentimento LGPD do usuário.</summary>
public class ConsentLog
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Usuario { get; set; }

    [Required, MaxLength(100)]
    public string TipoConsentimento { get; set; } = string.Empty;

    public bool Aceite { get; set; }

    public DateTime Data { get; set; } = DateTime.UtcNow;

    [MaxLength(45)]
    public string? IpAddress { get; set; }

    [MaxLength(500)]
    public string? Detalhes { get; set; }
}
