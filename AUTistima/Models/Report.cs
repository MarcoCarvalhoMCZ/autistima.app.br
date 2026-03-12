using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AUTistima.Models.Enums;

namespace AUTistima.Models;

/// <summary>Denúncia de post ou comentário na comunidade.</summary>
public class Report
{
    public int Id { get; set; }

    [Required]
    public string ReporterId { get; set; } = string.Empty;

    [ForeignKey("ReporterId")]
    public virtual ApplicationUser? Denunciante { get; set; }

    [Required, MaxLength(50)]
    public string TargetType { get; set; } = string.Empty; // "Post", "Comment"

    public int TargetId { get; set; }

    [Required, MaxLength(500)]
    public string Motivo { get; set; } = string.Empty;

    public StatusModeracao Status { get; set; } = StatusModeracao.Pendente;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public string? ResolvidoPorId { get; set; }

    [ForeignKey("ResolvidoPorId")]
    public virtual ApplicationUser? ResolvidoPor { get; set; }

    public DateTime? ResolvidoEm { get; set; }

    [MaxLength(500)]
    public string? ObsResolucao { get; set; }
}
