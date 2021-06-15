using Microsoft.EntityFrameworkCore.Migrations;

namespace Dentista.Infrastructure.Migrations
{
    public partial class RetirandoStatusEspecialidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tb_profissional_especialidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "tb_profissional_especialidade",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
