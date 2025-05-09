﻿﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMaster.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Marca, Modelo, Preco, Custo, QuantidadeEmEstoque, Fornecedor, ImagemUrl, ImagemThumblenailUrl, Peso, Altura, Largura, Profundidade, Ativo, DataDeAdicao, ProdutoDestaque, CategoriaId) VALUES ('Iphone 16', 'O iPhone 16 terá uma tela de 6,1 polegadas, o modelo Plus, 6,7 polegadas; o iPhone 16 Pro tem 6,3 polegadas, enquanto a versão Pro Max conta com uma tela de 6,9 polegadas', 'Apple', 'A18', 7799.00, 9000.00, 50, 'Apple Brasil', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQnCk3PA5tYZXdBzPcVkqfIXj3u6fdBjUokm7wX50mZjn0rbXVHxFeHw92qI4BE-nrM2Fwz_sUBV6xAkqH4WJBGRgKBRTZbwz3CH1znEbD6E4jRPy9OHfNY', 'https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone16-digitalmat-gallery-3-202409?wid=728&hei=666&fmt=jpeg&qlt=90&.v=1723669127642', 170, 147.6, 71.6, 7.80, 1, '2024-09-17', 1, 1)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from produtos");
        }
    }
}