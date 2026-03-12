using System.ComponentModel.DataAnnotations;

namespace AUTistima.Models.Enums;

/// <summary>
/// Tipo de registro inserido no prontuário do estudante
/// </summary>
public enum TipoRegistroEstudante
{
    [Display(Name = "Observação Escolar")]
    ObservacaoEscolar = 1,

    [Display(Name = "Relatório de Profissional")]
    RelatorioProfissional = 2,

    [Display(Name = "Avaliação Pedagógica")]
    AvaliacaoPedagogica = 3,

    [Display(Name = "Encaminhamento")]
    Encaminhamento = 4,

    [Display(Name = "Registro de Ocorrência")]
    RegistroOcorrencia = 5,

    [Display(Name = "Nota Administrativa")]
    NotaAdministrativa = 6
}
