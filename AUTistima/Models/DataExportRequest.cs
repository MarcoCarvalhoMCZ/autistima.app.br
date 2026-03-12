using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AUTistima.Models.Enums;

namespace AUTistima.Models;

/// <summary>Solicitação de exportação dos dados pessoais (LGPD Art. 18).</summary>
public class DataExportRequest
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Usuario { get; set; }

    public StatusRequisicaoLGPD Status { get; set; } = StatusRequisicaoLGPD.Pendente;

    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ProcessedAt { get; set; }

    [MaxLength(500)]
    public string? DownloadUrl { get; set; }
}
