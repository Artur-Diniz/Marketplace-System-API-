﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using marktplace_sistem.Data;

#nullable disable

namespace marktplace_sistem.Controllers.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("marktplace_sistem.models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_CATEGORIAS");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Camisas e camisetas",
                            Nome = "Camisetas"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Calças e Shorts",
                            Nome = "Calcas"
                        });
                });

            modelBuilder.Entity("marktplace_sistem.models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Categoria_Id")
                        .HasColumnType("int");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Image_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Produto_Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("data_criacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_ultimaAlteracao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_PRODUTOS");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Categoria_Id = 1,
                            Codigo = 100001,
                            Image_Url = "camiseta_polo_Preta.com.br",
                            Nome = "Camisa Polo Branca",
                            Produto_Ativo = true,
                            data_criacao = new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            data_ultimaAlteracao = new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Categoria_Id = 1,
                            Codigo = 100001,
                            Image_Url = "camiseta_polo_Branca.com.br",
                            Nome = "Camisa Polo preto ",
                            Produto_Ativo = true,
                            data_criacao = new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            data_ultimaAlteracao = new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
