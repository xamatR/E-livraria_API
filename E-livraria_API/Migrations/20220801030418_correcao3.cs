using Microsoft.EntityFrameworkCore.Migrations;

namespace E_livraria_API.Migrations
{
    public partial class correcao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Editoras_login",
                table: "Editoras",
                column: "login");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Clientes_login",
                table: "Clientes",
                column: "login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Editoras_login",
                table: "Editoras");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Clientes_login",
                table: "Clientes");
        }
    }
}
