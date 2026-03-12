using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUTistima.Migrations
{
    /// <inheritdoc />
    public partial class SEMED_Adequacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EscolaVinculadaId",
                schema: "autistima_sa_sql",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CadastradoPorEscolaUserId",
                schema: "autistima_sa_sql",
                table: "Children",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoUnico",
                schema: "autistima_sa_sql",
                table: "Children",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Comorbidades",
                schema: "autistima_sa_sql",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OutrasCondicoes",
                schema: "autistima_sa_sql",
                table: "Children",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RegistrosEstudante",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoRegistro = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosEstudante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosEstudante_Children_ChildId",
                        column: x => x.ChildId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistrosEstudante_Users_AutorId",
                        column: x => x.AutorId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacoesAcessoPerfil",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    ProfissionalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodigoEstudanteInformado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MotivoRejeicao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDecisao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AprovadoPorAdminId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacoesAcessoPerfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitacoesAcessoPerfil_Children_ChildId",
                        column: x => x.ChildId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacoesAcessoPerfil_Users_AprovadoPorAdminId",
                        column: x => x.AprovadoPorAdminId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SolicitacoesAcessoPerfil_Users_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3030));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3700));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3620));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3820));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 13,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3630));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 14,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3630));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 15,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3630));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 16,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3630));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 17,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 18,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 19,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 20,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3700));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 21,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3700));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 22,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3700));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 23,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 24,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 25,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 26,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 27,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 28,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 29,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 30,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 31,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 32,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 33,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 34,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 35,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 36,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 37,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 38,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 39,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 40,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 41,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 42,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 43,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 44,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 45,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 46,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 47,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 48,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3960));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 49,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3970));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 50,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3970));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 51,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3970));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 52,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3970));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 53,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3980));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 54,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(3980));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 55,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 56,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 57,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5110));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 58,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5110));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 59,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5110));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 60,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5120));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 61,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5120));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 62,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5120));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 63,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5120));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 64,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 65,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 66,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 67,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 68,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 69,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 70,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 71,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 72,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 73,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 74,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 75,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 76,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 77,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 78,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 504, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(1550));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(2130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(2140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(2140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(2150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(2150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(2150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(2700));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(2710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(3260));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(3270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 19, 20, 34, 507, DateTimeKind.Utc).AddTicks(3270));

            migrationBuilder.CreateIndex(
                name: "IX_Users_EscolaVinculadaId",
                schema: "autistima_sa_sql",
                table: "Users",
                column: "EscolaVinculadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_CadastradoPorEscolaUserId",
                schema: "autistima_sa_sql",
                table: "Children",
                column: "CadastradoPorEscolaUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_CodigoUnico",
                schema: "autistima_sa_sql",
                table: "Children",
                column: "CodigoUnico",
                unique: true,
                filter: "[CodigoUnico] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosEstudante_AutorId",
                schema: "autistima_sa_sql",
                table: "RegistrosEstudante",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosEstudante_ChildId",
                schema: "autistima_sa_sql",
                table: "RegistrosEstudante",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosEstudante_ChildId_Ativo",
                schema: "autistima_sa_sql",
                table: "RegistrosEstudante",
                columns: new[] { "ChildId", "Ativo" });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosEstudante_DataRegistro",
                schema: "autistima_sa_sql",
                table: "RegistrosEstudante",
                column: "DataRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesAcessoPerfil_AprovadoPorAdminId",
                schema: "autistima_sa_sql",
                table: "SolicitacoesAcessoPerfil",
                column: "AprovadoPorAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesAcessoPerfil_ChildId",
                schema: "autistima_sa_sql",
                table: "SolicitacoesAcessoPerfil",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesAcessoPerfil_ProfissionalId",
                schema: "autistima_sa_sql",
                table: "SolicitacoesAcessoPerfil",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesAcessoPerfil_ProfissionalId_ChildId",
                schema: "autistima_sa_sql",
                table: "SolicitacoesAcessoPerfil",
                columns: new[] { "ProfissionalId", "ChildId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesAcessoPerfil_Status",
                schema: "autistima_sa_sql",
                table: "SolicitacoesAcessoPerfil",
                column: "Status");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Users_CadastradoPorEscolaUserId",
                schema: "autistima_sa_sql",
                table: "Children",
                column: "CadastradoPorEscolaUserId",
                principalSchema: "autistima_sa_sql",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Schools_EscolaVinculadaId",
                schema: "autistima_sa_sql",
                table: "Users",
                column: "EscolaVinculadaId",
                principalSchema: "autistima_sa_sql",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Users_CadastradoPorEscolaUserId",
                schema: "autistima_sa_sql",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Schools_EscolaVinculadaId",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RegistrosEstudante",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "SolicitacoesAcessoPerfil",
                schema: "autistima_sa_sql");

            migrationBuilder.DropIndex(
                name: "IX_Users_EscolaVinculadaId",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Children_CadastradoPorEscolaUserId",
                schema: "autistima_sa_sql",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Children_CodigoUnico",
                schema: "autistima_sa_sql",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "EscolaVinculadaId",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CadastradoPorEscolaUserId",
                schema: "autistima_sa_sql",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "CodigoUnico",
                schema: "autistima_sa_sql",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "Comorbidades",
                schema: "autistima_sa_sql",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "OutrasCondicoes",
                schema: "autistima_sa_sql",
                table: "Children");

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3250));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3670));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 13,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3670));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 14,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3670));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 15,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3670));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 16,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3670));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 17,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 18,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 19,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 20,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 21,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 22,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 23,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 24,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 25,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 26,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 27,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 28,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 29,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 30,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 31,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 32,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 33,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 34,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 35,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 36,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 37,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 38,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 39,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 40,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 41,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 42,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 43,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 44,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 45,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 46,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 47,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 48,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 49,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 50,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3870));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 51,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3870));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 52,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3870));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 53,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3870));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 54,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(3870));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 55,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 56,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 57,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 58,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 59,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 60,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 61,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 62,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 63,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 64,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 65,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 66,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 67,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 68,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 69,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 70,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 71,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 72,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 73,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 74,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 75,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 76,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 77,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4790));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 78,
                column: "DataCriacao",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 491, DateTimeKind.Utc).AddTicks(4790));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(3840));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(4250));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(4280));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(4290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(4290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(4290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(4300));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCadastro",
                value: new DateTime(2026, 2, 25, 19, 9, 49, 493, DateTimeKind.Utc).AddTicks(5100));
        }
    }
}
