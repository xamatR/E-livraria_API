using Microsoft.EntityFrameworkCore.Migrations;

namespace E_livraria_API.Migrations
{
    public partial class correcaoNova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVendas_Clientes_clienteid",
                table: "ItemVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemVendas_Livro_livrosid",
                table: "ItemVendas");

            migrationBuilder.DropIndex(
                name: "IX_ItemVendas_livrosid",
                table: "ItemVendas");

            migrationBuilder.DropColumn(
                name: "livrosid",
                table: "ItemVendas");

            migrationBuilder.RenameColumn(
                name: "clienteid",
                table: "ItemVendas",
                newName: "Clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVendas_clienteid",
                table: "ItemVendas",
                newName: "IX_ItemVendas_Clienteid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVendas_Clientes_Clienteid",
                table: "ItemVendas",
                column: "Clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVendas_Clientes_Clienteid",
                table: "ItemVendas");

            migrationBuilder.DropColumn(
                name: "idCliente",
                table: "ItemVendas");

            migrationBuilder.DropColumn(
                name: "idLivros",
                table: "ItemVendas");

            migrationBuilder.RenameColumn(
                name: "Clienteid",
                table: "ItemVendas",
                newName: "clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVendas_Clienteid",
                table: "ItemVendas",
                newName: "IX_ItemVendas_clienteid");

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
                name: "FK_ItemVendas_Clientes_clienteid",
                table: "ItemVendas",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVendas_Livro_livrosid",
                table: "ItemVendas",
                column: "livrosid",
                principalTable: "Livro",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
