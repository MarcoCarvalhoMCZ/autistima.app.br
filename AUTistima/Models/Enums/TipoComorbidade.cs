using System.ComponentModel.DataAnnotations;

namespace AUTistima.Models.Enums;

/// <summary>
/// Comorbidades e condições do estudante (flags — pode ter mais de uma)
/// </summary>
[Flags]
public enum TipoComorbidade
{
    [Display(Name = "Nenhuma")]
    Nenhuma = 0,

    [Display(Name = "TEA (Transtorno do Espectro Autista)")]
    TEA = 1,

    [Display(Name = "TDAH (Transtorno do Déficit de Atenção e Hiperatividade)")]
    TDAH = 2,

    [Display(Name = "Deficiência Visual")]
    DeficienciaVisual = 4,

    [Display(Name = "Deficiência Física")]
    DeficienciaFisica = 8,

    [Display(Name = "Deficiência Auditiva")]
    DeficienciaAuditiva = 16,

    [Display(Name = "Deficiência Intelectual")]
    DeficienciaIntelectual = 32,

    [Display(Name = "Síndrome de Down")]
    SindromeDown = 64,

    [Display(Name = "Altas Habilidades / Superdotação")]
    AltasHabilidades = 128,

    [Display(Name = "Outras")]
    Outras = 256
}
