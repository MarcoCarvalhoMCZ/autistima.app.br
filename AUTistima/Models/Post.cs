using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AUTistima.Models.Enums;

namespace AUTistima.Models;

/// <summary>
/// Post da Central de Acolhimento - espaço para desabafos e apoio
/// </summary>
public class Post
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "Conteúdo")]
    [DataType(DataType.MultilineText)]
    public string Conteudo { get; set; } = string.Empty;
    
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    
    public DateTime? DataAtualizacao { get; set; }
    
    public bool Ativo { get; set; } = true;
    
    [Display(Name = "Permitir Comentários")]
    public bool PermitirComentarios { get; set; } = true;

    // Moderação
    [Display(Name = "Status de Moderação")]
    public StatusModeracaoPost StatusModeracao { get; set; } = StatusModeracaoPost.Pendente;

    [StringLength(500)]
    [Display(Name = "Feedback de Moderação")]
    public string? FeedbackModeracao { get; set; }

    public DateTime? DataModeracao { get; set; }

    public string? ModeradorId { get; set; }
    [ForeignKey("ModeradorId")]
    public virtual ApplicationUser? Moderador { get; set; }
    
    // Autor do post
    [Required]
    public string UserId { get; set; } = string.Empty;
    
    [ForeignKey("UserId")]
    public virtual ApplicationUser? Autor { get; set; }
    
    // Navegações
    public virtual ICollection<PostAcolhimento> Acolhimentos { get; set; } = new List<PostAcolhimento>();
    public virtual ICollection<PostComment> Comentarios { get; set; } = new List<PostComment>();
    
    // Propriedade calculada
    [NotMapped]
    public int TotalAcolhimentos => Acolhimentos?.Count ?? 0;
}
