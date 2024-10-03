using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMaster.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompras_Produtos_ProdutoId",
                table: "CarrinhoCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalhes_Pedidos_PedidoId",
                table: "PedidoDetalhes");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalhes_Produtos_ProdutoId",
                table: "PedidoDetalhes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoDetalhes",
                table: "PedidoDetalhes");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "CarrinhoCompras");

            migrationBuilder.RenameTable(
                name: "PedidoDetalhes",
                newName: "PedidoDetalhe");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarrinhoCompras",
                newName: "CarrinhoCompraItemId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoDetalhes_ProdutoId",
                table: "PedidoDetalhe",
                newName: "IX_PedidoDetalhe_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoDetalhes_PedidoId",
                table: "PedidoDetalhe",
                newName: "IX_PedidoDetalhe_PedidoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "CarrinhoCompras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarrinhoCompraId",
                table: "CarrinhoCompras",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoDetalhe",
                table: "PedidoDetalhe",
                column: "PedidoDetalheId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompras_Produtos_ProdutoId",
                table: "CarrinhoCompras",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalhe_Pedidos_PedidoId",
                table: "PedidoDetalhe",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalhe_Produtos_ProdutoId",
                table: "PedidoDetalhe",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompras_Produtos_ProdutoId",
                table: "CarrinhoCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalhe_Pedidos_PedidoId",
                table: "PedidoDetalhe");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalhe_Produtos_ProdutoId",
                table: "PedidoDetalhe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoDetalhe",
                table: "PedidoDetalhe");

            migrationBuilder.DropColumn(
                name: "CarrinhoCompraId",
                table: "CarrinhoCompras");

            migrationBuilder.RenameTable(
                name: "PedidoDetalhe",
                newName: "PedidoDetalhes");

            migrationBuilder.RenameColumn(
                name: "CarrinhoCompraItemId",
                table: "CarrinhoCompras",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoDetalhe_ProdutoId",
                table: "PedidoDetalhes",
                newName: "IX_PedidoDetalhes_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoDetalhe_PedidoId",
                table: "PedidoDetalhes",
                newName: "IX_PedidoDetalhes_PedidoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "CarrinhoCompras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CarrinhoId",
                table: "CarrinhoCompras",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoDetalhes",
                table: "PedidoDetalhes",
                column: "PedidoDetalheId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompras_Produtos_ProdutoId",
                table: "CarrinhoCompras",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalhes_Pedidos_PedidoId",
                table: "PedidoDetalhes",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalhes_Produtos_ProdutoId",
                table: "PedidoDetalhes",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
