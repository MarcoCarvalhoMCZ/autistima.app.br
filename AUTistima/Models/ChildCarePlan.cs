using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AUTistima.Models.Enums;

namespace AUTistima.Models;

/// <summary>Plano Individual de Cuidado de uma criança.</summary>
public class ChildCarePlan
{
    public int Id { get; set; }

    public int ChildId { get; set; }

    [ForeignKey("ChildId")]
    public virtual Child? Filho { get; set; }

    [Required, MaxLength(100)]
    public string Titulo { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Objetivos { get; set; }

    [MaxLength(2000)]
    public string? Intervencoes { get; set; }

    [MaxLength(1000)]
    public string? Terapias { get; set; }

    public DateTime? DataInicio { get; set; }

    public DateTime? DataRevisao { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;

    public virtual ICollection<ChildProgress> Progressos { get; set; } = new List<ChildProgress>();
}
