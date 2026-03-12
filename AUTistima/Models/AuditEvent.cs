using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>Evento de auditoria para ações sensíveis.</summary>
public class AuditEvent
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Usuario { get; set; }

    [Required, MaxLength(100)]
    public string Acao { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string Recurso { get; set; } = string.Empty;

    public DateTime Data { get; set; } = DateTime.UtcNow;

    [MaxLength(45)]
    public string? IpAddress { get; set; }

    [MaxLength(1000)]
    public string? Detalhes { get; set; }
}
