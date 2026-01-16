using System.ComponentModel.DataAnnotations;

namespace AUTistima.Models;

/// <summary>
/// Especialidade gerenciada pelo administrador para controlar opções disponíveis.
/// </summary>
public class EspecialidadeProfissional
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(150)]
    [Display(Name = "Nome da Especialidade")]
    public string Nome { get; set; } = string.Empty;
    
    [StringLength(300)]
    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }
    [Display(Name = "Ordem de Exibição")]
    public int Ordem { get; set; } = 0;
    
    public bool Ativo { get; set; } = true;
}
