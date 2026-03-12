using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>Plano de segurança familiar criado pela mãe.</summary>
public class SafetyPlan
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Usuario { get; set; }

    [MaxLength(3000)]
    public string? SinaisAlerta { get; set; }

    [MaxLength(3000)]
    public string? EstrategiasDesescalada { get; set; }

    [MaxLength(2000)]
    public string? RecursosLocais { get; set; }

    [MaxLength(2000)]
    public string? PlanoAposIntervencao { get; set; }

    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;

    public virtual ICollection<EmergencyContact> ContatosEmergencia { get; set; } = new List<EmergencyContact>();
}
