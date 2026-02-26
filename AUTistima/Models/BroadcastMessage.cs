using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AUTistima.Models.Enums;

namespace AUTistima.Models;

/// <summary>
/// Registro de avisos em massa enviados pelo administrador.
/// Cada envio gera um BroadcastMessage + N Notifications (uma por destinatário).
/// </summary>
public class BroadcastMessage
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [StringLength(1000)]
    [Display(Name = "Mensagem")]
    public string Mensagem { get; set; } = string.Empty;

    [StringLength(255)]
    [Display(Name = "Link")]
    public string? Link { get; set; }

    /// <summary>
    /// "Todos" | "Perfil:{TipoPerfil}" | "Selecionados"
    /// </summary>
    [Required]
    [StringLength(50)]
    public string TipoDestino { get; set; } = "Todos";

    /// <summary>
    /// Quando TipoDestino == "Perfil:{X}", armazena o valor inteiro do enum TipoPerfil.
    /// Null para Todos e Selecionados.
    /// </summary>
    public int? PerfilDestino { get; set; }

    /// <summary>
    /// Quantidade total de destinatários que receberam o aviso.
    /// </summary>
    public int TotalDestinatarios { get; set; }

    [Required]
    public string RemetenteId { get; set; } = string.Empty;

    public DateTime DataEnvio { get; set; } = DateTime.UtcNow;

    // Navegação
    [ForeignKey("RemetenteId")]
    public virtual ApplicationUser? Remetente { get; set; }
}
