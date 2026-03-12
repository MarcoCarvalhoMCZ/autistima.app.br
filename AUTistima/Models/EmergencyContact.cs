using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>Contato de emergência cadastrado no plano de segurança.</summary>
public class EmergencyContact
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Usuario { get; set; }

    [Required, MaxLength(150)]
    public string Nome { get; set; } = string.Empty;

    [Required, MaxLength(20)]
    public string Telefone { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Tipo { get; set; } = "Familiar";

    [MaxLength(200)]
    public string? Observacoes { get; set; }

    public bool Ativo { get; set; } = true;
}
