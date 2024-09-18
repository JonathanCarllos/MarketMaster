using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMaster.Migrations
{
    /// <inheritdoc />
    public partial class CarrinhoDeCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.CreateTable(
                name: "CarrinhoCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CarrinhoId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoCompras_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompras_ProdutoId",
                table: "CarrinhoCompras",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoCompras");           
        }
    }
}
