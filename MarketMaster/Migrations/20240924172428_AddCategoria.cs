using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMaster.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categorias(Nome,Descricao) values('Informática e Acessórios','Procurando mouse sem fio, teclado, gabinete, monitor, pen drive e outros acessórios de informática? Na Americanas tem tuuudo de informática e acessórios para sua casa ou escritório, com os melhores preços e possibilidade de retirar diretamente na loja. Encontre impressoras, cartuchos, toner, scanner, roteador e adaptador wireless, projetores e muitos outros acessórios e peças para computador com descontos imperdíveis na nossa seleção. Vem ver ')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
        }
    }
}
