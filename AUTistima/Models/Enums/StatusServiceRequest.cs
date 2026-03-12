using System.ComponentModel.DataAnnotations;

namespace AUTistima.Models.Enums;

public enum StatusServiceRequest
{
    [Display(Name = "Pendente")]
    Pendente = 0,

    [Display(Name = "Em Análise")]
    EmAnalise = 1,

    [Display(Name = "Agendado")]
    Agendado = 2,

    [Display(Name = "Concluído")]
    Concluido = 3,

    [Display(Name = "Cancelado")]
    Cancelado = 4
}
