using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>Lembrete de consulta ou terapia da criança.</summary>
public class AppointmentReminder
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Usuario { get; set; }

    public int? ChildId { get; set; }

    [ForeignKey("ChildId")]
    public virtual Child? Filho { get; set; }

    [Required, MaxLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Descricao { get; set; }

    [MaxLength(200)]
    public string? Local { get; set; }

    public DateTime DataHora { get; set; }

    public bool NotificacaoEnviada { get; set; } = false;

    public bool Ativo { get; set; } = true;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
