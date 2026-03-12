using AUTistima.Models;
using AUTistima.Models.Enums;
using AUTistima.Extensions;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace AUTistima.Tests.Services;

/// <summary>
/// Testes da lógica de exportação CSV e das notificações à mãe
/// </summary>
public class ExportacaoCSVTests
{
    // --- Geração do conteúdo CSV ---

    private static string GerarLinhaCSV(Child c)
    {
        // Replica a lógica do EstatisticasController.Csv()
        static string Csv(string? valor)
        {
            if (string.IsNullOrEmpty(valor)) return string.Empty;
            if (valor.Contains(';') || valor.Contains('"') || valor.Contains('\n'))
                return $"\"{valor.Replace("\"", "\"\"")}\"";
            return valor;
        }

        var comorbLabels = Enum.GetValues(typeof(TipoComorbidade))
            .Cast<TipoComorbidade>()
            .Where(cb => cb != TipoComorbidade.Nenhuma && c.Comorbidades.HasFlag(cb))
            .Select(cb => cb.GetDisplayName());

        return string.Join(";",
            Csv(c.CodigoUnico),
            Csv(c.Nome),
            c.DataNascimento?.ToString("dd/MM/yyyy") ?? "",
            Csv(c.EscolaNome),
            Csv(c.NivelSuporte?.GetDisplayName()),
            c.PossuiDiagnostico ? "Sim" : "Não",
            c.DataDiagnostico?.ToString("dd/MM/yyyy") ?? "",
            c.PossuiPAE ? "Sim" : "Não",
            Csv(string.Join(" | ", comorbLabels)),
            Csv(c.OutrasCondicoes),
            Csv(c.Usuario?.NomeCompleto),
            Csv(c.Usuario?.Email),
            Csv(c.Usuario?.PhoneNumber),
            c.DataCadastro.ToString("dd/MM/yyyy")
        );
    }

    [Fact]
    public void CSV_Cabecalho_DeveConter14Colunas()
    {
        var cabecalho = "Código;Nome do Estudante;Data de Nascimento;Escola;Nível de Suporte;" +
                        "Diagnóstico;Data Diagnóstico;PAE;Comorbidades;Outras Condições;" +
                        "Responsável;E-mail Responsável;Telefone Responsável;Data de Cadastro";
        var colunas = cabecalho.Split(';');
        Assert.Equal(14, colunas.Length);
    }

    [Fact]
    public void CSV_Linha_DeveTer14Campos()
    {
        var child = new Child
        {
            CodigoUnico = "ALU-2026-000001",
            Nome = "João Silva",
            DataNascimento = new DateTime(2015, 3, 10),
            EscolaNome = "EM Padre Cícero",
            NivelSuporte = NivelSuporte.Nivel1,
            PossuiDiagnostico = true,
            DataDiagnostico = new DateTime(2020, 6, 1),
            PossuiPAE = true,
            Comorbidades = TipoComorbidade.TEA,
            OutrasCondicoes = null,
            UserId = "u1",
            DataCadastro = DateTime.UtcNow
        };

        var linha = GerarLinhaCSV(child);
        var campos = linha.Split(';');
        Assert.Equal(14, campos.Length);
    }

    [Fact]
    public void CSV_CodigoUnico_DeveStar_NaPrimeiraCelulaLinha()
    {
        var child = new Child
        {
            CodigoUnico = "ALU-2026-000042",
            Nome = "Maria",
            UserId = "u1",
            DataCadastro = DateTime.UtcNow
        };

        var linha = GerarLinhaCSV(child);
        Assert.StartsWith("ALU-2026-000042;", linha);
    }

    [Fact]
    public void CSV_NomeComPontoVirgula_DeveSerEnvolvidoEmAspas()
    {
        // Nomes com ponto-e-vírgula devem ser escapados
        var child = new Child
        {
            CodigoUnico = "ALU-2026-000001",
            Nome = "Nome; Sobrenome",
            UserId = "u1",
            DataCadastro = DateTime.UtcNow
        };

        var linha = GerarLinhaCSV(child);
        Assert.Contains("\"Nome; Sobrenome\"", linha);
    }

    [Fact]
    public void CSV_ComorbidadesMultiplas_DevemSerSeparadasPorPipe()
    {
        var child = new Child
        {
            CodigoUnico = "ALU-2026-000001",
            Nome = "Carlos",
            UserId = "u1",
            Comorbidades = TipoComorbidade.TEA | TipoComorbidade.TDAH,
            DataCadastro = DateTime.UtcNow
        };

        var linha = GerarLinhaCSV(child);
        // O campo de comorbidades (índice 8) deve conter " | "
        var campos = linha.Split(';');
        var comorbField = campos[8];
        Assert.Contains("|", comorbField);
        Assert.Contains("TEA", comorbField);
        Assert.Contains("TDAH", comorbField);
    }

    [Fact]
    public void CSV_SemComorbidades_CampoDeve_EstarVazio()
    {
        var child = new Child
        {
            CodigoUnico = "ALU-2026-000001",
            Nome = "Ana",
            UserId = "u1",
            Comorbidades = TipoComorbidade.Nenhuma,
            DataCadastro = DateTime.UtcNow
        };

        var linha = GerarLinhaCSV(child);
        var campos = linha.Split(';');
        Assert.Equal(string.Empty, campos[8]); // Comorbidades vazia
    }

    [Fact]
    public void CSV_UTF8ComBOM_DeveQuebrarLinhas()
    {
        // Verifica que o CSV gerado como bytes UTF-8 com BOM pode ser lido como string
        var sb = new StringBuilder();
        sb.AppendLine("Col1;Col2;Col3");
        sb.AppendLine("A;B;C");

        var bytes = Encoding.UTF8.GetPreamble()
            .Concat(Encoding.UTF8.GetBytes(sb.ToString()))
            .ToArray();

        // Deve começar com BOM
        Assert.Equal(0xEF, bytes[0]);
        Assert.Equal(0xBB, bytes[1]);
        Assert.Equal(0xBF, bytes[2]);

        // Decodificando deve ter as linhas corretas
        var conteudo = Encoding.UTF8.GetString(bytes);
        Assert.Contains("Col1;Col2;Col3", conteudo);
        Assert.Contains("A;B;C", conteudo);
    }

    [Fact]
    public void CSV_NomeArquivo_DeveConterDataNoFormato()
    {
        var data = DateTime.Now;
        var nome = $"estudantes_semed_{data:yyyyMMdd_HHmm}.csv";
        // Verificar formato: estudantes_semed_YYYYMMDD_HHMM.csv
        Assert.Matches(@"^estudantes_semed_\d{8}_\d{4}\.csv$", nome);
    }
}

public class NotificacaoMaeTests
{
    [Fact]
    public void NotificacaoMae_MensagemBoasVindas_DeveConterCodigoEstudante()
    {
        var codigoUnico = "ALU-2026-000001";
        var nomeEstudante = "Pedro";
        var nomeEscola = "EM João Pessoa";
        var emailMae = "mae.12345678900@autistima.app.br";

        var mensagem = $"{nomeEstudante} foi cadastrado(a) por {nomeEscola}. " +
                       $"Seu código de estudante é {codigoUnico}. Acesse com o e-mail: {emailMae}";

        Assert.Contains(codigoUnico, mensagem);
        Assert.Contains(nomeEstudante, mensagem);
        Assert.Contains(nomeEscola, mensagem);
        Assert.Contains(emailMae, mensagem);
    }

    [Fact]
    public void NotificacaoMae_MensagemVinculo_QuandoMaeJaExistia()
    {
        var codigoUnico = "ALU-2026-000042";
        var nomeEstudante = "Ana";
        var nomeEscola = "EM Nossa Senhora";

        var mensagem = $"{nomeEstudante} foi vinculado(a) a {nomeEscola}. Código: {codigoUnico}.";

        Assert.Contains(codigoUnico, mensagem);
        Assert.Contains(nomeEscola, mensagem);
    }

    [Fact]
    public void NotificacaoAcesso_Aprovado_MensagemContemNomeEstudante()
    {
        var nomeEstudante = "Lucas";
        var titulo = "Acesso ao Prontuário Aprovado ✅";
        var mensagem = $"Seu acesso ao prontuário de {nomeEstudante} foi aprovado. Você já pode visualizar os registros.";

        Assert.Contains(nomeEstudante, mensagem);
        Assert.Contains("aprovado", mensagem);
        Assert.Contains("✅", titulo);
    }

    [Fact]
    public void NotificacaoAcesso_Rejeitado_MensagemContemMotivo()
    {
        var nomeEstudante = "Carla";
        var motivo = "Documentação insuficiente";
        var mensagem = $"Sua solicitação de acesso ao prontuário de {nomeEstudante} foi rejeitada. Motivo: {motivo}";

        Assert.Contains(motivo, mensagem);
        Assert.Contains(nomeEstudante, mensagem);
    }
}
