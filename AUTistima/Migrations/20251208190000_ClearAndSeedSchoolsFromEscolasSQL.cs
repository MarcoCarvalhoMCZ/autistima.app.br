using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUTistima.Migrations
{
    /// <inheritdoc />
    public partial class ClearAndSeedSchoolsFromEscolasSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Deletar todas as escolas existentes
            migrationBuilder.Sql("DELETE FROM [autistima_sa_sql].[Schools]");
            migrationBuilder.Sql("DBCC CHECKIDENT ('[autistima_sa_sql].[Schools]', RESEED, 0)");

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DOUTOR HENRIQUE EQUELMAN", "RUA 56 COHAB -  - JACINTINHO - Maceió", "Jacintinho", "57041620", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6365709, -35.7110774 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA DE ENSINO FUNDAMENTAL SAGRADO CORAÇÃO DE JESUS", "RUA DELMIRO GOUVEIA - SN - CRUZ DAS ALMAS - Maceió", "Cruz das Almas", "57038260", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6647625, -35.708704 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL ZANELI CALDAS", "PRAÇA DA MARAVILHA - 87 - POÇO - Maceió", "Poço", "57025860", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6586248, -35.717677 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DOUTOR ORLANDO ARAÚJO", "RUA DR. JOSÉ SAMPAIO LUZ -  - PONTA VERDE - Maceió", "Ponta Verde", "57035260", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6586543, -35.7108819 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL ANTÔNIO SEMEÃO LAMENHA LINS ", "RUA MAJOR JOSÉ JOAQUIM CALHEIROS -  - JACINTINHO - Maceió", "Jacintinho", "57041580", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6365709, -35.7110774 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL ARNON AFONSO FARIAS DE MELO ", "CONJ. JOSÉ DA SILVA PEIXOTO  -  - JACINTINHO - Maceió", "Jacintinho", "57041132", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6365709, -35.7110774 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DOM ANTÔNIO BRANDÃO ", "R. DO QUADRO  - SN - TABULEIRO - Maceió", "Tabuleiro do Martins", "57061120", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.57362400002035, -35.7636198712411 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DOUTOR POMPEU SARMENTO", "AVENIDA MUNIZ FALCÃO -  - BARRO DURO - Maceió", "Clima Bom", "57071130", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.58332718157225, -35.7396590577506 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI GRACILIANO RAMOS", "AV.DR. JOSÉ HAILTON DOS SANTOS - S/N - CIDADE UNIVERSITARIA - Maceió", "Cidade Universitária", "57073020", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI JOÃO XXIII", "RUA DR JOSE JOAQUIM ARAÚJO - 57 - JACINTINHO - Maceió", "Jacintinho", "57040090", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6365709, -35.7110774 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DOUTOR JOSÉ HAROLDO DA COSTA", "RUA DR. JÚLIO CÉSAR MENDONÇA UCHÔA -  - TABULEIRO DO MARTINS - Maceió", "Tabuleiro do Martins", "57081395", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5685551869336, -35.7569707024559 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSOR LENILTO ALVES SANTOS", "RUA ENFERMEIRO MARIANO -  - JACINTINHO - Maceió", "Jacintinho", "57041430", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6365709, -35.7110774 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL LUÍZA  OLIVEIRA SURUAGY ", "RUA PADRE CÍCERO -  - OURO PRETO - Maceió", "Ouro Preto", "57045815", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.56843676193485, -35.7474719326071 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI LUIZ CALHEIROS JÚNIOR", "RUA LOURIVAL DE AGUIAR PESSOA - 400 - SERRARIA - Maceió", "Serraria", "57046770", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5945808, -35.7280492 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL MAJOR BONIFÁCIO SILVEIRA", "AV JORNALISTA JOSÉ BATISTA - 277 - GRUTA DE LOURDES - Maceió", "Gruta de Lourdes", "57052645", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6125541, -35.7380054 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL MARECHAL FLORIANO PEIXOTO", "R. DA IGREJA -  - IPIOCA - Maceió", "Ipioca", "57039800", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.54659151427341, -35.626679153327 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PADRE PINHO", "RUA QUEBRANGULO - SN - CRUZ DAS ALMAS - Maceió", "Cruz das Almas", "57038460", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6647625, -35.708704 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PEDRO CAFÉ", "Praça leonidio Cardoso -  - RIO NOVO - Maceió", "Rio Novo", "57070570", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.59813271385177, -35.7716783890176 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PEDRO SURUAGY", "AV. MACEIÓ -  - TABULEIRO - Maceió", "Tabuleiro do Martins", "57061110", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.56831453902831, -35.7574474398445 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSOR DONIZETTE CALHEIROS ", "RUA JOSE HERMES DAMASCENO - S/N - SANTA LUCIA - Maceió", "Santa Lúcia", "57082010", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5865536, -35.7586476 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA EULINA RIBEIRO ALENCAR", "R. COARACY FONSECA -  - JACINTINHO - Maceió", "Jacintinho", "57040080", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6365709, -35.7110774 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL SUZEL DANTAS", "RUA ANTONIO MONTEIRO DE CARVALHO -  - TABULEIRO DO MARTINS - Maceió", "Tabuleiro do Martins", "57060020", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.57132539272584, -35.7567229102561 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL RUI PALMEIRA", "AV. MONTE CASTELO - SN - VERGEL DO LAGO - Maceió", "Vergel do Lago", "57015130", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.66782895040456, -35.7468942394374 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL SÉRGIO LUIZ PESSOA BRAGA", "AV. GOVERNADOR LAMENHA FILHO -  - CHÃ DA JAQUEIRA - Maceió", "Chã da Jaqueira", "57018550", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6191507, -35.7463003 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL SILVESTRE PÉRICLES", "PRAÇA DR. CAIO PORTO -  - PONTAL DA BARRA - Maceió", "Pontal da Barra", "57010830", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68905306290598, -35.7381565498812 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL JAIME DE ALTAVILLA ", "Rua Dilermando Reis -  - Santa Lúcia - Maceió", "Santa Lúcia", "57082045", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5865536, -35.7586476 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSOR CORINTHO DA PAZ", "CONJ. CIDADE UNIVERSITÁRIA -  - CIDADE UNIVERSITÁRIA - Maceió", "Cidade Universitária", "57072014", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSOR ANTÍDIO VIEIRA", "R. PAULO NETO  - SN - TRAPICHE - Maceió", "Trapiche da Barra", "57010380", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68545252498964, -35.7448549331619 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL HIGINO BELO ", "AV. SANTA RITA DE CÁSSIA  -  - FAROL - Maceió", "Farol", "57051600", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6555093, -35.7336269 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI NOSSA SENHORA DA GUIA", "AV. SIQUEIRA CAMPOS - 24/27 - TRAPICHE - Maceió", "Trapiche da Barra", "57010645", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68892362672242, -35.7481439418075 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSOR DERALDO CAMPOS", "PÇ. MOISES S. FIRMINO -  - VERGEL DO LAGO - Maceió", "Vergel do Lago", "57015050", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.66792821447216, -35.7516651215879 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA MARIA DE LOURDES VIEIRA ", "PRAÇA GONÇALVES LEDO - s/n - FAROL - Maceió", "Centro", "57020050", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6647296, -35.7385312 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI MARECHAL JOÃO BATISTA MASCARENHAS DE MORAES ", "PRAÇA DR. OSÓRIO CALHEIROS GATTO - S/N - PITANGUINHA - Maceió", "Pitanguinha", "57052320", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.64815558700123, -35.7249056351096 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI MONSENHOR LUIS BARBOSA ", "RUA DIVALDO SURUAGY - 98 - VILLAGE CAMPESTRE II - Maceió", "Cidade Universitária", "57073595", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI DOUTOR ANTÔNIO MÁRIO MAFRA ", "RUA 15 DE MARÇO  - S /N - LEVADA - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68324801296178, -35.7348842416203 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DE ENSINO FUNDAMENTAL SANTO ANTONIO", "AV. CACHOEIRA DO MEIRIM /LIRA  -  - BENEDITO BENTES - Maceió", "Benedito Bentes", "57084304", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DOUTOR BALTAZAR DE MENDONÇA ", "TEN. CEL. EXERC. BRAS. PEDRO JERONIMO DOS SANTOS - S/N - JACINTINHO - Maceió", "Jacintinho", "57040780", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6365709, -35.7110774 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL JOSÉ CORREIA COSTA", "AV EMPRESARIO VALENTIM DOS SANTOS DINIZ - s/n - SERRARIA - Maceió", "Serraria", "57046770", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5945808, -35.7280492 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DOUTOR JOSÉ CARNEIRO ", "RUA BERNADES LOPES - SN - Pinheiro - Maceió", "Pinheiro", "57057030", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6276873, -35.7384062 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL KÁTIA PIMENTEL ASSUNÇÃO ", "RUA BRENO CANSANÇAO - 788 - JACINTINHO - Maceió", "Jacintinho", "57041300", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6365709, -35.7110774 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL MANOEL PEDRO DOS SANTOS", "AV. CORINTHO CAMPELO DA PAZ -  - SANTOS DUMONT - Maceió", "Clima Bom", "57071230", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.57988003593628, -35.7407534811977 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI WALTER PITOMBO LARANJEIRAS", "AV GOVERNADOR TEOBALDO BARBOSA - 434 - VERGEL DO LAGO - Maceió", "Vergel do Lago", "57015852", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.66860487301587, -35.7516751257093 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSOR MANOEL COELHO NETO ", "RUA MANOEL FLORENTINO DA SILVA - 190 - PINHEIRO - Maceió", "Pinheiro", "57057380", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6276873, -35.7384062 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL TEREZA DE JESUS", "RUA SARGENTO JAYME PANTALEÃO - 75 - PRADO - Maceió", "Prado", "57010200", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68347570688572, -35.7375529017152 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL HERMÍNIO CARDOSO", "R. BARÃO DE JARAGUÁ - SN - FERNÃO VELHO - Maceió", "Rio Novo", "57070540", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.59236622216535, -35.7722544631193 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA JAREDE VIANA DE OLIVEIRA", "R. SÃO JOSÉ  - 888A - CLIMA BOM - Maceió", "Clima Bom", "57071051", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.57904535898876, -35.7398666194959 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA MARIA IVONE SANTOS DE OLIVEIRA ", "CONJ. CIDADE SORRISO I - S/N - BENEDITO BENTES II - Maceió", "Benedito Bentes", "57086131", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI GOVERNADOR LUIS ABILIO DE SOUSA NETO ", "RUA P, CONJ CIDADE SORRISO QD E - SN - BENEDITO BENTES II - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68251005449854, -35.7314684278412 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA MARIA APARECIDA BEZERRA NUNES", "CONJ. RES. DOS PESCADORES RUA ARY PITOMBO - s n - TRAPICHE DA BARRA - Maceió", "Trapiche da Barra", "57010386", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68537541686846, -35.7437112752662 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL GASTONE LÚCIA DE CARVALHO BELTRÃO", "CONJ. RES. JARDIM ROYAL II NÚMERO DO INEP 27051684 - SN - CIDADE UNIVERSITÁRIA - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.67704557311937, -35.7318550477701 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI JOSÉ MADLTTON VITOR DA SILVA", "Loteamento Bela Vista II - s/n - Benedito Bentes - Maceió", "Benedito Bentes", "57085540", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA FÚLVIA MARIA DE BARROS MOTT ROSEMBERG", "Avenida Alice Karoline -  - Cidade Universitária - Maceió", "Cidade Universitária", "57073415", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI ANA CAROLINA GALINA FORTES FERREIRA SANTIAGO", "Conjunto Novo Jardim  - S/N - Cidade Universitária - Maceió", "Cidade Universitária", "57072362", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA MARIA SALETE DA SILVA", "AVENIDA ANTÔNIO LISBOA DE AMORIM - S/N - BENEDITO BENTES - Maceió", "Benedito Bentes", "57085160", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL JOÃO FEITOSA", "Rua da Areia -  - Rio novo - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6765943717195, -35.7332280898501 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA MARIA JOSÉ DE OLIVEIRA ", "AVENIDA TANCREDO NEVES - SN - BENEDITO BENTES  - Maceió", "Cidade Universitária", "57073383", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI MESTRA VIRGÍNIA MORAES DA SILVA", "RUA SÃO LUIZ, CONJ. VALE DO TOCANTINS -  - RIO NOVO - Maceió", "Rio Novo", "57070630", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.59582303089602, -35.7726717319441 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSOR SILVÂNIO BARBOSA DOS SANTOS", "CONJ RESIDENCIAL JOSÉ APRIGIO VILELA - s/n - JACARECICA - Maceió", "Jacarecica", "57032070", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.62121532659095, -35.6994860589119 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA DULCINETE BARROS ALVES", "LOTEAMENTO CASA FORTE - S/N - ANTARES - Maceió", "Antares", "57048166", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.54722220350484, -35.7121137160267 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI MARTHA CÉLIA DE VASCONCELLOS BERNARDES", "RUA DR. JURACY PEREIRA - S/N - CIDADE UNIVERSITÁRIA - Maceió", "Cidade Universitária", "57072040", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA MARIA DE LOURDES BEZERRA NUNES", "RUA DR WALDEMIRO DE ALENCAR JR - 100 - MANGABEIRAS - Maceió", "Mangabeiras", "57037574", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6478561, -35.7147108 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSOR EDVALDO ALBUQUERQUE DOS SANTOS", "RUA D  - S/N - CIDADE UNIVERSITARIA - Maceió", "Cidade Universitária", "57073633", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI JOSE ORLANDO CAJE", "Avenida B - S/N - CIDADE UNIVERSITARIA - Maceió", "Cidade Universitária", "57072170", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA MARIA DA GRACAS SILVA", "Avenida Dr André Papini de Gois - 177 - Cidade Universitária - Maceió", "Cidade Universitária", "57073130", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA ALBENE CLARINDO DUARTE ", "RUA DR FRANCISCO AGUIRRE CAMARGO - S/N - BARRO DURO - Maceió", "Barro Duro", "57045450", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.65018809363235, -35.7435216350656 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA MARIA ELISABETE DOS SANTOS VASCONCELOS ", "Av. Lourival Melo Mota - S/N - SANTOS DUMONT - Maceió", "Santos Dumont", "57075970", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5320076, -35.795684 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA SIMONE FERREIRA SIMÃO ", "Avenida Maceió - 863 - TABULEIRO DO MARTINS - Maceió", "Tabuleiro do Martins", "57061110", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.57157438499642, -35.7591512682408 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA ANNE CLEIDE PIMENTEL BEZERRA ", "Avenida Menino Marcelo - 247 - ANTARES - Maceió", "Antares", "57083410", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.55366498233322, -35.7093820021919 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA ZAIRA NASCIMENTO DE OLIVEIRA - 27055680 INEP ", "Travessa Jatobá - 37 - Chã da Jaqueira - Maceió", "Chã da Jaqueira", "57018534", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6191507, -35.7463003 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA IVANEIDE MARIA SANTANA FARIAS ", "Conjunto Cidade Sorriso 1 - S/N - BENEDITO BENTES - Maceió", "Benedito Bentes", "57086037", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA NADIR BRANDÃO CAVALCANTE ", "RUA DA IGREJA - SN - IPIOCA - Maceió", "Ipioca", "57039800", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5525095118403, -35.6285154292651 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI ESTUDANTE JOAO PEDRO DA SILVA BERNARDINO ", "Rua Boa Vista - S/N - OURO PRETO - Maceió", "Ouro Preto", "57045811", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.57104080676541, -35.7451496927926 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI DESEMBARGADOR JOSE FERNANDO DE LIMA SOUZA ", "RUA BARÃO DE ATALAIA - 823 - CENTRO - Maceió", "Centro", "57020510", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6647296, -35.7385312 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA LUCINEIDE GOMES FLOR", "RUA FAUSTINO DA SILVEIRA - 68 - BEBEDOURO - Maceió", "Bebedouro", "57017692", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6232608, -35.7516398 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA CLAUDIA MARIA DA SILVA BRASIL", "AV EMPRESÁRIO NELSON OLIVEIRA MENEZES - 1323 - CIDADE UNIVERSITARIA - Maceió", "Cidade Universitária", "57073000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PADRE SILVESTRE VREDEGOOR", "PARQUE AFRÂNIO JORGE - S/N - PRADO - Maceió", "Prado", "57010020", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6823321378845, -35.7375926223515 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DOM MIGUEL FENELLON CÂMARA", "CONJ. JARDIM PETRÓPOLIS II - SN - PETRÓPOLIS - Maceió", "Petrópolis", "57062417", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.56526147296053, -35.7192611198076 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL ZUMBI DOS PALMARES", "CONJ. ROSANE COLLOR QD M - SN - CLIMA BOM - Maceió", "Clima Bom", "57071470", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.58177105810685, -35.7375960983266 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL MARIA CARMELITA CARDOSO GAMA ", "CAMPUS A.C. SIMÕES -  - CIDADE UNIVERSITÁRIA - Maceió", "Cidade Universitária", "57072900", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5552291, -35.7781208 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA NEIDE DE FREITAS FRANÇA", "POVOADO SAÚDE - IPIOCA - 303 - IPIOCA - Maceió", "Ipioca", "57039703", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.54774201029977, -35.630462718136 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL TRADUTOR JOÃO SAMPAIO", "RUA PERIMETRAL 5 - S/N - CONJ. JOÃO SAMPAIO I - Maceió", "Petrópolis", "57062636", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.56240286716157, -35.7170995366023 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA DE ENSINO FUNDAMENTAL NOSSA SENHORA APARECIDA", "RUA PROFESSORA MARIA JOSÉ LOUREIRO LIMA - 200 - PRADO - Maceió", "Prado", "57010324", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.67897980407205, -35.7341752064409 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA DE ENSINO FUNDAMENTAL LUIZ PEDRO DA SILVA I ", "RUA DEPUTADO JOSÉ BERNARDES - 10 - PETRÓPOLIS - Maceió", "Petrópolis", "57062195", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.56780593897751, -35.7237040532976 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA HÉVIA VALÉRIA MAIA AMORIM", "CONJ. VILLAGE CAMPESTRE I -  - TABULEIRO - Maceió", "Cidade Universitária", "57073490", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI BRENO AGRA ", "AV. ARTHUR VALENTE JUCÁ -  - BENEDITO BENTES I - Maceió", "Benedito Bentes", "57084048", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI LEDA COLLOR DE MELLO ", "RUA EM PROJETO, CONJ. OSMAN LOUREIRO - s/n - TABULEIRO DO MARTINS - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68180775542992, -35.7314916418578 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI BENEVIDES EPAMINONDAS DA SILVA", "AVENIDA GENERAL DE FRANÇA - 1585   - RIACHO DOCE - Maceió", "Riacho Doce", "57039230", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5818942343826, -35.648209337093 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CRECHE ROSANE COLLOR", "RUA JOSE REIS CAMPOS - s/n - JACINTINHO - Maceió", "Jacintinho", "57041540", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6365709, -35.7110774 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI MARIA LIEGE TAVARES DE ALBUQUERQUE", "RUA SÃO JOSÉ - SN - JACINTINHO - Maceió", "Jacintinho", "57040510", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6365709, -35.7110774 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI TEREZA DE LISIEUX", "RUA CÍCERO TORRES - S/N - LEVADA - Maceió", "Levada", "57017140", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.67517454245763, -35.7400560480257 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CRECHE SUZANA PALMEIRA", "RUA ALVARO MARINHO - 855/2 - PRADO - Maceió", "Prado", "57010050", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6792718577233, -35.7372654201523 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI HERMÉ MIRANDA  ", "R. PEDROSA - 203 - TABULEIRO - Maceió", "Tabuleiro do Martins", "57081510", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5683657871304, -35.7562344588648 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI AGENOR FERNANDES PONTES ", "VILA GOIABEIRA - 132 - FERNÃO VELHO - Maceió", "Fernão Velho", "57070440", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.60386220532486, -35.7820709277773 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DRA ELIZABETH ANNE LYRA LOPES DE FARIAS", "R. ROBERT LYRA - 04 - BENEDITO BENTES - Maceió", "Vergel do Lago", "57015320", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.67346743474962, -35.7538300209766 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI JOSÉ MARIA DE MELO ", " RUA BELO HORIZONTE - SN - BENEDITO BENTES - Maceió", "Benedito Bentes", "57084780", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI VICE-GOVERNADOR FRANCISCO MELLO", "CONJ. VIRGEM DOS POBRES - S/N - VERGEL DO LAGO - Maceió", "Trapiche da Barra", "57010480", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68700456795329, -35.7471657410068 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DOM HELDER CÂMARA", "RUA ACRE - S/N - FEITOSA - Maceió", "Feitosa", "57043230", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6306916, -35.7256452 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL SELMA BANDEIRA", "CONJ SELMA BANDEIRA -  - BENEDITO BENTES - Maceió", "Benedito Bentes", "57086236", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DOUTORA NISE DA SILVEIRA", "LOTEAMENTO TERRA DE ANTARES I - SN - SERRARIA - Maceió", "Antares", "57048140", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.54823278541899, -35.7094791621512 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL CÍCERA LUCIMAR DE SENA SANTOS", "Rua José Maria de Lima, antiga 26 de abril - 222 - Poço - Maceió", "Poço", "57025570", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6586248, -35.717677 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA ELMA MARQUES CURTI", "AV. BENEDITO BENTES -  - BENEDITO BENTES II - Maceió", "Benedito Bentes", "57084649", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA MARIA NILDA DOS SANTOS SILVA", "RUA SÃO FRANCISCO DE ASSIS -  - CHÃ DA JAQUEIRA - Maceió", "Chã da Jaqueira", "57018445", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.616444, -35.7459655 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA RUTH BRAGA QUINTELA CAVALCANTE", "RUA PASTOR EURICO CALHEIROS - 502 - JACINTINHO - Maceió", "Jacintinho", "57041620", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6384785, -35.7124853 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSOR PETRÔNIO VIANA", "CONJUNTO CARMINHA -  - BENEDITO BENTES - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.67895638898082, -35.7384799754209 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSOR AURÉLIO BUARQUE DE HOLANDA FERREIRA ", "CONJ. FREITAS NETO - S/N - BENEDITO BENTES - Maceió", "Benedito Bentes", "57086412", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA DE ENSINO FUNDAMENTAL LUIZ PEDRO DA SILVA II ", "RUA NADJA ABYS FRANÇA - 32 - CLIMA BOM - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68302957795266, -35.7367306974047 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA DE ENSINO FUNDAMENTAL LUIZ PEDRO DA SILVA IV", "COMPLEXO RESIDENCIAL GAMA LINS -  - CIDADE UNIVERSITÁRIA - Maceió", "Santa Lúcia", "57082000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5865536, -35.7586476 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA GERUZA COSTA LIMA", "RUA SANTA MARGARIDA - 222 - JACINTINHO - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68111673153711, -35.7347595358972 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL FREI DAMIÃO", "AV MUNDAÚ - 120 - BENEDITO BENTES - Maceió", "Benedito Bentes", "57085778", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL DOUTOR DENISSON LUIZ CERQUEIRA MENEZES", "CONJ. DENISSON MENEZES -  - TABULEIRO - Maceió", "Cidade Universitária", "57073639", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA MARIA JOSÉ CARRASCOSA ", "RUA DIEGUES JUNIOR - 224 - POÇO - Maceió", "Poço", "57025650", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6586248, -35.717677 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI MESTRE MÁRIO IZALDINO", "AV SENADOR ARNON DE MELLO - 25 - PONTAL DA BARRA - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68172969643873, -35.738029356439 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA KYRA MARIA BARROS PAES ", "RUA MUNIZ FALCÃO -  - CLIMA BOM - Maceió", "Clima Bom", "57071130", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.57691549313523, -35.741253467185 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PAULO HENRIQUE COSTA BANDEIRA", "RUA NORMA PIMENTEL DA COSTA - 11 - BENEDITO BENTES - Maceió", "Benedito Bentes", "57084650", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA NATALINA COSTA CAVALCANTE", "RUA ROTARY -  - TABULEIRO DO MARTINS - Maceió", "Tabuleiro do Martins", "57081132", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.56869944977204, -35.7598450289292 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI SÃO SEBASTIÃO", "RUA EDGAR DE GOES MONTEIRO  - 817 - PRADO - Maceió", "Prado", "57010140", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68198684118247, -35.7383476048007 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL MARIA DE FÁTIMA LYRA ", "BENEDITO BENTES I RUA A VINTE E CINCO - 310 - BENEDITO BENTES - Maceió", "Benedito Bentes", "57084025", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL MARIA DE LOURDES DE MELO PIMENTEL", "RUA PADRE CÍCERO - 05 - CIDADE UNIVERSITARIA - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68106434780435, -35.737972946011 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL OCTÁVIO BRANDÃO", "RUA JOSE LOBO DE MEDEIROS -  - TABULEIRO - Maceió", "Tabuleiro do Martins", "57061100", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.56848951767931, -35.7630101689275 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI CASA DA AMIZADE ", "AV. VEREADOR DARIO MARSIGLIA - 300 - TABULEIRO - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.67880392213741, -35.7377867045641 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PADRE BRANDÃO LIMA ", "AVENIDA CACHOEIRA DO MEIRIM - S/N - BENEDITO BENTES - Maceió", "Benedito Bentes", "57084700", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PIO X", "RUA PROFESSORA MARIA JOSÉ LOUREIRO LIMA - 200 - PRADO - Maceió", "Prado", "57010324", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68208206861178, -35.7334387759458 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA SILVIA CELINA NUNES LIMA", "RUA BENEDITO CALAÇA LOUREIRO - 2001 - CIDADE UNIVERSITÁRIA - Maceió", "Cidade Universitária", "57073510", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL MARCOS SORIANO", "CONJ. JARDIM PETROPÓLIS II B -  - PETRÓPOLIS - Maceió", "Petrópolis", "57062572", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.56889808179245, -35.7176014453428 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL BENEDITA DA SILVA SANTOS ", "AV ARTHUR VALENTE JUCA - 557 - BENEDITO BENTES - Maceió", "Benedito Bentes", "57084610", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL CESAR AUGUSTO DE OLIVEIRA", "R. BOA ESPERANÇA -  - SANTOS DUMONT - Maceió", "Santos Dumont", "57075570", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5320076, -35.795684 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL JAIME AMORIM MIRANDA ", "AV BELMIRO AMORIM  - 760 - TABULEIRO - Maceió", "Santa Lúcia", "57082000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5865536, -35.7586476 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL OLAVO BILAC", "RUA GOVERNADOR LAMENHA FILHO - SN - FEITOSA - Maceió", "Feitosa", "57043000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6306916, -35.7256452 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL YEDA OLIVEIRA DOS SANTOS", "AV JOSÉ CAMELO DE FREITAS - 595 - CIDADE UNIVERSITARIA - Maceió", "Cidade Universitária", "57073360", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI HELOÍSA MARINHO DE GUSMÃO MEDEIROS ", "AVENIDA MOACIR ANDRADE -  - BENEDITO BENTES II - Maceió", "Benedito Bentes", "57086171", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA MARILUCIA MACEDO DOS SANTOS", "RUA ANTÔNIO ZEFERINO DOS SANTOS - 20 - JACINTINHO - Maceió", "Jacintinho", "57042030", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6384785, -35.7124853 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA MARIA DE FÁTIMA MELO DOS SANTOS ", "AVENIDA MACEIO       - 342 - TABULEIRO - Maceió", "Tabuleiro do Martins", "57061110", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.57167852130199, -35.7601891326778 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL MONSENHOR ANTÔNIO ASSUNÇÃO ARAÚJO", "RUA ARACI MARTINS DA SILVA - 04 - SERRARIA - Maceió", "Serraria", "57046161", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5945808, -35.7280492 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA MARIZETTE CORREIA NUNES BRUNO", "AVENIDA MENINO MARCELO LOTEAMENTO CASA FORTE  - 08 - SERRARIA - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.67841169043449, -35.7317200444119 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA ZILKA DE OLIVEIRA GRAÇA", "RUA JOSÉ GONZAGA DE ALMEIDA - 276 - TABULEIRO DO MARTINS - Maceió", "Tabuleiro do Martins", "57061060", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.56707308219645, -35.7594023343747 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA MARIA DO SOCORRO TAVARES LIMA DA SILVA", "RUA CARLOS DE MIRANDA - 257 - POÇO - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68233059517171, -35.7330946156743 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL CÍCERO DUÉ DA SILVA", "AV. MENINO MARCELO - 1391 - CIDADE UNIVERTÁRIA - Maceió", "Cidade Universitária", "57073460", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5539008, -35.7461255 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI JORGE DE LIMA ", "AV. BELMIRO AMORIM - 1750 - SANTA LÚCIA - Maceió", "Santa Lúcia", "57082000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5865536, -35.7586476 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA MARIA JOSÉ CLEMENTE ROCHA", "RUA A 5 - 47 - BENEDITO BENTES  - Maceió", "Poço", "57025673", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6586248, -35.717677 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PROFESSORA CLAUDINETE BATISTA DA SILVA", "R. ARY PITOMBO - 290 - TRAPICHE - Maceió", "Trapiche da Barra", "57010376", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6880427971936, -35.7459263779812 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI TOBIAS GRANJA", "AV. JORN. TEOFILO A. LINS -  - CLIMA BOM - Maceió", "Clima Bom", "57071820", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.58382324823213, -35.7360674005005 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI HERBERT DE SOUZA  ", "AV. GAL LUIZ DE FRANÇA ALBUQUERQUE - s/n - JACARECICA - Maceió", "Prado", "57010000", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.68112661072629, -35.7314143293695 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI VEREADOR BRAGA NETO", "RUA ELIETE ROLEMBERG DE FIGUEIREDO - 163 - TABULEIRO DOS MARTINS - Maceió", "Tabuleiro do Martins", "57061070", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.56612851242515, -35.7637679909151 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL PEDRO BARBOSA JÚNIOR", "RUA ARNALDO BRAGA  -  - CRUZ DAS ALMAS - Maceió", "Cruz das Almas", "57038130", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.6647625, -35.708704 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PROFESSORA ELZA LIRA", "CONJ SELMA BANDEIRA -  - BENEDITO BENTES - Maceió", "Benedito Bentes", "57086281", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL MARIA CECILIA PONTES CARNAÚBA", "AV. GILBERTO SOARES PINTO - 763 - ANTARES I - Maceió", "Antares", "57048260", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.55004915985304, -35.7121244137866 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "ESCOLA MUNICIPAL RADIALISTA EDÉCIO LOPES", "ALAMEDA CELIA DOS ANJOS -  Nº 06 - PETROPOLIS - Maceió", "Petrópolis", "57062200", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.56879731405515, -35.7238417636864 });

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Schools",
                columns: new[] { "Nome", "Endereco", "Bairro", "CEP", "Cidade", "Estado", "EscolaPublica", "PossuiSalaRecursos", "Ativo", "DataCadastro", "Latitude", "Longitude" },
                values: new object[] { "CMEI PRESIDENTE FRANCISCO DE PAULA RODRIGUES ALVES", "AV. CACHOEIRA DO MEIRIM -  - BENEDITO BENTES - Maceió", "Benedito Bentes", "57084700", "Maceió", "AL", true, false, true, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), -9.5859671, -35.7150116 });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
