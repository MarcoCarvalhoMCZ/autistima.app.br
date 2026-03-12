using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>Registro de progresso/evidência na linha do tempo da criança.</summary>
public class ChildProgress
{
    public int Id { get; set; }

    public int ChildId { get; set; }

    [ForeignKey("ChildId")]
    public virtual Child? Filho { get; set; }

    public int? CarePlanId { get; set; }

    [ForeignKey("CarePlanId")]
    public virtual ChildCarePlan? PlanoAssociado { get; set; }

    [Required, MaxLength(100)]
    public string TipoRegistro { get; set; } = string.Empty;

    [Required, MaxLength(3000)]
    public string Observacao { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? AnexoUrl { get; set; }

    public DateTime Data { get; set; } = DateTime.UtcNow;

    public bool Ativo { get; set; } = true;
}
