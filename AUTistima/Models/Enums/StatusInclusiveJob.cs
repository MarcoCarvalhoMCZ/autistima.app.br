using System.ComponentModel.DataAnnotations;

namespace AUTistima.Models.Enums;

public enum StatusInclusiveJob
{
    [Display(Name = "Ativa")]
    Ativa = 0,

    [Display(Name = "Pausada")]
    Pausada = 1,

    [Display(Name = "Encerrada")]
    Encerrada = 2
}
