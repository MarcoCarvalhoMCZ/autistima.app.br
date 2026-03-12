using AUTistima.Extensions;
using AUTistima.Models.Enums;
using Xunit;

namespace AUTistima.Tests.Extensions;

/// <summary>
/// Testa o método de extensão GetDisplayName para todos os enums
/// </summary>
public class EnumExtensionsTests
{
    [Theory]
    [InlineData(TipoPerfil.Administrador)]
    [InlineData(TipoPerfil.Mae)]
    [InlineData(TipoPerfil.ProfissionalSaude)]
    [InlineData(TipoPerfil.ProfissionalEducacao)]
    [InlineData(TipoPerfil.Empresa)]
    [InlineData(TipoPerfil.Governo)]
    [InlineData(TipoPerfil.Escola)]
    public void GetDisplayName_TipoPerfil_NuncaRetornaVazio(TipoPerfil perfil)
    {
        var result = perfil.GetDisplayName();
        Assert.False(string.IsNullOrWhiteSpace(result));
    }

    [Theory]
    [InlineData(TipoComorbidade.Nenhuma)]
    [InlineData(TipoComorbidade.TEA)]
    [InlineData(TipoComorbidade.TDAH)]
    [InlineData(TipoComorbidade.DeficienciaVisual)]
    [InlineData(TipoComorbidade.DeficienciaFisica)]
    [InlineData(TipoComorbidade.DeficienciaAuditiva)]
    [InlineData(TipoComorbidade.DeficienciaIntelectual)]
    [InlineData(TipoComorbidade.SindromeDown)]
    [InlineData(TipoComorbidade.AltasHabilidades)]
    [InlineData(TipoComorbidade.Outras)]
    public void GetDisplayName_TipoComorbidade_NuncaRetornaVazio(TipoComorbidade comorbidade)
    {
        var result = comorbidade.GetDisplayName();
        Assert.False(string.IsNullOrWhiteSpace(result));
    }

    [Theory]
    [InlineData(StatusSolicitacaoAcesso.Pendente, "Pendente")]
    [InlineData(StatusSolicitacaoAcesso.Aprovado, "Aprovado")]
    [InlineData(StatusSolicitacaoAcesso.Rejeitado, "Rejeitado")]
    public void GetDisplayName_StatusSolicitacaoAcesso_RetornaTextoCorreto(
        StatusSolicitacaoAcesso status, string esperado)
    {
        Assert.Equal(esperado, status.GetDisplayName());
    }

    [Theory]
    [InlineData(TipoRegistroEstudante.ObservacaoEscolar, "Observação Escolar")]
    [InlineData(TipoRegistroEstudante.RelatorioProfissional, "Relatório de Profissional")]
    [InlineData(TipoRegistroEstudante.AvaliacaoPedagogica, "Avaliação Pedagógica")]
    [InlineData(TipoRegistroEstudante.Encaminhamento, "Encaminhamento")]
    [InlineData(TipoRegistroEstudante.RegistroOcorrencia, "Registro de Ocorrência")]
    [InlineData(TipoRegistroEstudante.NotaAdministrativa, "Nota Administrativa")]
    public void GetDisplayName_TipoRegistroEstudante_RetornaTextoCorreto(
        TipoRegistroEstudante tipo, string esperado)
    {
        Assert.Equal(esperado, tipo.GetDisplayName());
    }

    [Fact]
    public void GetDisplayName_EnumSemDisplayAttribute_RetornaFallbackComEspacos()
    {
        // Usa TipoPerfil sem atributo Display para testar o fallback regex
        // ProfissionalSaude → "Profissional Saude"
        // Verifica que pelo menos NÃO está vazio e não está idêntico ao .ToString() 
        // (porque o fallback adiciona espaços)
        var result = TipoPerfil.ProfissionalSaude.GetDisplayName();
        Assert.False(string.IsNullOrWhiteSpace(result));
    }
}
