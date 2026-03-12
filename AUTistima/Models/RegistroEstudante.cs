using AUTistima.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>
/// Registro inserido no prontuário do estudante por escola, profissional ou administração
/// </summary>
public class RegistroEstudante
{
    [Key]
    public int Id { get; set; }

    // Estudante vinculado
    [Required]
    public int ChildId { get; set; }

    [ForeignKey("ChildId")]
    public virtual Child? Estudante { get; set; }

    // Autor do registro
    [Required]
    public string AutorId { get; set; } = string.Empty;

    [ForeignKey("AutorId")]
    public virtual ApplicationUser? Autor { get; set; }

    [Required]
    [Display(Name = "Tipo de Registro")]
    public TipoRegistroEstudante TipoRegistro { get; set; }

    [Required]
    [StringLength(200)]
    [Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Conteúdo")]
    public string Conteudo { get; set; } = string.Empty;

    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

    public bool Ativo { get; set; } = true;
}
