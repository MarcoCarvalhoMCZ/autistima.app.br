using System.ComponentModel.DataAnnotations;

namespace AUTistima.Models.Enums;

/// <summary>
/// Status de solicitação de acesso ao perfil do estudante
/// </summary>
public enum StatusSolicitacaoAcesso
{
    [Display(Name = "Pendente")]
    Pendente = 0,

    [Display(Name = "Aprovado")]
    Aprovado = 1,

    [Display(Name = "Rejeitado")]
    Rejeitado = 2
}
