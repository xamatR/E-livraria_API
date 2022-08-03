using Microsoft.EntityFrameworkCore.Migrations;

namespace E_livraria_API.Migrations
{
    public partial class correcaoItemVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_ItemVendas_ItemVendaid",
                table: "Livro");

            migrationBuilder.DropIndex(
                name: "IX_Livro_ItemVendaid",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "ItemVendaid",
                table: "Livro");

            migrationBuilder.AddColumn<int>(
                name: "livrosid",
                table: "ItemVendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendas_livrosid",
                table: "ItemVendas",
                column: "livrosid");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVendas_Livro_livrosid",
                table: "ItemVendas",
                column: "livrosid",
                principalTable: "Livro",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVendas_Livro_livrosid",
                table: "ItemVendas");

            migrationBuilder.DropIndex(
                name: "IX_ItemVendas_livrosid",
                table: "ItemVendas");

            migrationBuilder.DropColumn(
                name: "livrosid",
                table: "ItemVendas");

            migrationBuilder.AddColumn<int>(
                name: "ItemVendaid",
                table: "Livro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livro_ItemVendaid",
                table: "Livro",
                column: "ItemVendaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_ItemVendas_ItemVendaid",
                table: "Livro",
                column: "ItemVendaid",
                principalTable: "ItemVendas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
