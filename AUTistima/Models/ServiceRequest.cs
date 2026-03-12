using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AUTistima.Models.Enums;

namespace AUTistima.Models;

/// <summary>Solicitação de agendamento de serviço/atendimento.</summary>
public class ServiceRequest
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Solicitante { get; set; }

    public int? ServiceId { get; set; }

    [ForeignKey("ServiceId")]
    public virtual Service? Servico { get; set; }

    public int? ChildId { get; set; }

    [ForeignKey("ChildId")]
    public virtual Child? Filho { get; set; }

    [Required, MaxLength(1000)]
    public string Observacoes { get; set; } = string.Empty;

    public StatusServiceRequest Status { get; set; } = StatusServiceRequest.Pendente;

    public int Prioridade { get; set; } = 1;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public DateTime? RespondidoEm { get; set; }

    [MaxLength(500)]
    public string? RespostaServico { get; set; }

    public bool Ativo { get; set; } = true;

    public virtual ICollection<ServiceAppointment> Agendamentos { get; set; } = new List<ServiceAppointment>();
}
