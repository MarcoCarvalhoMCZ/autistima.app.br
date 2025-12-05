using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AUTistima.Migrations
{
    /// <inheritdoc />
    public partial class SeedCapsMaceio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8260));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "Services",
                columns: new[] { "Id", "AtendeOnline", "Ativo", "Bairro", "CEP", "Cidade", "DataCadastro", "Descricao", "Email", "Endereco", "Especialidade", "Estado", "NomeProfissional", "Observacoes", "RegistroProfissional", "Telefone", "TipoAtendimento", "UserId", "ValorConsulta", "Verificado", "Website" },
                values: new object[,]
                {
                    { 1, false, true, "Centro", "57020-090", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6400), "Centro de Atenção Psicossocial para atendimento de adultos com transtornos mentais graves e persistentes. Oferece acolhimento, atendimento individual e em grupo, oficinas terapêuticas e acompanhamento familiar.", null, "Rua Comendador Palmeira, 270", 1, "AL", "CAPS II - Centro (Dr. Everaldo Moreira)", "Atendimento de segunda a sexta, das 8h às 17h. Funcionamento em regime de porta aberta.", null, "(82) 3315-5590", 1, null, "Gratuito (SUS)", true, null },
                    { 2, false, true, "Jacintinho", "57041-400", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6850), "Centro de Atenção Psicossocial para atendimento de adultos com transtornos mentais graves. Equipe multidisciplinar com psicólogos, psiquiatras, assistentes sociais e terapeutas ocupacionais.", null, "Rua Conselheiro Lourenço de Albuquerque, s/n", 1, "AL", "CAPS II - Jacintinho", "Atendimento de segunda a sexta, das 8h às 17h.", null, "(82) 3315-5591", 1, null, "Gratuito (SUS)", true, null },
                    { 3, false, true, "Benedito Bentes", "57084-000", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6850), "Centro de Atenção Psicossocial para atendimento de adultos com transtornos mentais. Oferece atendimento individual, em grupo, oficinas terapêuticas e visitas domiciliares.", null, "Conjunto Denisson Menezes, s/n", 1, "AL", "CAPS II - Benedito Bentes", "Atendimento de segunda a sexta, das 8h às 17h.", null, "(82) 3315-5592", 1, null, "Gratuito (SUS)", true, null },
                    { 4, false, true, "Farol", "57055-000", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6850), "CAPS especializado no atendimento de crianças e adolescentes com transtornos mentais graves, incluindo autismo (TEA). Equipe especializada em saúde mental infantojuvenil com psicólogos, fonoaudiólogos, terapeutas ocupacionais e psiquiatras.", null, "Av. Fernandes Lima, 1681", 1, "AL", "CAPSi - Centro de Atenção Psicossocial Infanto-Juvenil", "Atendimento especializado para crianças e adolescentes de 0 a 18 anos. Referência em TEA. Segunda a sexta, das 8h às 17h.", null, "(82) 3315-5593", 1, null, "Gratuito (SUS)", true, null },
                    { 5, false, true, "Trapiche da Barra", "57010-005", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6860), "CAPS especializado em tratamento de pessoas com transtornos relacionados ao uso de álcool e outras drogas. Funciona 24 horas com leitos de acolhimento noturno.", null, "Av. Siqueira Campos, 1655", 1, "AL", "CAPS AD III - Centro de Atenção Psicossocial Álcool e Drogas", "Funcionamento 24 horas, incluindo finais de semana e feriados. Possui leitos de acolhimento.", null, "(82) 3315-5594", 1, null, "Gratuito (SUS)", true, null },
                    { 6, false, true, "Tabuleiro do Martins", "57081-000", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6860), "Centro de Atenção Psicossocial com funcionamento 24 horas para adultos com transtornos mentais graves. Possui leitos de acolhimento noturno e atendimento de urgência psiquiátrica.", null, "Rua México, s/n", 1, "AL", "CAPS III - Tabuleiro do Martins", "Funcionamento 24 horas. Porta de entrada para urgências psiquiátricas.", null, "(82) 3315-5595", 1, null, "Gratuito (SUS)", true, null },
                    { 7, false, true, "Poço", "57025-000", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6860), "Ambulatório de especialidades com atendimento em neurologia, psiquiatria e psicologia. Realiza avaliação diagnóstica para TEA e acompanhamento de pessoas autistas.", null, "Av. Major Cícero de Góes Monteiro, 1655", 5, "AL", "Ambulatório de Saúde Mental - PAM Salgadinho", "Necessário encaminhamento da UBS. Atendimento mediante agendamento.", null, "(82) 3315-5500", 1, null, "Gratuito (SUS)", true, null },
                    { 8, false, true, "Farol", "57055-170", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(7280), "Instituição filantrópica que oferece atendimento multidisciplinar gratuito para pessoas com deficiência intelectual e autismo. Serviços incluem: psicologia, fonoaudiologia, terapia ocupacional, fisioterapia, pedagogia e serviço social.", "apae.maceio@gmail.com", "Rua José de Alencar, 340", 3, "AL", "APAE Maceió - Associação de Pais e Amigos dos Excepcionais", "Atendimento gratuito pelo SUS. Necessário cadastro e avaliação inicial. Segunda a sexta, das 7h às 17h.", null, "(82) 3221-3344", 1, null, "Gratuito", true, null },
                    { 9, false, true, "Pitanguinha", "57052-280", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(7290), "Associação especializada no atendimento de pessoas autistas e suas famílias. Oferece terapia ABA, fonoaudiologia, terapia ocupacional, psicopedagogia e grupos de apoio para famílias.", "ama.alagoas@gmail.com", "Rua Melo Moraes, 99", 9, "AL", "AMA Alagoas - Associação dos Amigos do Autista", "Associação sem fins lucrativos. Oferece atendimento por valor social. Grupos de apoio para mães.", null, "(82) 3223-4567", 2, null, "Valor social (consultar)", true, null },
                    { 10, false, true, "Trapiche da Barra", "57010-300", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(7700), "Clínica escola da Universidade Estadual de Ciências da Saúde de Alagoas. Oferece atendimento fonoaudiológico gratuito para avaliação e terapia de linguagem, fala e comunicação alternativa.", null, "Rua Dr. Jorge de Lima, 113", 2, "AL", "Clínica Escola UNCISAL - Fonoaudiologia", "Atendimento gratuito por estudantes supervisionados. Necessário agendamento. Fila de espera pode ser longa.", null, "(82) 3315-6700", 3, null, "Gratuito (clínica escola)", true, "https://www.uncisal.edu.br" },
                    { 11, false, true, "Farol", "57051-160", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(7710), "Clínica escola do CESMAC com atendimento psicológico por estudantes supervisionados. Oferece avaliação psicológica, psicoterapia individual e familiar, e grupos terapêuticos.", null, "Rua Cônego Machado, 918", 1, "AL", "Clínica Escola CESMAC - Psicologia", "Atendimento por estudantes de psicologia supervisionados. Valor social para comunidade.", null, "(82) 3215-5000", 3, null, "Gratuito ou valor social", true, "https://www.cesmac.edu.br" },
                    { 12, false, true, "Cidade Universitária", "57072-970", "Maceió", new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(7710), "Serviço de Psicologia Aplicada da Universidade Federal de Alagoas. Oferece atendimento psicológico gratuito à comunidade, incluindo avaliação e acompanhamento de crianças autistas.", null, "Campus A.C. Simões, Av. Lourival Melo Mota, s/n", 1, "AL", "Clínica de Psicologia UFAL", "Serviço gratuito da UFAL. Necessário inscrição e triagem. Atendimento por estudantes supervisionados por professores.", null, "(82) 3214-1100", 3, null, "Gratuito", true, "https://www.ufal.edu.br" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 50, 49, 584, DateTimeKind.Utc).AddTicks(9090));
        }
    }
}
