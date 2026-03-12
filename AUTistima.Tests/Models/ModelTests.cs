using AUTistima.Models;
using AUTistima.Models.Enums;
using Xunit;

namespace AUTistima.Tests.Models;

/// <summary>
/// Testa os modelos criados/alterados pelas adequações SEMED
/// </summary>
public class SolicitacaoAcessoPerfilTests
{
    [Fact]
    public void SolicitacaoAcessoPerfil_StatusDefault_DeveSer_Pendente()
    {
        var solicitacao = new SolicitacaoAcessoPerfil();
        Assert.Equal(StatusSolicitacaoAcesso.Pendente, solicitacao.Status);
    }

    [Fact]
    public void SolicitacaoAcessoPerfil_DataSolicitacao_NaoDeveSerDefault()
    {
        var antes = DateTime.UtcNow.AddSeconds(-1);
        var solicitacao = new SolicitacaoAcessoPerfil();
        Assert.True(solicitacao.DataSolicitacao >= antes,
            "DataSolicitacao deve ser inicializada como DateTime.UtcNow");
    }

    [Fact]
    public void SolicitacaoAcessoPerfil_DataDecisao_DeveSerNullaPorPadrao()
    {
        var solicitacao = new SolicitacaoAcessoPerfil();
        Assert.Null(solicitacao.DataDecisao);
    }

    [Fact]
    public void SolicitacaoAcessoPerfil_MotivoRejeicao_DeveSerNuloPorPadrao()
    {
        var solicitacao = new SolicitacaoAcessoPerfil();
        Assert.Null(solicitacao.MotivoRejeicao);
    }

    [Fact]
    public void SolicitacaoAcessoPerfil_AprovadoPorAdminId_DeveSerNuloPorPadrao()
    {
        var solicitacao = new SolicitacaoAcessoPerfil();
        Assert.Null(solicitacao.AprovadoPorAdminId);
    }

    [Fact]
    public void SolicitacaoAcessoPerfil_PodeTerStatusAprovado()
    {
        var solicitacao = new SolicitacaoAcessoPerfil
        {
            Status = StatusSolicitacaoAcesso.Aprovado,
            DataDecisao = DateTime.UtcNow
        };
        Assert.Equal(StatusSolicitacaoAcesso.Aprovado, solicitacao.Status);
        Assert.NotNull(solicitacao.DataDecisao);
    }

    [Fact]
    public void SolicitacaoAcessoPerfil_PodeTerStatusRejeitado_ComMotivo()
    {
        var solicitacao = new SolicitacaoAcessoPerfil
        {
            Status = StatusSolicitacaoAcesso.Rejeitado,
            MotivoRejeicao = "Documentação insuficiente",
            DataDecisao = DateTime.UtcNow
        };
        Assert.Equal(StatusSolicitacaoAcesso.Rejeitado, solicitacao.Status);
        Assert.Equal("Documentação insuficiente", solicitacao.MotivoRejeicao);
    }
}

public class RegistroEstudanteTests
{
    [Fact]
    public void RegistroEstudante_Ativo_DeveSer_TruePorPadrao()
    {
        var registro = new RegistroEstudante();
        Assert.True(registro.Ativo);
    }

    [Fact]
    public void RegistroEstudante_DataRegistro_NaoDeveSerDefault()
    {
        var antes = DateTime.UtcNow.AddSeconds(-1);
        var registro = new RegistroEstudante();
        Assert.True(registro.DataRegistro >= antes,
            "DataRegistro deve ser inicializado como DateTime.UtcNow");
    }

    [Fact]
    public void RegistroEstudante_PodeReceberTodosOsTipos()
    {
        foreach (TipoRegistroEstudante tipo in Enum.GetValues(typeof(TipoRegistroEstudante)))
        {
            var registro = new RegistroEstudante
            {
                TipoRegistro = tipo,
                Titulo = $"Teste {tipo}",
                Conteudo = "Conteúdo de teste"
            };
            Assert.Equal(tipo, registro.TipoRegistro);
        }
    }

    [Fact]
    public void RegistroEstudante_PodeSerInativado()
    {
        var registro = new RegistroEstudante { Ativo = false };
        Assert.False(registro.Ativo);
    }
}

public class ChildModelTests
{
    [Fact]
    public void Child_CodigoUnico_DeveAceitarFormatoALU()
    {
        var child = new Child
        {
            Nome = "Teste",
            UserId = "user-id",
            CodigoUnico = "ALU-2026-000001"
        };
        Assert.Equal("ALU-2026-000001", child.CodigoUnico);
    }

    [Fact]
    public void Child_CodigoUnico_PodeSerNulo()
    {
        var child = new Child { Nome = "Teste", UserId = "user-id" };
        Assert.Null(child.CodigoUnico);
    }

    [Fact]
    public void Child_Comorbidades_DefaultDeveSerNenhuma()
    {
        var child = new Child { Nome = "Teste", UserId = "user-id" };
        Assert.Equal(TipoComorbidade.Nenhuma, child.Comorbidades);
    }

    [Fact]
    public void Child_Comorbidades_PodeCombinarFlags()
    {
        var child = new Child
        {
            Nome = "Teste",
            UserId = "user-id",
            Comorbidades = TipoComorbidade.TEA | TipoComorbidade.TDAH
        };
        Assert.True(child.Comorbidades.HasFlag(TipoComorbidade.TEA));
        Assert.True(child.Comorbidades.HasFlag(TipoComorbidade.TDAH));
        Assert.False(child.Comorbidades.HasFlag(TipoComorbidade.SindromeDown));
    }

    [Fact]
    public void Child_OutrasCondicoes_PodeSerNulo()
    {
        var child = new Child { Nome = "Teste", UserId = "user-id" };
        Assert.Null(child.OutrasCondicoes);
    }

    [Fact]
    public void Child_CadastradoPorEscolaUserId_PodeSerNulo()
    {
        var child = new Child { Nome = "Teste", UserId = "user-id" };
        Assert.Null(child.CadastradoPorEscolaUserId);
    }

    [Fact]
    public void Child_CodigoUnico_DevePassarFormatoRegex()
    {
        // Valida o formato ALU-YYYY-NNNNNN
        var regex = new System.Text.RegularExpressions.Regex(@"^ALU-\d{4}-\d{6}$");
        Assert.Matches(regex, "ALU-2026-000001");
        Assert.Matches(regex, "ALU-2025-123456");
        Assert.DoesNotMatch(regex, "ALU-26-001");
        Assert.DoesNotMatch(regex, "EST-2026-000001");
    }
}

public class ApplicationUserTests
{
    [Fact]
    public void ApplicationUser_EscolaVinculadaId_PodeSerNulo()
    {
        var user = new ApplicationUser();
        Assert.Null(user.EscolaVinculadaId);
    }

    [Fact]
    public void ApplicationUser_EscolaVinculadaId_PodeReceberValorInteiro()
    {
        var user = new ApplicationUser { EscolaVinculadaId = 42 };
        Assert.Equal(42, user.EscolaVinculadaId);
    }
}
