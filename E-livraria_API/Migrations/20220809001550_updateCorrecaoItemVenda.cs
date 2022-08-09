using Microsoft.EntityFrameworkCore.Migrations;

namespace E_livraria_API.Migrations
{
    public partial class updateCorrecaoItemVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idCliente",
                table: "ItemVendas");

            migrationBuilder.DropColumn(
                name: "idLivros",
                table: "ItemVendas");

            migrationBuilder.AddColumn<int>(
                name: "Livrosid",
                table: "ItemVendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendas_Livrosid",
                table: "ItemVendas",
                column: "Livrosid");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVendas_Livro_Livrosid",
                table: "ItemVendas",
                column: "Livrosid",
                principalTable: "Livro",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVendas_Livro_Livrosid",
                table: "ItemVendas");

            migrationBuilder.DropIndex(
                name: "IX_ItemVendas_Livrosid",
                table: "ItemVendas");

            migrationBuilder.DropColumn(
                name: "Livrosid",
                table: "ItemVendas");

            migrationBuilder.AddColumn<int>(
                name: "idCliente",
                table: "ItemVendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idLivros",
                table: "ItemVendas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
