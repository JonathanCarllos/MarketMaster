﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMaster.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Marca, Modelo, Preco, Custo, QuantidadeEmEstoque, Fornecedor, ImagemUrl, ImagemThumblenailUrl, Peso, Altura, Largura, Profundidade, Ativo, DataDeAdicao, ProdutoDestaque, CategoriaId) VALUES ('Lenovo T490', 'Notebook Lenovo T490 Core i5 8ªGen vPro ssd 256GB 8GB Win 10 Pro Usado', 'Lenovo', 'T490', 1701.00, 1900.00, 50, 'Lenovo Brasil', 'https://images-americanas.b2w.io/produtos/7482289565/imagens/notebook-lenovo-t490-core-i5-8-gen-vpro-ssd-256gb-8gb-win-10-pro-usado/7482289565_4_xlarge.jpg', 'https://www.americanas.com.br/produto/7482289565/notebook-lenovo-t490-core-i5-8agen-vpro-ssd-256gb-8gb-win-10-pro-usado?pfm_carac=os%20mais%20visitados%20da%20categoria&pfm_index=1&pfm_page=category&pfm_pos=category_page.rr2&pfm_type=vit_recommendation&DCSext.recom=RR_category_page.rr2-mars_TopVisitsCategory%3AP%3A100%3A%3Aads%3Dtrue%3AorderAdsTest%3Dmotor_high_ads%3Atestab%3DsingleStrategy&nm_origem=rec_category_page.rr2-mars_TopVisitsCategory%3AP%3A100%3A%3Aads%3Dtrue%3AorderAdsTest%3Dmotor_high_ads%3Atestab%3DsingleStrategy&nm_ranking_rec=1&chave=b2wads_66d75dc423a0400016a9ddf3_18638476000118_7482289565_599c7947-4861-43be-9295-be5ece98662a&sellerId=18638476000118&portfolio=rec&st=mars_TopVisitsCategory&pl=category_page.rr2&offerId=66d5fc72f85575c569693ff3#&gid=1&pid=1', 500, 20, 42, 0, 1, '2024-09-17', 1, 3)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from produtos");
        }
    }
}