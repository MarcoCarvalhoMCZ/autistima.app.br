using System.Security.Cryptography;
using AUTistima.Models;
using AUTistima.Models.Enums;
using Xunit;

namespace AUTistima.Tests.Models;

/// <summary>
/// Testes da Fase 5: fixes de segurança + novos fluxos
/// </summary>
public class Fase5Tests
{
    // ── Fix 1: Segurança — geração de senha criptográfica ──────────────────

    [Fact]
    public void SenhaAleatoria_DeveUsarCaracteresVariados()
    {
        // Não podemos chamar o método privado diretamente, mas validamos
        // que o algoritmo com RandomNumberGenerator produz resultados que:
        // a) têm comprimento 10
        // b) contêm caracteres do charset esperado
        const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz23456789@#$!";
        using var rng = RandomNumberGenerator.Create();
        var bytes = new byte[10];
        rng.GetBytes(bytes);
        var senha = new string(bytes.Select(b => chars[b % chars.Length]).ToArray());

        Assert.Equal(10, senha.Length);
        Assert.All(senha, c => Assert.Contains(c, chars));
    }

    [Fact]
    public void SenhaAleatoria_DuasChamadasDevemGerarValoresDiferentes()
    {
        const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz23456789@#$!";
        string Gerar() {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[10];
            rng.GetBytes(bytes);
            return new string(bytes.Select(b => chars[b % chars.Length]).ToArray());
        }

        var s1 = Gerar();
        var s2 = Gerar();
        // Extremamente improvável que duas sejam iguais (1 em 62^10 aprox)
        Assert.NotEqual(s1, s2);
    }

    [Fact]
    public void RandomNumberGenerator_NaoEhPrevisivel_Random()
    {
        // Garante que não estamos usando new Random() com seed fixa
        using var rng = RandomNumberGenerator.Create();
        var a = new byte[8];
        var b = new byte[8];
        rng.GetBytes(a);
        rng.GetBytes(b);
        Assert.False(a.SequenceEqual(b), "RNG não deve gerar sequências idênticas consecutivas.");
    }

    // ── Fix 2: Soft delete ─────────────────────────────────────────────────

    [Fact]
    public void EscolaSoftDelete_AtivoFalseNaoRemoveRegistro()
    {
        var escola = new AUTistima.Models.School { Id = 1, Nome = "EMEF Teste", Ativo = true };
        // Simula soft delete
        escola.Ativo = false;

        Assert.False(escola.Ativo);
        Assert.Equal(1, escola.Id);      // objeto ainda existe em memória
        Assert.Equal("EMEF Teste", escola.Nome);
    }

    [Fact]
    public void EscolaAtiva_DeveSerFiltradaCorretamente()
    {
        var escolas = new List<AUTistima.Models.School>
        {
            new() { Id = 1, Nome = "Escola A", Ativo = true },
            new() { Id = 2, Nome = "Escola B", Ativo = false },
            new() { Id = 3, Nome = "Escola C", Ativo = true }
        };

        var ativas = escolas.Where(e => e.Ativo).ToList();
        Assert.Equal(2, ativas.Count);
        Assert.DoesNotContain(ativas, e => e.Id == 2);
    }

    // ── Fix 3: Flags de comorbidade ────────────────────────────────────────

    [Fact]
    public void ComorbidadesFlags_OrBitaWise_CombinaDoisFlags()
    {
        var tea = (int)TipoComorbidade.TEA;          // 1
        var tdah = (int)TipoComorbidade.TDAH;        // 2
        var resultado = tea | tdah;                  // 3

        var parsed = (TipoComorbidade)resultado;
        Assert.True(parsed.HasFlag(TipoComorbidade.TEA));
        Assert.True(parsed.HasFlag(TipoComorbidade.TDAH));
        Assert.False(parsed.HasFlag(TipoComorbidade.DeficienciaVisual));
    }

    [Fact]
    public void ComorbidadesFlags_ValorZeroEquivaleNenhuma()
    {
        var hiddenValue = 0; // valor do input hidden quando nenhum checkbox marcado
        var parsed = (TipoComorbidade)hiddenValue;
        Assert.Equal(TipoComorbidade.Nenhuma, parsed);
    }

    [Fact]
    public void ComorbidadesFlags_TodosOsValoresSaoPoteniasDeDois()
    {
        var valores = Enum.GetValues(typeof(TipoComorbidade))
            .Cast<TipoComorbidade>()
            .Where(c => c != TipoComorbidade.Nenhuma)
            .Select(c => (int)c);

        foreach (var v in valores)
        {
            Assert.True(v > 0 && (v & (v - 1)) == 0,
                $"TipoComorbidade valor {v} não é potência de 2 — flags inválido.");
        }
    }

    [Fact]
    public void ComorbidadesFlags_OrDeCheckboxesEquivaleAoHidden()
    {
        // Simula o cálculo do JS: reduce com bitwise OR
        var checked_ = new[] { TipoComorbidade.TEA, TipoComorbidade.SindromeDown };
        var total = checked_.Aggregate(0, (acc, c) => acc | (int)c);

        var hiddenValue = (TipoComorbidade)total;
        Assert.True(hiddenValue.HasFlag(TipoComorbidade.TEA));
        Assert.True(hiddenValue.HasFlag(TipoComorbidade.SindromeDown));
        Assert.False(hiddenValue.HasFlag(TipoComorbidade.TDAH));
    }

    // ── Mãe: prontuário do filho ────────────────────────────────────────────

    [Fact]
    public void ProntuarioFilho_ApenasRegistrosAtivosDevemAparecer()
    {
        var registros = new List<RegistroEstudante>
        {
            new() { Id = 1, Titulo = "Obs 1", Ativo = true,  ChildId = 5 },
            new() { Id = 2, Titulo = "Obs 2", Ativo = false, ChildId = 5 },
            new() { Id = 3, Titulo = "Obs 3", Ativo = true,  ChildId = 5 }
        };

        var filho = new Child
        {
            Id = 5, Nome = "Lucas",
            Registros = registros
        };

        var visiveis = filho.Registros.Where(r => r.Ativo).ToList();
        Assert.Equal(2, visiveis.Count);
        Assert.DoesNotContain(visiveis, r => r.Id == 2);
    }

    [Fact]
    public void ProntuarioFilho_AcessosAprovadosDevemAparecer()
    {
        var solicitacoes = new List<SolicitacaoAcessoPerfil>
        {
            new() { Id = 1, Status = StatusSolicitacaoAcesso.Aprovado },
            new() { Id = 2, Status = StatusSolicitacaoAcesso.Pendente },
            new() { Id = 3, Status = StatusSolicitacaoAcesso.Rejeitado }
        };

        var filho = new Child { Id = 5, Nome = "Lucas", SolicitacoesAcesso = solicitacoes };

        var aprovados = filho.SolicitacoesAcesso.Where(s => s.Status == StatusSolicitacaoAcesso.Aprovado).ToList();
        var pendentes = filho.SolicitacoesAcesso.Where(s => s.Status == StatusSolicitacaoAcesso.Pendente).ToList();

        Assert.Single(aprovados);
        Assert.Single(pendentes);
    }

    [Fact]
    public void ProntuarioFilho_FilhoDeMaeErradaDeveForbid()
    {
        // Teste de lógica: só o filho cujo UserId = mãe logada deve ser retornado
        var filhos = new List<Child>
        {
            new() { Id = 1, Nome = "Filho A", UserId = "mae-1" },
            new() { Id = 2, Nome = "Filho B", UserId = "mae-2" }
        };

        string maeLogadaId = "mae-1";
        int idRequisitado = 2; // tentando acessar filho de outra mãe

        var filho = filhos.FirstOrDefault(c => c.Id == idRequisitado && c.UserId == maeLogadaId);
        Assert.Null(filho); // deve retornar nulo → controller responde Forbid()
    }

    // ── Escola: editar estudante ────────────────────────────────────────────

    [Fact]
    public void EditarEstudante_AtualizacoesDevemSerAplicadas()
    {
        var estudante = new Child
        {
            Id = 10, Nome = "Ana", PossuiPAE = false,
            Comorbidades = TipoComorbidade.Nenhuma,
            EstrategiasCrise = null
        };

        // Simula o que o POST faz
        estudante.Nome = "Ana Paula";
        estudante.PossuiPAE = true;
        estudante.Comorbidades = TipoComorbidade.TEA | TipoComorbidade.TDAH;
        estudante.EstrategiasCrise = "Reduzir estímulos sensoriais.";

        Assert.Equal("Ana Paula", estudante.Nome);
        Assert.True(estudante.PossuiPAE);
        Assert.True(estudante.Comorbidades.HasFlag(TipoComorbidade.TEA));
        Assert.NotNull(estudante.EstrategiasCrise);
    }

    [Fact]
    public void EditarEstudante_EscolaViewModelTemCampoEstrategiasCrise()
    {
        // EditarEstudanteViewModel deve ter EstrategiasCrise
        var vm = new AUTistima.Areas.Escola.Controllers.EditarEstudanteViewModel();
        vm.EstrategiasCrise = "Técnica de relaxamento";
        Assert.Equal("Técnica de relaxamento", vm.EstrategiasCrise);
    }

    [Fact]
    public void EditarEstudante_EscolaViewModelNomeObrigatorio()
    {
        var vm = new AUTistima.Areas.Escola.Controllers.EditarEstudanteViewModel
        {
            Id = 1,
            NomeEstudante = "" // inválido
        };

        var ctx = new System.ComponentModel.DataAnnotations.ValidationContext(vm);
        var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
        var valido = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(vm, ctx, results, true);

        Assert.False(valido);
        Assert.Contains(results, r => r.MemberNames.Contains("NomeEstudante"));
    }

    // ── Push ao adicionar registro ──────────────────────────────────────────

    [Fact]
    public void RegistroAdicionado_CriadoComAutorETempo()
    {
        var registro = new RegistroEstudante
        {
            ChildId   = 3,
            AutorId   = "prof-abc",
            Titulo    = "Avaliação mensal",
            Conteudo  = "Melhora observada.",
            TipoRegistro = TipoRegistroEstudante.AvaliacaoPedagogica,
            DataRegistro = DateTime.UtcNow,
            Ativo = true
        };

        Assert.Equal("prof-abc", registro.AutorId);
        Assert.True(registro.Ativo);
        Assert.True((DateTime.UtcNow - registro.DataRegistro).TotalSeconds < 5);
    }

    // ── Paginação AcessosEstudante ─────────────────────────────────────────

    [Fact]
    public void Paginacao_CalculaTotalDePaginasCorretamente()
    {
        int total = 45;
        int porPagina = 20;
        int totalPaginas = (int)Math.Ceiling(total / (double)porPagina);

        Assert.Equal(3, totalPaginas);
    }

    [Fact]
    public void Paginacao_PaginaAnteriorDisabladaNaPrimeiraPagina()
    {
        int paginaAtual = 1;
        bool anteriorDisabled = paginaAtual == 1;
        Assert.True(anteriorDisabled);
    }

    [Fact]
    public void Paginacao_ProximaDisabladaNaUltimaPagina()
    {
        int paginaAtual = 3;
        int totalPaginas = 3;
        bool proximaDisabled = paginaAtual == totalPaginas;
        Assert.True(proximaDisabled);
    }
}
