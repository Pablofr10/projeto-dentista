using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dentista.Infrastructure.Migrations
{
    public partial class AlterandoNomeEntidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_exclusao",
                table: "tb_paciente");

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "tb_paciente",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ativo",
                table: "tb_paciente");

            migrationBuilder.AddColumn<DateTime>(
                name: "data_exclusao",
                table: "tb_paciente",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
