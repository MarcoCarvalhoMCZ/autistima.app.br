using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUTistima.Migrations
{
    /// <inheritdoc />
    public partial class AddUserPersonalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CEP",
                schema: "autistima_sa_sql",
                table: "Users",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                schema: "autistima_sa_sql",
                table: "Users",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                schema: "autistima_sa_sql",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                schema: "autistima_sa_sql",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                schema: "autistima_sa_sql",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroEndereco",
                schema: "autistima_sa_sql",
                table: "Users",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RG",
                schema: "autistima_sa_sql",
                table: "Users",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CPF",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Complemento",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Endereco",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NumeroEndereco",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RG",
                schema: "autistima_sa_sql",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(3140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 19, 21, 45, 354, DateTimeKind.Utc).AddTicks(3140));
        }
    }
}
