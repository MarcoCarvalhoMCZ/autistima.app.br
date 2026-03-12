using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>Agendamento confirmado de um atendimento.</summary>
public class ServiceAppointment
{
    public int Id { get; set; }

    public int RequestId { get; set; }

    [ForeignKey("RequestId")]
    public virtual ServiceRequest? Solicitacao { get; set; }

    public DateTime DataHora { get; set; }

    [MaxLength(50)]
    public string Canal { get; set; } = "Presencial";

    [MaxLength(500)]
    public string? LinkTeleatendimento { get; set; }

    [MaxLength(200)]
    public string? Local { get; set; }

    [MaxLength(1000)]
    public string? Observacoes { get; set; }

    public bool Confirmado { get; set; } = false;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
