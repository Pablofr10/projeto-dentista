using Microsoft.EntityFrameworkCore.Migrations;

namespace Dentista.Infrastructure.Migrations
{
    public partial class MudandoFormapagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "forma_pagamento",
                table: "tb_pagamento",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "forma_pagamento",
                table: "tb_pagamento",
                type: "integer",
                maxLength: 2,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
