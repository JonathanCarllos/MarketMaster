using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMaster.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categorias(Nome,Descricao) values('Celular','Um smartphone é um dispositivo eletrônico que combina as funções de um telefone celular com as de um computador de bolso.')");
            migrationBuilder.Sql("Insert into Categorias(Nome,Descricao) values('Eletrodoméstico','aparelhos elétricos que facilitam as tarefas domésticas, como: Cozinhar e conservar alimentos, Limpar a casa, Tratar da roupa, Cuidados de beleza, Entretenimento.')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
        }
    }
}