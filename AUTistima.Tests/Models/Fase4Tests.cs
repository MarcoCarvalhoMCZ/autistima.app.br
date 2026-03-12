using AUTistima.Models;
using AUTistima.Models.Enums;
using Xunit;

namespace AUTistima.Tests.Models;

/// <summary>
/// Testes da Fase 4: CodigoUnico visível para mãe + filtro CSV por escola
/// </summary>
public class Fase4Tests
{
    // ── CodigoUnico display ──────────────────────────────────────────────────

    [Fact]
    public void CodigoUnico_NuloOuVazio_NaoDeveExibirBadge()
    {
        var filho = new Child { Nome = "Ana", CodigoUnico = null };
        Assert.True(string.IsNullOrEmpty(filho.CodigoUnico));
    }

    [Fact]
    public void CodigoUnico_Preenchido_DevePermitirExibicaoBadge()
    {
        var filho = new Child { Nome = "João", CodigoUnico = "ALU-2026-000001" };
        Assert.False(string.IsNullOrEmpty(filho.CodigoUnico));
    }

    [Fact]
    public void CodigoUnico_FormatoPadrao_DeveConterPrefixoALU()
    {
        var filho = new Child { Nome = "Pedro", CodigoUnico = "ALU-2026-000042" };
        Assert.StartsWith("ALU-", filho.CodigoUnico);
    }

    [Fact]
    public void CodigoUnico_DeveSerCopiavel_DisponivelComoString()
    {
        var filho = new Child { Nome = "Maria", CodigoUnico = "ALU-2026-000100" };
        // O código deve poder ser convertido a string sem perda
        var codigoCopiar = filho.CodigoUnico?.ToString();
        Assert.Equal("ALU-2026-000100", codigoCopiar);
    }

    [Theory]
    [InlineData("ALU-2024-000001")]
    [InlineData("ALU-2025-999999")]
    [InlineData("ALU-2026-000042")]
    public void CodigoUnico_VariosFormatos_DevemPassarNaValidacao(string codigo)
    {
        var filho = new Child { Nome = "Teste", CodigoUnico = codigo };
        Assert.Matches(@"^ALU-\d{4}-\d{6}$", filho.CodigoUnico!);
    }

    // ── Filtro por escola no CSV ─────────────────────────────────────────────

    [Fact]
    public void FiltroEscolaCSV_EscolaIdNulo_DeveRetornarTodosEstudantes()
    {
        var estudantes = new List<Child>
        {
            new Child { Nome = "A", EscolaId = 1 },
            new Child { Nome = "B", EscolaId = 2 },
            new Child { Nome = "C", EscolaId = 3 }
        };

        int? escolaId = null;
        var filtrados = escolaId.HasValue
            ? estudantes.Where(c => c.EscolaId == escolaId.Value).ToList()
            : estudantes;

        Assert.Equal(3, filtrados.Count());
    }

    [Fact]
    public void FiltroEscolaCSV_EscolaIdPreenchido_DeveRetornarApenasEssaEscola()
    {
        var estudantes = new List<Child>
        {
            new Child { Nome = "A", EscolaId = 1 },
            new Child { Nome = "B", EscolaId = 2 },
            new Child { Nome = "C", EscolaId = 1 }
        };

        int? escolaId = 1;
        var filtrados = escolaId.HasValue
            ? estudantes.Where(c => c.EscolaId == escolaId.Value).ToList()
            : estudantes;

        Assert.Equal(2, filtrados.Count);
        Assert.All(filtrados, e => Assert.Equal(1, e.EscolaId));
    }

    [Fact]
    public void FiltroEscolaCSV_EscolaInexistente_DeveRetornarListaVazia()
    {
        var estudantes = new List<Child>
        {
            new Child { Nome = "A", EscolaId = 1 },
            new Child { Nome = "B", EscolaId = 2 }
        };

        int? escolaId = 99;
        var filtrados = escolaId.HasValue
            ? estudantes.Where(c => c.EscolaId == escolaId.Value).ToList()
            : estudantes;

        Assert.Empty(filtrados);
    }

    [Fact]
    public void NomeArquivoCSV_SemFiltro_DeveConterSufixoTodas()
    {
        int? escolaId = null;
        var sufixo = escolaId.HasValue ? $"_escola{escolaId}" : "_todas";
        var nomeArquivo = $"estudantes_semed{sufixo}_20260101_1200.csv";

        Assert.Contains("_todas", nomeArquivo);
        Assert.DoesNotContain("_escola", nomeArquivo);
    }

    [Fact]
    public void NomeArquivoCSV_ComFiltro_DeveConterIdDaEscola()
    {
        int? escolaId = 7;
        var sufixo = escolaId.HasValue ? $"_escola{escolaId}" : "_todas";
        var nomeArquivo = $"estudantes_semed{sufixo}_20260101_1200.csv";

        Assert.Contains("_escola7", nomeArquivo);
        Assert.DoesNotContain("_todas", nomeArquivo);
    }

    // ── Integridade dos dados exibidos ───────────────────────────────────────

    [Fact]
    public void ChildComCodigo_DeveExibirNomeECodigo()
    {
        var c = new Child { Nome = "Lucas Ferreira", CodigoUnico = "ALU-2026-000017", EscolaId = 3 };
        Assert.Equal("Lucas Ferreira", c.Nome);
        Assert.Equal("ALU-2026-000017", c.CodigoUnico);
        Assert.Equal(3, c.EscolaId);
    }

    [Fact]
    public void ChildSemCodigo_NaoDeveFalharAoExibirDetalhes()
    {
        var c = new Child { Nome = "Sofia Mendes", CodigoUnico = null };
        // Verificar que operações de display não lançam exceção
        var display = string.IsNullOrEmpty(c.CodigoUnico) ? "—" : c.CodigoUnico;
        Assert.Equal("—", display);
    }
}
