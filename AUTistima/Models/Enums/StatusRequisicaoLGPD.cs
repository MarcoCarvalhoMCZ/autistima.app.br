using System.ComponentModel.DataAnnotations;

namespace AUTistima.Models.Enums;

public enum StatusRequisicaoLGPD
{
    [Display(Name = "Pendente")]
    Pendente = 0,

    [Display(Name = "Em Processamento")]
    EmProcessamento = 1,

    [Display(Name = "Concluído")]
    Concluido = 2,

    [Display(Name = "Rejeitado")]
    Rejeitado = 3
}
