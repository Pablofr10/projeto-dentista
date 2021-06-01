using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dentista.Infrastructure.Migrations
{
    public partial class RestoreDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "tb_especialidade",
                table => new
                {
                    id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>("character varying(100)", maxLength: 100, nullable: false),
                    ativa = table.Column<bool>("boolean", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_tb_especialidade", x => x.id); });

            migrationBuilder.CreateTable(
                "tb_paciente",
                table => new
                {
                    id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>("character varying(100)", maxLength: 100, nullable: false),
                    endereco = table.Column<string>("character varying(100)", maxLength: 100, nullable: false),
                    cep = table.Column<int>("integer", maxLength: 8, nullable: false),
                    sexo = table.Column<string>("character varying(2)", maxLength: 2, nullable: false),
                    criado_em = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    cidade = table.Column<string>("character varying(30)", maxLength: 30, nullable: false),
                    telefone = table.Column<string>("character varying(11)", maxLength: 11, nullable: false),
                    celular = table.Column<string>("character varying(11)", maxLength: 11, nullable: false),
                    ativo = table.Column<bool>("boolean", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_tb_paciente", x => x.id); });

            migrationBuilder.CreateTable(
                "tb_pagamento",
                table => new
                {
                    id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    preco = table.Column<decimal>("numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    pago_em = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    status = table.Column<int>("integer", maxLength: 2, nullable: false),
                    forma_pagamento = table.Column<string>("character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_tb_pagamento", x => x.id); });

            migrationBuilder.CreateTable(
                "tb_profissional",
                table => new
                {
                    id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>("character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_tb_profissional", x => x.id); });

            migrationBuilder.CreateTable(
                "tb_consulta",
                table => new
                {
                    id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_consulta =
                        table.Column<DateTime>("timestamp without time zone", maxLength: 1, nullable: false),
                    criado_em = table.Column<DateTime>("timestamp without time zone", maxLength: 1, nullable: false),
                    status = table.Column<int>("integer", maxLength: 1, nullable: false),
                    id_pagamento = table.Column<int>("integer", nullable: false),
                    id_procedimento = table.Column<int>("integer", nullable: false),
                    id_profissional = table.Column<int>("integer", nullable: false),
                    id_paciente = table.Column<int>("integer", nullable: false),
                    PacienteId1 = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_consulta", x => x.id);
                    table.ForeignKey(
                        "FK_tb_consulta_tb_especialidade_id_procedimento",
                        x => x.id_procedimento,
                        "tb_especialidade",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_tb_consulta_tb_paciente_id_paciente",
                        x => x.id_paciente,
                        "tb_paciente",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_tb_consulta_tb_paciente_PacienteId1",
                        x => x.PacienteId1,
                        "tb_paciente",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_tb_consulta_tb_pagamento_id_pagamento",
                        x => x.id_pagamento,
                        "tb_pagamento",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_tb_consulta_tb_profissional_id_profissional",
                        x => x.id_profissional,
                        "tb_profissional",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "tb_procedimento_profissional",
                table => new
                {
                    id_profissional = table.Column<int>("integer", nullable: false),
                    id_procedimento = table.Column<int>("integer", nullable: false),
                    status = table.Column<bool>("boolean", nullable: false),
                    criado_em = table.Column<DateTime>("timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_procedimento_profissional",
                        x => new {x.id_procedimento, x.id_profissional});
                    table.ForeignKey(
                        "FK_tb_procedimento_profissional_tb_especialidade_id_procedimen~",
                        x => x.id_procedimento,
                        "tb_especialidade",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_tb_procedimento_profissional_tb_profissional_id_profissional",
                        x => x.id_profissional,
                        "tb_profissional",
                        "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_tb_consulta_id_paciente",
                "tb_consulta",
                "id_paciente");

            migrationBuilder.CreateIndex(
                "IX_tb_consulta_id_pagamento",
                "tb_consulta",
                "id_pagamento");

            migrationBuilder.CreateIndex(
                "IX_tb_consulta_id_procedimento",
                "tb_consulta",
                "id_procedimento");

            migrationBuilder.CreateIndex(
                "IX_tb_consulta_id_profissional",
                "tb_consulta",
                "id_profissional");

            migrationBuilder.CreateIndex(
                "IX_tb_consulta_PacienteId1",
                "tb_consulta",
                "PacienteId1");

            migrationBuilder.CreateIndex(
                "IX_tb_procedimento_profissional_id_profissional",
                "tb_procedimento_profissional",
                "id_profissional");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "tb_consulta");

            migrationBuilder.DropTable(
                "tb_procedimento_profissional");

            migrationBuilder.DropTable(
                "tb_paciente");

            migrationBuilder.DropTable(
                "tb_pagamento");

            migrationBuilder.DropTable(
                "tb_especialidade");

            migrationBuilder.DropTable(
                "tb_profissional");
        }
    }
}