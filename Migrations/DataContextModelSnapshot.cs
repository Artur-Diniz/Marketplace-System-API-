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

            modelBuilder.Entity("marktplace_sistem.models.Clientes_CPF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .IsFixedLength();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_Cadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_UltimaCompra")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_CLIENTES_CPF");
                });

            modelBuilder.Entity("marktplace_sistem.models.Clientes_Cnpj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nchar(14)")
                        .IsFixedLength();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_Cadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_UltimaCompra")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_CLIENTES_CNPJ");
                });

            modelBuilder.Entity("marktplace_sistem.models.Compras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_fornecedor")
                        .HasColumnType("int");

                    b.Property<int>("Id_produto")
                        .HasColumnType("int");

                    b.Property<int>("Qunatidade")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_compra")
                        .HasColumnType("datetime2");

                    b.Property<double>("preco_Frete")
                        .HasColumnType("float");

                    b.Property<double>("preco_total")
                        .HasColumnType("float");

                    b.Property<double>("preco_unitario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Id_fornecedor");

                    b.HasIndex("Id_produto");

                    b.ToTable("TB_COMPRAS");
                });

            modelBuilder.Entity("marktplace_sistem.models.Enderecos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Clientes_CPF_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Clientes_Cnpj_Id")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nchar(2)")
                        .IsFixedLength();

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TB_ENDERECOS");
                });

            modelBuilder.Entity("marktplace_sistem.models.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_Produto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade_disponivel")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade_reservada")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ultima_Atualicacao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_ESTOQUE");
                });

            modelBuilder.Entity("marktplace_sistem.models.Fornecedor_Produto", b =>
                {
                    b.Property<int>("Id_Fornecedor")
                        .HasColumnType("int");

                    b.Property<int>("Id_Produto")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Fornecedor", "Id_Produto");

                    b.HasIndex("Id_Produto");

                    b.ToTable("TB_FORNECEDOR_PRODUTO");
                });

            modelBuilder.Entity("marktplace_sistem.models.Fornecedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Fornecedor_Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.Property<string>("cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nchar(14)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("TB_FORNEDORES");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jonas@gmail.com",
                            Fornecedor_Ativo = true,
                            Nome = "Jonas",
                            Telefone = 1124311717,
                            cnpj = "12312312312321"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Jonathan@gmail.com",
                            Fornecedor_Ativo = true,
                            Nome = "Jonathan",
                            Telefone = 1124311743,
                            cnpj = "32132132132123"
                        });
                });

            modelBuilder.Entity("marktplace_sistem.models.Historico_precos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_produto")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("data_finalizou")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_inicio")
                        .HasColumnType("datetime2");

                    b.Property<double>("preco_base")
                        .HasColumnType("float");

                    b.Property<double>("preco_venda")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Id_produto");

                    b.ToTable("TB_HISTORICO_PRECOS");
                });

            modelBuilder.Entity("marktplace_sistem.models.Impostos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_produto")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_inicio")
                        .HasColumnType("datetime2");

                    b.Property<double>("percentual")
                        .HasColumnType("float");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id_produto")
                        .IsUnique();

                    b.ToTable("TB_IMPOSTOS");
                });

            modelBuilder.Entity("marktplace_sistem.models.Itens_Pedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_pedido")
                        .HasColumnType("int");

                    b.Property<int>("Id_produto")
                        .HasColumnType("int");

                    b.Property<int>("preco_unitario")
                        .HasColumnType("int");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_pedido");

                    b.HasIndex("Id_produto");

                    b.ToTable("TB_INTES_PEDIDOS");
                });

            modelBuilder.Entity("marktplace_sistem.models.Lucros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_produto")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_UltimaAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<double>("margem_lucro_percentual")
                        .HasColumnType("float");

                    b.Property<double>("preco_custo")
                        .HasColumnType("float");

                    b.Property<double>("preco_unitario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Id_produto");

                    b.ToTable("TB_LUCROS");
                });

            modelBuilder.Entity("marktplace_sistem.models.Pedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data_Entrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Pedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("Forma_Pagamento")
                        .HasColumnType("int");

                    b.Property<int?>("Id_Cliente_CNPJ")
                        .HasColumnType("int");

                    b.Property<int?>("Id_Cliente_CPF")
                        .HasColumnType("int");

                    b.Property<double>("Preco_Frete")
                        .HasColumnType("float");

                    b.Property<double>("Valor_pedido")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Id_Cliente_CNPJ");

                    b.HasIndex("Id_Cliente_CPF");

                    b.ToTable("TB_PEDIDOS");
                });

            modelBuilder.Entity("marktplace_sistem.models.Precos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_produto")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_inicial")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_promo_final")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_promo_inicial")
                        .HasColumnType("datetime2");

                    b.Property<double>("preco_base")
                        .HasColumnType("float");

                    b.Property<double>("preco_promocional")
                        .HasColumnType("float");

                    b.Property<double>("preco_venda")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("TB_PRECOS");
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

                    b.Property<string>("Cor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_Estoque")
                        .HasColumnType("int");

                    b.Property<int>("Id_Precos")
                        .HasColumnType("int");

                    b.Property<string>("Image_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Produto_Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Tamanho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("data_criacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_ultimaAlteracao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Categoria_Id");

                    b.HasIndex("Id_Estoque")
                        .IsUnique();

                    b.HasIndex("Id_Precos")
                        .IsUnique();

                    b.ToTable("TB_PRODUTOS");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Categoria_Id = 1,
                            Codigo = 100001,
                            Cor = "Preto",
                            Id_Estoque = 0,
                            Id_Precos = 0,
                            Image_Url = "camiseta_polo_Preta.com.br",
                            Nome = "Camisa Polo Gola V",
                            Produto_Ativo = true,
                            Tamanho = "Médio",
                            data_criacao = new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            data_ultimaAlteracao = new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Categoria_Id = 1,
                            Codigo = 100002,
                            Cor = "Branco",
                            Id_Estoque = 0,
                            Id_Precos = 0,
                            Image_Url = "camiseta_polo_Branca.com.br",
                            Nome = "Camisa Polo",
                            Produto_Ativo = true,
                            Tamanho = "Médio",
                            data_criacao = new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            data_ultimaAlteracao = new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("marktplace_sistem.models.Compras", b =>
                {
                    b.HasOne("marktplace_sistem.models.Fornecedores", "Fornecedores")
                        .WithMany("Compras")
                        .HasForeignKey("Id_fornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("marktplace_sistem.models.Produto", "Produto")
                        .WithMany("Compras")
                        .HasForeignKey("Id_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedores");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("marktplace_sistem.models.Fornecedor_Produto", b =>
                {
                    b.HasOne("marktplace_sistem.models.Fornecedores", "Fornecedores")
                        .WithMany("Fornecedor_Produto")
                        .HasForeignKey("Id_Fornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("marktplace_sistem.models.Produto", "Produto")
                        .WithMany("Fornecedor_Produto")
                        .HasForeignKey("Id_Produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedores");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("marktplace_sistem.models.Historico_precos", b =>
                {
                    b.HasOne("marktplace_sistem.models.Produto", "Produto")
                        .WithMany("Historico_Precos")
                        .HasForeignKey("Id_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("marktplace_sistem.models.Impostos", b =>
                {
                    b.HasOne("marktplace_sistem.models.Produto", "Produto")
                        .WithOne("Impostos")
                        .HasForeignKey("marktplace_sistem.models.Impostos", "Id_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("marktplace_sistem.models.Itens_Pedidos", b =>
                {
                    b.HasOne("marktplace_sistem.models.Pedidos", "Pedidos")
                        .WithMany("Itens_Pedidos")
                        .HasForeignKey("Id_pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("marktplace_sistem.models.Produto", "Produto")
                        .WithMany("Itens_Pedidos")
                        .HasForeignKey("Id_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedidos");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("marktplace_sistem.models.Lucros", b =>
                {
                    b.HasOne("marktplace_sistem.models.Produto", "Produto")
                        .WithMany("Lucros")
                        .HasForeignKey("Id_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("marktplace_sistem.models.Pedidos", b =>
                {
                    b.HasOne("marktplace_sistem.models.Clientes_Cnpj", "Clientes_CNPJ")
                        .WithMany()
                        .HasForeignKey("Id_Cliente_CNPJ")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("marktplace_sistem.models.Clientes_CPF", "Clientes_CPF")
                        .WithMany()
                        .HasForeignKey("Id_Cliente_CPF")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Clientes_CNPJ");

                    b.Navigation("Clientes_CPF");
                });

            modelBuilder.Entity("marktplace_sistem.models.Produto", b =>
                {
                    b.HasOne("marktplace_sistem.models.Categoria", "categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("Categoria_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("marktplace_sistem.models.Estoque", "Estoque")
                        .WithOne("Produto")
                        .HasForeignKey("marktplace_sistem.models.Produto", "Id_Estoque")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("marktplace_sistem.models.Precos", "Precos")
                        .WithOne("Produto")
                        .HasForeignKey("marktplace_sistem.models.Produto", "Id_Precos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estoque");

                    b.Navigation("Precos");

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("marktplace_sistem.models.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("marktplace_sistem.models.Estoque", b =>
                {
                    b.Navigation("Produto");
                });

            modelBuilder.Entity("marktplace_sistem.models.Fornecedores", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("Fornecedor_Produto");
                });

            modelBuilder.Entity("marktplace_sistem.models.Pedidos", b =>
                {
                    b.Navigation("Itens_Pedidos");
                });

            modelBuilder.Entity("marktplace_sistem.models.Precos", b =>
                {
                    b.Navigation("Produto");
                });

            modelBuilder.Entity("marktplace_sistem.models.Produto", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("Fornecedor_Produto");

                    b.Navigation("Historico_Precos");

                    b.Navigation("Impostos");

                    b.Navigation("Itens_Pedidos");

                    b.Navigation("Lucros");
                });
#pragma warning restore 612, 618
        }
    }
}
