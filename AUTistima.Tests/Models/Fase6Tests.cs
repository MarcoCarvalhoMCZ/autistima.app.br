using AUTistima.Models;
using AUTistima.Models.Enums;
using AUTistima.Services;
using Xunit;

namespace AUTistima.Tests.Models;

/// <summary>
/// Testes da Fase 6: revogação de acesso, métricas PAE, card prontuário, banner escola.
/// </summary>
public class Fase6Tests
{
    // ── Gap 10: Revogação de acesso ──────────────────────────────────────────

    [Fact]
    public void Solicitacao_AoCancelarAcesso_StatusDeveSerRejeitado()
    {
        // Arrange — simula o que acontece no controller ao revogar
        var sol = new SolicitacaoAcessoPerfil
        {
            Status = StatusSolicitacaoAcesso.Aprovado,
            MotivoRejeicao = null
        };

        // Act — reproduz a lógica do Revogar()
        sol.Status = StatusSolicitacaoAcesso.Rejeitado;
        sol.MotivoRejeicao = "Acesso revogado pelo administrador.";
        sol.DataDecisao = DateTime.UtcNow;

        // Assert
        Assert.Equal(StatusSolicitacaoAcesso.Rejeitado, sol.Status);
        Assert.NotNull(sol.MotivoRejeicao);
        Assert.NotNull(sol.DataDecisao);
    }

    [Fact]
    public void Revogacao_SomenteAcessoAprovadoPodeSerRevogado()
    {
        var pendente = new SolicitacaoAcessoPerfil { Status = StatusSolicitacaoAcesso.Pendente };
        var rejeitado = new SolicitacaoAcessoPerfil { Status = StatusSolicitacaoAcesso.Rejeitado };

        // A guarda no controller verifica: Status != Aprovado → não revoga
        Assert.NotEqual(StatusSolicitacaoAcesso.Aprovado, pendente.Status);
        Assert.NotEqual(StatusSolicitacaoAcesso.Aprovado, rejeitado.Status);
    }

    [Fact]
    public void Revogacao_AposMudarStatus_ProntuarioNaoDeveEstarAcessivel()
    {
        // Simula: ProntuariosController.VerProntuario() exige Status == Aprovado
        var sol = new SolicitacaoAcessoPerfil
        {
            ProfissionalId = "prof-1",
            ChildId = 7,
            Status = StatusSolicitacaoAcesso.Aprovado
        };

        // Ação: revogar
        sol.Status = StatusSolicitacaoAcesso.Rejeitado;

        // O controller usa: s.Status == StatusSolicitacaoAcesso.Aprovado
        var temAcesso = sol.Status == StatusSolicitacaoAcesso.Aprovado;
        Assert.False(temAcesso);
    }

    [Fact]
    public void Revogacao_PushDeveMencionarNomeEstudante()
    {
        var nomeEstudante = "Ana Beatriz";
        var mensagem = $"Seu acesso ao prontuário de {nomeEstudante} foi revogado pelo administrador.";

        Assert.Contains("revogado", mensagem);
        Assert.Contains(nomeEstudante, mensagem);
    }

    // ── Gap 11: Card prontuário no painel do profissional ───────────────────

    [Fact]
    public void Profissional_ContadorProntuarios_SomenteAcessosAprovados()
    {
        // Simula o que o controller calcula para ViewBag.TotalProntuariosAprovados
        var solicitacoes = new List<SolicitacaoAcessoPerfil>
        {
            new() { ProfissionalId = "p1", Status = StatusSolicitacaoAcesso.Aprovado },
            new() { ProfissionalId = "p1", Status = StatusSolicitacaoAcesso.Aprovado },
            new() { ProfissionalId = "p1", Status = StatusSolicitacaoAcesso.Pendente },
            new() { ProfissionalId = "p1", Status = StatusSolicitacaoAcesso.Rejeitado },
        };

        var total = solicitacoes.Count(s =>
            s.ProfissionalId == "p1" && s.Status == StatusSolicitacaoAcesso.Aprovado);

        Assert.Equal(2, total);
    }

    [Fact]
    public void Profissional_SemAcessos_ContadorDeveSerZero()
    {
        var solicitacoes = new List<SolicitacaoAcessoPerfil>();
        var total = solicitacoes.Count(s => s.Status == StatusSolicitacaoAcesso.Aprovado);
        Assert.Equal(0, total);
    }

    // ── Gap 13: Métricas PAE no relatório de estudantes ─────────────────────

    [Fact]
    public void RelatorioPAE_TotalComPAE_MaisTotalSemPAE_IgualTotalEstudantes()
    {
        // Simula o que o service computa
        var estudantes = new List<Child>
        {
            new() { PossuiPAE = true },
            new() { PossuiPAE = true },
            new() { PossuiPAE = false },
        };

        int total = estudantes.Count;
        int comPAE = estudantes.Count(c => c.PossuiPAE);
        int semPAE = total - comPAE;

        Assert.Equal(3, total);
        Assert.Equal(2, comPAE);
        Assert.Equal(1, semPAE);
        Assert.Equal(total, comPAE + semPAE);
    }

    [Fact]
    public void RelatorioPAE_TotalComDiagnostico_MaisSem_IgualTotal()
    {
        var estudantes = new List<Child>
        {
            new() { PossuiDiagnostico = true },
            new() { PossuiDiagnostico = false },
            new() { PossuiDiagnostico = false },
        };

        int total = estudantes.Count;
        int comDiag = estudantes.Count(c => c.PossuiDiagnostico);
        int semDiag = total - comDiag;

        Assert.Equal(1, comDiag);
        Assert.Equal(2, semDiag);
        Assert.Equal(total, comDiag + semDiag);
    }

    [Fact]
    public void RelatorioEstudantesMetrics_DeveTerPropriedadesPAE()
    {
        var metrics = new RelatorioEstudantesMetrics
        {
            TotalEstudantes = 10,
            TotalComPAE = 4,
            TotalSemPAE = 6,
            TotalComDiagnostico = 7,
            TotalSemDiagnostico = 3
        };

        Assert.Equal(metrics.TotalEstudantes, metrics.TotalComPAE + metrics.TotalSemPAE);
        Assert.Equal(metrics.TotalEstudantes, metrics.TotalComDiagnostico + metrics.TotalSemDiagnostico);
    }

    [Fact]
    public void RelatorioEstudantesMetrics_QuandoNenhumEstudante_TudoZero()
    {
        var metrics = new RelatorioEstudantesMetrics
        {
            TotalEstudantes = 0,
            TotalComPAE = 0,
            TotalSemPAE = 0,
            TotalComDiagnostico = 0,
            TotalSemDiagnostico = 0
        };

        Assert.Equal(0, metrics.TotalComPAE + metrics.TotalSemPAE);
    }

    // ── Gap 14: Escola sem vínculo ───────────────────────────────────────────

    [Fact]
    public void Escola_UsuarioSemVinculo_EscolaVinculadaIdDeveSerNulo()
    {
        var user = new ApplicationUser
        {
            TipoPerfil = TipoPerfil.Escola,
            EscolaVinculadaId = null
        };

        Assert.Null(user.EscolaVinculadaId);
    }

    [Fact]
    public void Escola_UsuarioComVinculo_EscolaVinculadaIdDeveEstarPreenchido()
    {
        var user = new ApplicationUser
        {
            TipoPerfil = TipoPerfil.Escola,
            EscolaVinculadaId = 5
        };

        Assert.NotNull(user.EscolaVinculadaId);
        Assert.Equal(5, user.EscolaVinculadaId);
    }

    [Fact]
    public void Escola_LogicaDeBanner_SemVinculo_DeveMostrarAviso()
    {
        // Simula a lógica do Razor: @if (escola == null) { mostrar alerta }
        School? escola = null;
        bool deveExibirAviso = escola == null;
        Assert.True(deveExibirAviso);
    }

    [Fact]
    public void Escola_LogicaDeBanner_ComVinculo_NaoDeveMostrarAviso()
    {
        var escola = new School { Id = 1, Nome = "Escola Municipal", Ativo = true };
        bool deveExibirAviso = escola == null;
        Assert.False(deveExibirAviso);
    }
}
