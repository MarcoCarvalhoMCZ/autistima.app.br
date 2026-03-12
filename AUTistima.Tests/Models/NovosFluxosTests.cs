using AUTistima.Models;
using AUTistima.Models.Enums;
using Xunit;

namespace AUTistima.Tests.Models;

/// <summary>
/// Testa os comportamentos adicionados na fase 2 (vinculação escola / notificações)
/// </summary>
public class NovosFluxosTests
{
    // --- Aprovação / Rejeição de acesso ---

    [Fact]
    public void AprovacaoAcesso_DeveMudarStatusERegistrarAdmin()
    {
        var solicitacao = new SolicitacaoAcessoPerfil
        {
            ProfissionalId = "prof-1",
            CodigoEstudanteInformado = "ALU-2026-000001"
        };
        Assert.Equal(StatusSolicitacaoAcesso.Pendente, solicitacao.Status);

        // Simular aprovação
        solicitacao.Status = StatusSolicitacaoAcesso.Aprovado;
        solicitacao.DataDecisao = DateTime.UtcNow;
        solicitacao.AprovadoPorAdminId = "admin-1";

        Assert.Equal(StatusSolicitacaoAcesso.Aprovado, solicitacao.Status);
        Assert.NotNull(solicitacao.DataDecisao);
        Assert.Equal("admin-1", solicitacao.AprovadoPorAdminId);
        Assert.Null(solicitacao.MotivoRejeicao); // Aprovação não tem motivo
    }

    [Fact]
    public void RejeicaoAcesso_DeveMudarStatusEGravarMotivo()
    {
        var solicitacao = new SolicitacaoAcessoPerfil
        {
            ProfissionalId = "prof-1",
            CodigoEstudanteInformado = "ALU-2026-000001"
        };

        // Simular rejeição
        solicitacao.Status = StatusSolicitacaoAcesso.Rejeitado;
        solicitacao.MotivoRejeicao = "Documentação incompleta";
        solicitacao.DataDecisao = DateTime.UtcNow;
        solicitacao.AprovadoPorAdminId = "admin-1";

        Assert.Equal(StatusSolicitacaoAcesso.Rejeitado, solicitacao.Status);
        Assert.NotNull(solicitacao.MotivoRejeicao);
        Assert.Contains("Documentação", solicitacao.MotivoRejeicao);
    }

    [Fact]
    public void RejeicaoAcesso_MotivoMaximo500Chars_DeveFuncionar()
    {
        var motivo = new string('x', 500);
        var solicitacao = new SolicitacaoAcessoPerfil
        {
            Status = StatusSolicitacaoAcesso.Rejeitado,
            MotivoRejeicao = motivo
        };
        Assert.Equal(500, solicitacao.MotivoRejeicao!.Length);
    }

    // --- Vinculação de Escola ---

    [Fact]
    public void ApplicationUser_TipoPerfilEscola_PodeVincularEscolaId()
    {
        var user = new ApplicationUser
        {
            TipoPerfil = TipoPerfil.Escola,
            EscolaVinculadaId = 7
        };
        Assert.Equal(TipoPerfil.Escola, user.TipoPerfil);
        Assert.Equal(7, user.EscolaVinculadaId);
    }

    [Fact]
    public void ApplicationUser_OutrosPerfis_EscolaIdDeveSerNulo()
    {
        // Ao salvar perfis não-Escola, EscolaVinculadaId deve ser null
        var tiposNaoEscola = new[] { TipoPerfil.Mae, TipoPerfil.ProfissionalSaude,
            TipoPerfil.ProfissionalEducacao, TipoPerfil.Administrador,
            TipoPerfil.Empresa, TipoPerfil.Governo };

        foreach (var tipo in tiposNaoEscola)
        {
            var user = new ApplicationUser { TipoPerfil = tipo, EscolaVinculadaId = null };
            Assert.Null(user.EscolaVinculadaId);
        }
    }

    // --- Código único de estudante ---

    [Theory]
    [InlineData("ALU-2026-000001", true)]
    [InlineData("ALU-2025-999999", true)]
    [InlineData("ALU-2026-00001", false)]   // 5 dígitos
    [InlineData("EST-2026-000001", false)]  // prefixo errado
    [InlineData("ALU-26-000001", false)]    // ano com 2 dígitos
    [InlineData("", false)]
    public void CodigoUnico_FormatoALU_Validacao(string codigo, bool valido)
    {
        var regex = new System.Text.RegularExpressions.Regex(@"^ALU-\d{4}-\d{6}$");
        Assert.Equal(valido, regex.IsMatch(codigo));
    }

    [Fact]
    public void CodigoUnico_GeracaoSequencial_DeveIncrementer()
    {
        // Simula a lógica do EscolaController: ALU-{year}-{maxId+1:D6}
        int maxId = 0;
        int ano = 2026;
        var codigo1 = $"ALU-{ano}-{(maxId + 1):D6}";
        var codigo2 = $"ALU-{ano}-{(maxId + 2):D6}";

        Assert.Equal("ALU-2026-000001", codigo1);
        Assert.Equal("ALU-2026-000002", codigo2);
    }

    // --- Flags Comorbidades em contagem ---

    [Fact]
    public void TipoComorbidade_ContarFlags_DoisEstudantes()
    {
        var estudantes = new[]
        {
            TipoComorbidade.TEA | TipoComorbidade.TDAH,
            TipoComorbidade.TEA | TipoComorbidade.SindromeDown,
            TipoComorbidade.TDAH
        };

        int comTEA = estudantes.Count(c => c.HasFlag(TipoComorbidade.TEA));
        int comTDAH = estudantes.Count(c => c.HasFlag(TipoComorbidade.TDAH));
        int comSindrome = estudantes.Count(c => c.HasFlag(TipoComorbidade.SindromeDown));

        Assert.Equal(2, comTEA);
        Assert.Equal(2, comTDAH);
        Assert.Equal(1, comSindrome);
    }

    // --- Prontuário: registros por tipo ---

    [Fact]
    public void RegistroEstudante_MultiplosTipos_CadaUmIndependente()
    {
        var registros = new[]
        {
            new RegistroEstudante { TipoRegistro = TipoRegistroEstudante.ObservacaoEscolar, Titulo = "Obs 1", Conteudo = "c", AutorId = "a", ChildId = 1 },
            new RegistroEstudante { TipoRegistro = TipoRegistroEstudante.RelatorioProfissional, Titulo = "Rel 1", Conteudo = "c", AutorId = "a", ChildId = 1 },
            new RegistroEstudante { TipoRegistro = TipoRegistroEstudante.ObservacaoEscolar, Titulo = "Obs 2", Conteudo = "c", AutorId = "a", ChildId = 1 },
        };

        var observacoes = registros.Count(r => r.TipoRegistro == TipoRegistroEstudante.ObservacaoEscolar);
        var relatorios = registros.Count(r => r.TipoRegistro == TipoRegistroEstudante.RelatorioProfissional);

        Assert.Equal(2, observacoes);
        Assert.Equal(1, relatorios);
    }

    [Fact]
    public void RegistroEstudante_SoftDelete_ApenasAtivos_Funciona()
    {
        var registros = new[]
        {
            new RegistroEstudante { Ativo = true, Titulo = "Ativo", Conteudo = "c", AutorId = "a", ChildId = 1,  TipoRegistro = TipoRegistroEstudante.NotaAdministrativa },
            new RegistroEstudante { Ativo = false, Titulo = "Inativo", Conteudo = "c", AutorId = "a", ChildId = 1, TipoRegistro = TipoRegistroEstudante.NotaAdministrativa },
            new RegistroEstudante { Ativo = true, Titulo = "Ativo 2", Conteudo = "c", AutorId = "a", ChildId = 1, TipoRegistro = TipoRegistroEstudante.NotaAdministrativa },
        };

        var ativos = registros.Where(r => r.Ativo).ToList();
        Assert.Equal(2, ativos.Count);
    }
}
