using AUTistima.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUTistima.Models;

/// <summary>
/// Solicitação de acesso de um profissional ao prontuário de um estudante
/// </summary>
public class SolicitacaoAcessoPerfil
{
    [Key]
    public int Id { get; set; }

    // Estudante alvo
    [Required]
    public int ChildId { get; set; }

    [ForeignKey("ChildId")]
    public virtual Child? Estudante { get; set; }

    // Profissional que solicita
    [Required]
    public string ProfissionalId { get; set; } = string.Empty;

    [ForeignKey("ProfissionalId")]
    public virtual ApplicationUser? Profissional { get; set; }

    // Código único do estudante informado ao solicitar
    [Required]
    [StringLength(20)]
    [Display(Name = "Código do Estudante")]
    public string CodigoEstudanteInformado { get; set; } = string.Empty;

    // Status e decisão
    [Display(Name = "Status")]
    public StatusSolicitacaoAcesso Status { get; set; } = StatusSolicitacaoAcesso.Pendente;

    [StringLength(500)]
    [Display(Name = "Motivo da Rejeição")]
    public string? MotivoRejeicao { get; set; }

    public DateTime DataSolicitacao { get; set; } = DateTime.UtcNow;

    public DateTime? DataDecisao { get; set; }

    // Admin que tomou a decisão
    public string? AprovadoPorAdminId { get; set; }

    [ForeignKey("AprovadoPorAdminId")]
    public virtual ApplicationUser? AprovadoPorAdmin { get; set; }
}
