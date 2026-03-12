using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>Preferências de acessibilidade do usuário.</summary>
public class AccessibilityPreference
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey("UserId")]
    public virtual ApplicationUser? Usuario { get; set; }

    public bool ModoLeituraFacil { get; set; } = false;

    public bool AudioDescricao { get; set; } = false;

    public bool UsarPictogramas { get; set; } = false;

    public bool AltoContraste { get; set; } = false;

    [MaxLength(10)]
    public string TamanhoFonte { get; set; } = "normal";

    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
}
