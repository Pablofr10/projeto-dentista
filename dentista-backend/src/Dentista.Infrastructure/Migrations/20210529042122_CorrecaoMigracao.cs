using Microsoft.EntityFrameworkCore.Migrations;

namespace Dentista.Infrastructure.Migrations
{
    public partial class CorrecaoMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId",
                table: "tb_consulta");

            migrationBuilder.DropColumn(
                name: "NomeDentista",
                table: "tb_consulta");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "tb_paciente",
                newName: "cep");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "tb_consulta",
                newName: "id_paciente");

            migrationBuilder.RenameColumn(
                name: "DataConsulta",
                table: "tb_consulta",
                newName: "data_consulta");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "tb_consulta",
                newName: "criado_em");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_PacienteId",
                table: "tb_consulta",
                newName: "IX_tb_consulta_id_paciente");

            migrationBuilder.AlterColumn<int>(
                name: "id_paciente",
                table: "tb_consulta",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId1",
                table: "tb_consulta",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_PacienteId1",
                table: "tb_consulta",
                column: "PacienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta",
                column: "id_paciente",
                principalTable: "tb_paciente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId1",
                table: "tb_consulta",
                column: "PacienteId1",
                principalTable: "tb_paciente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId1",
                table: "tb_consulta");

            migrationBuilder.DropIndex(
                name: "IX_tb_consulta_PacienteId1",
                table: "tb_consulta");

            migrationBuilder.DropColumn(
                name: "PacienteId1",
                table: "tb_consulta");

            migrationBuilder.RenameColumn(
                name: "cep",
                table: "tb_paciente",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "id_paciente",
                table: "tb_consulta",
                newName: "PacienteId");

            migrationBuilder.RenameColumn(
                name: "data_consulta",
                table: "tb_consulta",
                newName: "DataConsulta");

            migrationBuilder.RenameColumn(
                name: "criado_em",
                table: "tb_consulta",
                newName: "CriadoEm");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_id_paciente",
                table: "tb_consulta",
                newName: "IX_tb_consulta_PacienteId");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "tb_consulta",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "NomeDentista",
                table: "tb_consulta",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId",
                table: "tb_consulta",
                column: "PacienteId",
                principalTable: "tb_paciente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
