using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AUTistima.Models.Enums;

namespace AUTistima.Models;

/// <summary>Solicitação de exclusão/anonimização dos dados pessoais (LGPD Art. 18).</summary>
public class DataDeletionRequest
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Usuario { get; set; }

    [Required, MaxLength(500)]
    public string Motivo { get; set; } = string.Empty;

    public StatusRequisicaoLGPD Status { get; set; } = StatusRequisicaoLGPD.Pendente;

    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ProcessedAt { get; set; }

    [MaxLength(500)]
    public string? ObsAdmin { get; set; }
}
