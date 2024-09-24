﻿// <auto-generated />
using System;
using MarketMaster.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarketMaster.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240924172611_AddNewProduto")]
    partial class AddNewProduto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("MarketMaster.Models.CarrinhoCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarrinhoId")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("CarrinhoCompras");
                });

            modelBuilder.Entity("MarketMaster.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("MarketMaster.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Custo")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("DataDeAdicao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Fornecedor")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ImagemThumblenailUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Largura")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Marca")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("ProdutoDestaque")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Profundidade")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("QuantidadeEmEstoque")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("MarketMaster.Models.CarrinhoCompra", b =>
                {
                    b.HasOne("MarketMaster.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MarketMaster.Models.Categoria", b =>
                {
                    b.HasOne("MarketMaster.Models.Categoria", null)
                        .WithMany("Categorias")
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("MarketMaster.Models.Produto", b =>
                {
                    b.HasOne("MarketMaster.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("MarketMaster.Models.Categoria", b =>
                {
                    b.Navigation("Categorias");
                });
#pragma warning restore 612, 618
        }
    }
}
