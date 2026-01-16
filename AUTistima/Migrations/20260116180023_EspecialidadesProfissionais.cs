using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AUTistima.Migrations
{
    /// <inheritdoc />
    public partial class EspecialidadesProfissionais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfessionalSpecialties",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Ordem = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalSpecialties", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(6940));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7310));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7310));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7310));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7320));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7350));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7390));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 13,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 14,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 15,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7310));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 16,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7310));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 17,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7310));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 18,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7320));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 19,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7320));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 20,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7320));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 21,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7320));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 22,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7350));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 23,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7350));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 24,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7350));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 25,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7350));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 26,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 27,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 28,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 29,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 30,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 31,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 32,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 33,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 34,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 35,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 36,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 37,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7380));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 38,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7380));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 39,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7390));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 40,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7390));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 41,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 42,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 43,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 44,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 45,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 46,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 47,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 48,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 49,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 50,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 51,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 52,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 53,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7420));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 54,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(7420));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 55,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 56,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 57,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 58,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 59,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 60,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 61,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 62,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 63,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 64,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 65,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 66,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 67,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 68,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 69,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 70,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 71,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 72,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 73,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 74,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 75,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 76,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 77,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 78,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 883, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "ProfessionalSpecialties",
                columns: new[] { "Id", "Ativo", "Descricao", "Nome", "Ordem" },
                values: new object[,]
                {
                    { 1, true, null, "Psicologia", 1 },
                    { 2, true, null, "Fonoaudiologia", 2 },
                    { 3, true, null, "Terapia Ocupacional", 3 },
                    { 4, true, null, "Psicopedagogia", 4 },
                    { 5, true, null, "Neurologia", 5 },
                    { 6, true, null, "Psiquiatria", 6 },
                    { 7, true, null, "Fisioterapia", 7 },
                    { 8, true, null, "Musicoterapia", 8 },
                    { 9, true, null, "ABA", 9 },
                    { 10, true, null, "Nutrição", 10 },
                    { 11, true, null, "Psicanálise", 11 }
                });

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(4300));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(4680));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(4680));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(5030));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(5040));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(5360));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(5370));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 18, 0, 22, 885, DateTimeKind.Utc).AddTicks(5370));

            migrationBuilder.CreateIndex(
                name: "IX_Users_Especialidade",
                schema: "autistima_sa_sql",
                table: "Users",
                column: "Especialidade");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSpecialties_Nome",
                schema: "autistima_sa_sql",
                table: "ProfessionalSpecialties",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSpecialties_Ordem",
                schema: "autistima_sa_sql",
                table: "ProfessionalSpecialties",
                column: "Ordem");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ProfessionalSpecialties_Especialidade",
                schema: "autistima_sa_sql",
                table: "Services",
                column: "Especialidade",
                principalSchema: "autistima_sa_sql",
                principalTable: "ProfessionalSpecialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ProfessionalSpecialties_Especialidade",
                schema: "autistima_sa_sql",
                table: "Users",
                column: "Especialidade",
                principalSchema: "autistima_sa_sql",
                principalTable: "ProfessionalSpecialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ProfessionalSpecialties_Especialidade",
                schema: "autistima_sa_sql",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ProfessionalSpecialties_Especialidade",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ProfessionalSpecialties",
                schema: "autistima_sa_sql");

            migrationBuilder.DropIndex(
                name: "IX_Users_Especialidade",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 13,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 14,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 15,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 16,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 17,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 18,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 19,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 20,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 21,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 22,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 23,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 24,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 25,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 26,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 27,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 28,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 29,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 30,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5170));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 31,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5170));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 32,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 33,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 34,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 35,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 36,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 37,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 38,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 39,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 40,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 41,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5260));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 42,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 43,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 44,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 45,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 46,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 47,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 48,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 49,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 50,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 51,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 52,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5300));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 53,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5300));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 54,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5300));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 55,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5960));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 56,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 57,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 58,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 59,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 60,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 61,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 62,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 63,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 64,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 65,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 66,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 67,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5990));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 68,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5990));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 69,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5990));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 70,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5990));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 71,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5990));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 72,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5990));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 73,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(5990));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 74,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 75,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 76,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 77,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 78,
                column: "DataCriacao",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 265, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(1330));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(2060));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(2070));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(2390));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(2400));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCadastro",
                value: new DateTime(2026, 1, 16, 17, 40, 35, 268, DateTimeKind.Utc).AddTicks(2400));
        }
    }
}
