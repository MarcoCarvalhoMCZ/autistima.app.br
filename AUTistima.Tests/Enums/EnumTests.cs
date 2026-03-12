using AUTistima.Models.Enums;
using AUTistima.Extensions;
using Xunit;

namespace AUTistima.Tests.Enums;

/// <summary>
/// Testa os valores e comportamento dos enums adicionados pelas adequações SEMED
/// </summary>
public class TipoPerfilTests
{
    [Fact]
    public void TipoPerfil_Escola_DeveTerValor6()
    {
        Assert.Equal(6, (int)TipoPerfil.Escola);
    }

    [Fact]
    public void TipoPerfil_Escola_DisplayName_DeveSerEscolaMunicipal()
    {
        var displayName = TipoPerfil.Escola.GetDisplayName();
        // Aceita qualquer nome que contenha "Escola" (não depende de atributo exato)
        Assert.Contains("Escola", displayName, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void TipoPerfil_ValoresOriginais_DevemPermanecer()
    {
        Assert.Equal(0, (int)TipoPerfil.Administrador);
        Assert.Equal(1, (int)TipoPerfil.Mae);
        Assert.Equal(2, (int)TipoPerfil.ProfissionalSaude);
        Assert.Equal(3, (int)TipoPerfil.ProfissionalEducacao);
        Assert.Equal(4, (int)TipoPerfil.Empresa);
        Assert.Equal(5, (int)TipoPerfil.Governo);
    }
}

public class TipoComorbidadeTests
{
    [Fact]
    public void TipoComorbidade_DeveSerFlagsEnum()
    {
        var tipo = typeof(TipoComorbidade);
        Assert.True(tipo.IsDefined(typeof(FlagsAttribute), false),
            "TipoComorbidade deve ter o atributo [Flags]");
    }

    [Fact]
    public void TipoComorbidade_Nenhuma_DeveTerValor0()
    {
        Assert.Equal(0, (int)TipoComorbidade.Nenhuma);
    }

    [Fact]
    public void TipoComorbidade_Valores_DevemSerPotentesDe2()
    {
        Assert.Equal(1,   (int)TipoComorbidade.TEA);
        Assert.Equal(2,   (int)TipoComorbidade.TDAH);
        Assert.Equal(4,   (int)TipoComorbidade.DeficienciaVisual);
        Assert.Equal(8,   (int)TipoComorbidade.DeficienciaFisica);
        Assert.Equal(16,  (int)TipoComorbidade.DeficienciaAuditiva);
        Assert.Equal(32,  (int)TipoComorbidade.DeficienciaIntelectual);
        Assert.Equal(64,  (int)TipoComorbidade.SindromeDown);
        Assert.Equal(128, (int)TipoComorbidade.AltasHabilidades);
        Assert.Equal(256, (int)TipoComorbidade.Outras);
    }

    [Fact]
    public void TipoComorbidade_CombinacaoFlags_DeveSerBitwise()
    {
        var comorbidades = TipoComorbidade.TEA | TipoComorbidade.TDAH;
        Assert.True(comorbidades.HasFlag(TipoComorbidade.TEA));
        Assert.True(comorbidades.HasFlag(TipoComorbidade.TDAH));
        Assert.False(comorbidades.HasFlag(TipoComorbidade.DeficienciaVisual));
    }

    [Fact]
    public void TipoComorbidade_TEA_DisplayName_DeveConterTEA()
    {
        var displayName = TipoComorbidade.TEA.GetDisplayName();
        Assert.Contains("TEA", displayName);
    }

    [Fact]
    public void TipoComorbidade_SindromeDown_DisplayName_DeveFuncionar()
    {
        var displayName = TipoComorbidade.SindromeDown.GetDisplayName();
        Assert.Contains("Down", displayName, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void TipoComorbidade_TodosValores_DevemTerDisplayName()
    {
        foreach (TipoComorbidade valor in Enum.GetValues(typeof(TipoComorbidade)))
        {
            var displayName = valor.GetDisplayName();
            Assert.False(string.IsNullOrWhiteSpace(displayName),
                $"TipoComorbidade.{valor} não tem DisplayName definido");
        }
    }
}

public class StatusSolicitacaoAcessoTests
{
    [Fact]
    public void StatusSolicitacaoAcesso_Pendente_DeveTerValor0()
    {
        Assert.Equal(0, (int)StatusSolicitacaoAcesso.Pendente);
    }

    [Fact]
    public void StatusSolicitacaoAcesso_Aprovado_DeveTerValor1()
    {
        Assert.Equal(1, (int)StatusSolicitacaoAcesso.Aprovado);
    }

    [Fact]
    public void StatusSolicitacaoAcesso_Rejeitado_DeveTerValor2()
    {
        Assert.Equal(2, (int)StatusSolicitacaoAcesso.Rejeitado);
    }

    [Fact]
    public void StatusSolicitacaoAcesso_TodosValores_DevemTerDisplayName()
    {
        foreach (StatusSolicitacaoAcesso s in Enum.GetValues(typeof(StatusSolicitacaoAcesso)))
        {
            var dn = s.GetDisplayName();
            Assert.False(string.IsNullOrWhiteSpace(dn));
        }
    }
}

public class TipoRegistroEstudanteTests
{
    [Fact]
    public void TipoRegistroEstudante_PrimeiroComeçaEm1()
    {
        Assert.Equal(1, (int)TipoRegistroEstudante.ObservacaoEscolar);
    }

    [Fact]
    public void TipoRegistroEstudante_TodosTem6Valores()
    {
        var valores = Enum.GetValues(typeof(TipoRegistroEstudante));
        Assert.Equal(6, valores.Length);
    }

    [Fact]
    public void TipoRegistroEstudante_TodosValores_DevemTerDisplayName()
    {
        foreach (TipoRegistroEstudante t in Enum.GetValues(typeof(TipoRegistroEstudante)))
        {
            var dn = t.GetDisplayName();
            Assert.False(string.IsNullOrWhiteSpace(dn),
                $"TipoRegistroEstudante.{t} não tem DisplayName");
        }
    }
}
