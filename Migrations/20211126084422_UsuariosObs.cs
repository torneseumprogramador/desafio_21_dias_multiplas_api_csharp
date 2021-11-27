using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuarioAPI.Migrations
{
    public partial class UsuariosObs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "observacao",
                table: "usuarios",
                type: "text",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "observacao",
                table: "usuarios");
        }
    }
}
