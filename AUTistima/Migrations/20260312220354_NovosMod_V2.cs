using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUTistima.Migrations
{
    /// <inheritdoc />
    public partial class NovosMod_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessibilityPreferences",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModoLeituraFacil = table.Column<bool>(type: "bit", nullable: false),
                    AudioDescricao = table.Column<bool>(type: "bit", nullable: false),
                    UsarPictogramas = table.Column<bool>(type: "bit", nullable: false),
                    AltoContraste = table.Column<bool>(type: "bit", nullable: false),
                    TamanhoFonte = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessibilityPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessibilityPreferences_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentReminders",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChildId = table.Column<int>(type: "int", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Local = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificacaoEnviada = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentReminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentReminders_Children_ChildId",
                        column: x => x.ChildId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AppointmentReminders_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditEvents",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Acao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Recurso = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Detalhes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditEvents_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BenefitChecklistItems",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TipoBeneficio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Concluido = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcluidoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitChecklistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitChecklistItems_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenefitEligibilities",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoBeneficio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Elegivel = table.Column<bool>(type: "bit", nullable: false),
                    Justificativa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitEligibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitEligibilities_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildCarePlans",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Objetivos = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Intervencoes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Terapias = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataRevisao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCarePlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCarePlans_Children_ChildId",
                        column: x => x.ChildId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyBadges",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nivel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Justificativa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ConquistadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBadges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyBadges_Users_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsentLogs",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoConsentimento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aceite = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Detalhes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsentLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsentLogs_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataDeletionRequests",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObsAdmin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataDeletionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataDeletionRequests_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataExportRequests",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DownloadUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataExportRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataExportRequests_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InclusiveJobs",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Acomodacoes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Localizacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Regime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SalarioMin = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    SalarioMax = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InclusiveJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InclusiveJobs_Users_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReporterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TargetType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TargetId = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResolvidoPorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ResolvidoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObsResolucao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Users_ReporterId",
                        column: x => x.ReporterId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Users_ResolvidoPorId",
                        column: x => x.ResolvidoPorId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SafetyPlans",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SinaisAlerta = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    EstrategiasDesescalada = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    RecursosLocais = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PlanoAposIntervencao = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyPlans_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    ChildId = table.Column<int>(type: "int", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RespondidoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RespostaServico = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Children_ChildId",
                        column: x => x.ChildId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChildProgresses",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    CarePlanId = table.Column<int>(type: "int", nullable: true),
                    TipoRegistro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    AnexoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildProgresses_ChildCarePlans_CarePlanId",
                        column: x => x.CarePlanId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "ChildCarePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ChildProgresses_Children_ChildId",
                        column: x => x.ChildId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContacts",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    SafetyPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyContacts_SafetyPlans_SafetyPlanId",
                        column: x => x.SafetyPlanId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "SafetyPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmergencyContacts_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAppointments",
                schema: "autistima_sa_sql",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Canal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LinkTeleatendimento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Local = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Confirmado = table.Column<bool>(type: "bit", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAppointments_ServiceRequests_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "autistima_sa_sql",
                        principalTable: "ServiceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(4630));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5080));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5080));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5080));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5080));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5240));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5060));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 13,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 14,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 15,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 16,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 17,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 18,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5080));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 19,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5080));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 20,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 21,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 22,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 23,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 24,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 25,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 26,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 27,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 28,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 29,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 30,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 31,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 32,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5240));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 33,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5240));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 34,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5240));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 35,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5240));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 36,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 37,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5260));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 38,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5260));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 39,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 40,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 41,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 42,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 43,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 44,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 45,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 46,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 47,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 48,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 49,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 50,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 51,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 52,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 53,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5300));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 54,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(5310));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 55,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6160));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 56,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6170));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 57,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6170));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 58,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6170));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 59,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 60,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 61,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 62,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 63,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6180));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 64,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 65,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 66,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 67,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 68,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 69,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6200));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 70,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6200));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 71,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6200));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 72,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6200));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 73,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6200));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 74,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6200));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 75,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6210));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 76,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6210));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 77,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6210));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 78,
                column: "DataCriacao",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 757, DateTimeKind.Utc).AddTicks(6210));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(6790));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(6850));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(6850));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(7310));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(7710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCadastro",
                value: new DateTime(2026, 3, 12, 22, 3, 52, 759, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.CreateIndex(
                name: "IX_AccessibilityPreferences_UserId",
                schema: "autistima_sa_sql",
                table: "AccessibilityPreferences",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentReminders_ChildId",
                schema: "autistima_sa_sql",
                table: "AppointmentReminders",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentReminders_DataHora",
                schema: "autistima_sa_sql",
                table: "AppointmentReminders",
                column: "DataHora");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentReminders_UserId",
                schema: "autistima_sa_sql",
                table: "AppointmentReminders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditEvents_Data",
                schema: "autistima_sa_sql",
                table: "AuditEvents",
                column: "Data");

            migrationBuilder.CreateIndex(
                name: "IX_AuditEvents_UserId",
                schema: "autistima_sa_sql",
                table: "AuditEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitChecklistItems_UserId",
                schema: "autistima_sa_sql",
                table: "BenefitChecklistItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitEligibilities_UserId",
                schema: "autistima_sa_sql",
                table: "BenefitEligibilities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCarePlans_ChildId",
                schema: "autistima_sa_sql",
                table: "ChildCarePlans",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildProgresses_CarePlanId",
                schema: "autistima_sa_sql",
                table: "ChildProgresses",
                column: "CarePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildProgresses_ChildId",
                schema: "autistima_sa_sql",
                table: "ChildProgresses",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBadges_EmpresaId",
                schema: "autistima_sa_sql",
                table: "CompanyBadges",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsentLogs_UserId",
                schema: "autistima_sa_sql",
                table: "ConsentLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataDeletionRequests_UserId",
                schema: "autistima_sa_sql",
                table: "DataDeletionRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataExportRequests_UserId",
                schema: "autistima_sa_sql",
                table: "DataExportRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_SafetyPlanId",
                schema: "autistima_sa_sql",
                table: "EmergencyContacts",
                column: "SafetyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_UserId",
                schema: "autistima_sa_sql",
                table: "EmergencyContacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InclusiveJobs_EmpresaId",
                schema: "autistima_sa_sql",
                table: "InclusiveJobs",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_InclusiveJobs_Status",
                schema: "autistima_sa_sql",
                table: "InclusiveJobs",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReporterId",
                schema: "autistima_sa_sql",
                table: "Reports",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ResolvidoPorId",
                schema: "autistima_sa_sql",
                table: "Reports",
                column: "ResolvidoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Status",
                schema: "autistima_sa_sql",
                table: "Reports",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyPlans_UserId",
                schema: "autistima_sa_sql",
                table: "SafetyPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAppointments_RequestId",
                schema: "autistima_sa_sql",
                table: "ServiceAppointments",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ChildId",
                schema: "autistima_sa_sql",
                table: "ServiceRequests",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ServiceId",
                schema: "autistima_sa_sql",
                table: "ServiceRequests",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_Status",
                schema: "autistima_sa_sql",
                table: "ServiceRequests",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_UserId",
                schema: "autistima_sa_sql",
                table: "ServiceRequests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessibilityPreferences",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "AppointmentReminders",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "AuditEvents",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "BenefitChecklistItems",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "BenefitEligibilities",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "ChildProgresses",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "CompanyBadges",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "ConsentLogs",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "DataDeletionRequests",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "DataExportRequests",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "EmergencyContacts",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "InclusiveJobs",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "Reports",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "ServiceAppointments",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "ChildCarePlans",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "SafetyPlans",
                schema: "autistima_sa_sql");

            migrationBuilder.DropTable(
                name: "ServiceRequests",
                schema: "autistima_sa_sql");

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
        }
    }
}
