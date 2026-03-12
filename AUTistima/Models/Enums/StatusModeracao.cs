using System.ComponentModel.DataAnnotations;

namespace AUTistima.Models.Enums;

public enum StatusModeracao
{
    [Display(Name = "Pendente")]
    Pendente = 0,

    [Display(Name = "Em Análise")]
    EmAnalise = 1,

    [Display(Name = "Resolvido")]
    Resolvido = 2,

    [Display(Name = "Arquivado")]
    Arquivado = 3
}
