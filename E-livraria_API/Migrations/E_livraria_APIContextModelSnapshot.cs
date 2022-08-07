﻿// <auto-generated />
using System;
using E_livraria_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_livraria_API.Migrations
{
    [DbContext(typeof(E_livraria_APIContext))]
    partial class E_livraria_APIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("E_livraria_API.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accType")
                        .HasColumnType("int");

                    b.Property<bool>("auth")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("id");

                    b.HasAlternateKey("login");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("E_livraria_API.Models.Editora", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accType")
                        .HasColumnType("int");

                    b.Property<bool>("auth")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("id");

                    b.HasAlternateKey("login");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("E_livraria_API.Models.ItemVenda", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Clienteid")
                        .HasColumnType("int");

                    b.Property<int>("idCliente")
                        .HasColumnType("int");

                    b.Property<int>("idLivros")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Clienteid");

                    b.ToTable("ItemVendas");
                });

            modelBuilder.Entity("E_livraria_API.Models.Livro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("autor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("editoraid")
                        .HasColumnType("int");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("imageURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("livroURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("preco")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("editoraid");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("E_livraria_API.Models.Venda", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("dataCompra")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("itemVendaid")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<double>("valor")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("itemVendaid");

                    b.ToTable("vendas");
                });

            modelBuilder.Entity("E_livraria_API.Models.ItemVenda", b =>
                {
                    b.HasOne("E_livraria_API.Models.Cliente", null)
                        .WithMany("itemVenda")
                        .HasForeignKey("Clienteid");
                });

            modelBuilder.Entity("E_livraria_API.Models.Livro", b =>
                {
                    b.HasOne("E_livraria_API.Models.Editora", "editora")
                        .WithMany("livros")
                        .HasForeignKey("editoraid");

                    b.Navigation("editora");
                });

            modelBuilder.Entity("E_livraria_API.Models.Venda", b =>
                {
                    b.HasOne("E_livraria_API.Models.ItemVenda", "itemVenda")
                        .WithMany()
                        .HasForeignKey("itemVendaid");

                    b.Navigation("itemVenda");
                });

            modelBuilder.Entity("E_livraria_API.Models.Cliente", b =>
                {
                    b.Navigation("itemVenda");
                });

            modelBuilder.Entity("E_livraria_API.Models.Editora", b =>
                {
                    b.Navigation("livros");
                });
#pragma warning restore 612, 618
        }
    }
}
