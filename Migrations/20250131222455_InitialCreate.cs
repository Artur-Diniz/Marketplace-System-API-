using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace marktplace_sistem.Controllers.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CATEGORIAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORIAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLIENTES_CNPJ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nchar(14)", fixedLength: true, maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    data_Cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_UltimaCompra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTES_CNPJ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLIENTES_CPF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    data_Cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_UltimaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTES_CPF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_ESTOQUE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Produto = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Quantidade_reservada = table.Column<int>(type: "int", nullable: false),
                    Quantidade_disponivel = table.Column<int>(type: "int", nullable: false),
                    Ultima_Atualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESTOQUE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_FORNECEDORES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpj = table.Column<string>(type: "nchar(14)", fixedLength: true, maxLength: 14, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fornecedor_Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FORNECEDORES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UF = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<int>(type: "int", fixedLength: true, maxLength: 8, nullable: false),
                    Clientes_Cnpj_Id = table.Column<int>(type: "int", nullable: true),
                    Clientes_CPF_Id = table.Column<int>(type: "int", nullable: true),
                    Clientes_CPFId = table.Column<int>(type: "int", nullable: true),
                    Clientes_CnpjId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ENDERECOS_TB_CLIENTES_CNPJ_Clientes_CnpjId",
                        column: x => x.Clientes_CnpjId,
                        principalTable: "TB_CLIENTES_CNPJ",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_ENDERECOS_TB_CLIENTES_CNPJ_Clientes_Cnpj_Id",
                        column: x => x.Clientes_Cnpj_Id,
                        principalTable: "TB_CLIENTES_CNPJ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_ENDERECOS_TB_CLIENTES_CPF_Clientes_CPFId",
                        column: x => x.Clientes_CPFId,
                        principalTable: "TB_CLIENTES_CPF",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_ENDERECOS_TB_CLIENTES_CPF_Clientes_CPF_Id",
                        column: x => x.Clientes_CPF_Id,
                        principalTable: "TB_CLIENTES_CPF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_PEDIDOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Cliente_CPF = table.Column<int>(type: "int", nullable: true),
                    Id_Cliente_CNPJ = table.Column<int>(type: "int", nullable: true),
                    Preco_Frete = table.Column<double>(type: "float", nullable: false),
                    Data_Pedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Entrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valor_pedido = table.Column<double>(type: "float", nullable: false),
                    Forma_Pagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PEDIDOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PEDIDOS_TB_CLIENTES_CNPJ_Id_Cliente_CNPJ",
                        column: x => x.Id_Cliente_CNPJ,
                        principalTable: "TB_CLIENTES_CNPJ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_PEDIDOS_TB_CLIENTES_CPF_Id_Cliente_CPF",
                        column: x => x.Id_Cliente_CPF,
                        principalTable: "TB_CLIENTES_CPF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Image_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Produto_Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Estoque = table.Column<int>(type: "int", nullable: false),
                    Id_categoria = table.Column<int>(type: "int", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_ultimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PRODUTOS_TB_CATEGORIAS_Id_categoria",
                        column: x => x.Id_categoria,
                        principalTable: "TB_CATEGORIAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PRODUTOS_TB_ESTOQUE_Id_Estoque",
                        column: x => x.Id_Estoque,
                        principalTable: "TB_ESTOQUE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_COMPRAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_fornecedor = table.Column<int>(type: "int", nullable: false),
                    Id_produto = table.Column<int>(type: "int", nullable: false),
                    Qunatidade = table.Column<int>(type: "int", nullable: false),
                    preco_unitario = table.Column<double>(type: "float", nullable: false),
                    preco_total = table.Column<double>(type: "float", nullable: false),
                    preco_Frete = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    data_compra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COMPRAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_COMPRAS_TB_FORNECEDORES_Id_fornecedor",
                        column: x => x.Id_fornecedor,
                        principalTable: "TB_FORNECEDORES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_COMPRAS_TB_PRODUTOS_Id_produto",
                        column: x => x.Id_produto,
                        principalTable: "TB_PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_FORNECEDOR_PRODUTO",
                columns: table => new
                {
                    Id_Fornecedor = table.Column<int>(type: "int", nullable: false),
                    Id_Produto = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FORNECEDOR_PRODUTO", x => new { x.Id_Fornecedor, x.Id_Produto });
                    table.ForeignKey(
                        name: "FK_TB_FORNECEDOR_PRODUTO_TB_FORNECEDORES_Id_Fornecedor",
                        column: x => x.Id_Fornecedor,
                        principalTable: "TB_FORNECEDORES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_FORNECEDOR_PRODUTO_TB_PRODUTOS_Id_Produto",
                        column: x => x.Id_Produto,
                        principalTable: "TB_PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_HISTORICO_PRECOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_produto = table.Column<int>(type: "int", nullable: false),
                    preco_base = table.Column<double>(type: "float", nullable: false),
                    preco_venda = table.Column<double>(type: "float", nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_finalizou = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HISTORICO_PRECOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_HISTORICO_PRECOS_TB_PRODUTOS_Id_produto",
                        column: x => x.Id_produto,
                        principalTable: "TB_PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_IMPOSTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_produto = table.Column<int>(type: "int", nullable: false),
                    percentual = table.Column<double>(type: "float", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPOSTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_IMPOSTOS_TB_PRODUTOS_Id_produto",
                        column: x => x.Id_produto,
                        principalTable: "TB_PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ITENS_PEDIDOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_pedido = table.Column<int>(type: "int", nullable: false),
                    Id_produto = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    preco_unitario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ITENS_PEDIDOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ITENS_PEDIDOS_TB_PEDIDOS_Id_pedido",
                        column: x => x.Id_pedido,
                        principalTable: "TB_PEDIDOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ITENS_PEDIDOS_TB_PRODUTOS_Id_produto",
                        column: x => x.Id_produto,
                        principalTable: "TB_PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_LUCROS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_produto = table.Column<int>(type: "int", nullable: false),
                    preco_custo = table.Column<double>(type: "float", nullable: false),
                    margem_lucro_percentual = table.Column<double>(type: "float", nullable: false),
                    data_UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LUCROS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_LUCROS_TB_PRODUTOS_Id_produto",
                        column: x => x.Id_produto,
                        principalTable: "TB_PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRECOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_produto = table.Column<int>(type: "int", nullable: false),
                    preco_base = table.Column<double>(type: "float", nullable: false),
                    preco_venda = table.Column<double>(type: "float", nullable: false),
                    preco_promocional = table.Column<double>(type: "float", nullable: false),
                    data_inicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_promo_inicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_promo_final = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRECOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PRECOS_TB_PRODUTOS_Id_produto",
                        column: x => x.Id_produto,
                        principalTable: "TB_PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_CATEGORIAS",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Camisas e camisetas", "Camisetas" },
                    { 2, "Calças e Shorts", "Calcas" }
                });

            migrationBuilder.InsertData(
                table: "TB_CLIENTES_CNPJ",
                columns: new[] { "Id", "Cnpj", "Email", "Nome", "Status", "Telefone", "data_Cadastro", "data_UltimaCompra" },
                values: new object[,]
                {
                    { 1, "12312312312342", "jon@gmail.com", "Jon", 1, 23312344, new DateTime(2025, 1, 31, 19, 24, 54, 680, DateTimeKind.Local).AddTicks(9952), null },
                    { 2, "42123123123123", "bob@gmail.com", "Bob", 1, 44233123, new DateTime(2025, 1, 31, 19, 24, 54, 683, DateTimeKind.Local).AddTicks(6335), null }
                });

            migrationBuilder.InsertData(
                table: "TB_CLIENTES_CPF",
                columns: new[] { "Id", "CPF", "Email", "Nome", "Status", "Telefone", "data_Cadastro", "data_UltimaCompra" },
                values: new object[,]
                {
                    { 1, "23421231231231", "julian@gmail.com", "Julian", 1, 23312344, new DateTime(2025, 1, 31, 19, 24, 54, 683, DateTimeKind.Local).AddTicks(9367), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "31234212312312", "thomas@gmail.com", "Thomas", 1, 44233117, new DateTime(2025, 1, 31, 19, 24, 54, 683, DateTimeKind.Local).AddTicks(9650), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TB_ESTOQUE",
                columns: new[] { "Id", "Id_Produto", "Quantidade", "Quantidade_disponivel", "Quantidade_reservada", "Ultima_Atualizacao" },
                values: new object[,]
                {
                    { 1, 1, 20, 20, 0, new DateTime(2025, 1, 31, 19, 24, 54, 685, DateTimeKind.Local).AddTicks(400) },
                    { 2, 1, 36, 36, 0, new DateTime(2025, 1, 31, 19, 24, 54, 685, DateTimeKind.Local).AddTicks(663) }
                });

            migrationBuilder.InsertData(
                table: "TB_FORNECEDORES",
                columns: new[] { "Id", "Email", "Fornecedor_Ativo", "Nome", "Telefone", "cnpj" },
                values: new object[,]
                {
                    { 1, "jonas@gmail.com", true, "Jonas", 1124311717, "12312312312321" },
                    { 2, "Jonathan@gmail.com", true, "Jonathan", 1124311743, "32132132132123" }
                });

            migrationBuilder.InsertData(
                table: "TB_ENDERECOS",
                columns: new[] { "Id", "Bairro", "Cep", "Cidade", "Clientes_CPFId", "Clientes_CPF_Id", "Clientes_CnpjId", "Clientes_Cnpj_Id", "Complemento", "Logradouro", "Pais", "UF", "numero" },
                values: new object[,]
                {
                    { 1, "Vila Maria", 49107174, "São Paulo", null, 1, null, null, "", "Av. Guilherme Cottin", "Brasil", "SP", 62 },
                    { 2, "Centro", 74491071, "Sorocaba", null, null, null, 1, "", "Av. São Pedro ", "Brasil", "SP", 65 }
                });

            migrationBuilder.InsertData(
                table: "TB_PEDIDOS",
                columns: new[] { "Id", "Data_Entrega", "Data_Pedido", "Forma_Pagamento", "Id_Cliente_CNPJ", "Id_Cliente_CPF", "Preco_Frete", "Valor_pedido" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 31, 19, 24, 54, 686, DateTimeKind.Local).AddTicks(9414), new DateTime(2025, 1, 31, 19, 24, 54, 686, DateTimeKind.Local).AddTicks(9153), 2, 0, 1, 19.0, 44.0 },
                    { 2, new DateTime(2025, 1, 31, 19, 24, 54, 686, DateTimeKind.Local).AddTicks(9957), new DateTime(2025, 1, 31, 19, 24, 54, 686, DateTimeKind.Local).AddTicks(9954), 1, 1, 0, 10.0, 99.980000000000004 }
                });

            migrationBuilder.InsertData(
                table: "TB_PRODUTOS",
                columns: new[] { "Id", "Codigo", "Cor", "Id_Estoque", "Id_categoria", "Image_Url", "Nome", "Produto_Ativo", "Tamanho", "data_criacao", "data_ultimaAlteracao" },
                values: new object[,]
                {
                    { 1, 100001, "Preto", 0, 1, "camiseta_polo_Preta.com.br", "Camisa Polo Gola V", true, "Médio", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 100002, "Branco", 0, 1, "camiseta_polo_Branca.com.br", "Camisa Polo", true, "Médio", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TB_COMPRAS",
                columns: new[] { "Id", "Id_fornecedor", "Id_produto", "Qunatidade", "Status", "data_compra", "preco_Frete", "preco_total", "preco_unitario" },
                values: new object[,]
                {
                    { 1, 1, 1, 20, 4, new DateTime(2025, 1, 31, 19, 24, 54, 684, DateTimeKind.Local).AddTicks(610), 120.0, 360.0, 12.0 },
                    { 2, 2, 2, 36, 4, new DateTime(2025, 1, 31, 19, 24, 54, 684, DateTimeKind.Local).AddTicks(2681), 120.0, 480.0, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "TB_FORNECEDOR_PRODUTO",
                columns: new[] { "Id_Fornecedor", "Id_Produto", "Descricao" },
                values: new object[,]
                {
                    { 1, 1, "Camisestas com melhor custo beneficios" },
                    { 2, 2, "Camisestas de Luxo" }
                });

            migrationBuilder.InsertData(
                table: "TB_HISTORICO_PRECOS",
                columns: new[] { "Id", "Id_produto", "Motivo", "data_finalizou", "data_inicio", "preco_base", "preco_venda" },
                values: new object[,]
                {
                    { 1, 1, "preço está dando prejuizo a loja", new DateTime(2025, 1, 31, 19, 24, 54, 686, DateTimeKind.Local).AddTicks(2649), new DateTime(2025, 1, 31, 19, 24, 54, 686, DateTimeKind.Local).AddTicks(2344), 20.010000000000002, 22.0 },
                    { 2, 1, "", null, new DateTime(2025, 1, 31, 19, 24, 54, 686, DateTimeKind.Local).AddTicks(3850), 20.010000000000002, 49.990000000000002 }
                });

            migrationBuilder.InsertData(
                table: "TB_IMPOSTOS",
                columns: new[] { "Id", "Id_produto", "data_inicio", "percentual", "status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 31, 19, 24, 54, 686, DateTimeKind.Local).AddTicks(4847), 17.0, true },
                    { 2, 2, new DateTime(2025, 1, 31, 19, 24, 54, 686, DateTimeKind.Local).AddTicks(5594), 20.0, true }
                });

            migrationBuilder.InsertData(
                table: "TB_ITENS_PEDIDOS",
                columns: new[] { "Id", "Id_pedido", "Id_produto", "preco_unitario", "quantidade" },
                values: new object[,]
                {
                    { 1, 1, 1, 22.0, 2 },
                    { 2, 1, 1, 49.990000000000002, 1 }
                });

            migrationBuilder.InsertData(
                table: "TB_LUCROS",
                columns: new[] { "Id", "Id_produto", "data_UltimaAtualizacao", "margem_lucro_percentual", "preco_custo" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 31, 19, 24, 54, 687, DateTimeKind.Local).AddTicks(1002), 40.0, 20.0 },
                    { 2, 2, new DateTime(2025, 1, 31, 19, 24, 54, 687, DateTimeKind.Local).AddTicks(1749), 36.0, 15.0 }
                });

            migrationBuilder.InsertData(
                table: "TB_PRECOS",
                columns: new[] { "Id", "Id_produto", "Status", "data_fim", "data_inicial", "data_promo_final", "data_promo_inicial", "preco_base", "preco_promocional", "preco_venda" },
                values: new object[,]
                {
                    { 1, 1, 3, new DateTime(2025, 1, 31, 19, 24, 54, 687, DateTimeKind.Local).AddTicks(3443), new DateTime(2025, 1, 31, 19, 24, 54, 687, DateTimeKind.Local).AddTicks(3179), new DateTime(2025, 1, 31, 19, 24, 54, 687, DateTimeKind.Local).AddTicks(4081), new DateTime(2025, 1, 31, 19, 24, 54, 687, DateTimeKind.Local).AddTicks(3691), 20.010000000000002, 21.0, 22.0 },
                    { 2, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 31, 19, 24, 54, 687, DateTimeKind.Local).AddTicks(4894), new DateTime(2025, 1, 31, 19, 24, 54, 687, DateTimeKind.Local).AddTicks(4898), new DateTime(2025, 1, 31, 19, 24, 54, 687, DateTimeKind.Local).AddTicks(4897), 20.010000000000002, 29.989999999999998, 49.990000000000002 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_COMPRAS_Id_fornecedor",
                table: "TB_COMPRAS",
                column: "Id_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_TB_COMPRAS_Id_produto",
                table: "TB_COMPRAS",
                column: "Id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECOS_Clientes_Cnpj_Id",
                table: "TB_ENDERECOS",
                column: "Clientes_Cnpj_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECOS_Clientes_CnpjId",
                table: "TB_ENDERECOS",
                column: "Clientes_CnpjId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECOS_Clientes_CPF_Id",
                table: "TB_ENDERECOS",
                column: "Clientes_CPF_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECOS_Clientes_CPFId",
                table: "TB_ENDERECOS",
                column: "Clientes_CPFId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_FORNECEDOR_PRODUTO_Id_Produto",
                table: "TB_FORNECEDOR_PRODUTO",
                column: "Id_Produto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORICO_PRECOS_Id_produto",
                table: "TB_HISTORICO_PRECOS",
                column: "Id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_IMPOSTOS_Id_produto",
                table: "TB_IMPOSTOS",
                column: "Id_produto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ITENS_PEDIDOS_Id_pedido",
                table: "TB_ITENS_PEDIDOS",
                column: "Id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ITENS_PEDIDOS_Id_produto",
                table: "TB_ITENS_PEDIDOS",
                column: "Id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_LUCROS_Id_produto",
                table: "TB_LUCROS",
                column: "Id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDOS_Id_Cliente_CNPJ",
                table: "TB_PEDIDOS",
                column: "Id_Cliente_CNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDOS_Id_Cliente_CPF",
                table: "TB_PEDIDOS",
                column: "Id_Cliente_CPF");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRECOS_Id_produto",
                table: "TB_PRECOS",
                column: "Id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTOS_Id_categoria",
                table: "TB_PRODUTOS",
                column: "Id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTOS_Id_Estoque",
                table: "TB_PRODUTOS",
                column: "Id_Estoque",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_COMPRAS");

            migrationBuilder.DropTable(
                name: "TB_ENDERECOS");

            migrationBuilder.DropTable(
                name: "TB_FORNECEDOR_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_HISTORICO_PRECOS");

            migrationBuilder.DropTable(
                name: "TB_IMPOSTOS");

            migrationBuilder.DropTable(
                name: "TB_ITENS_PEDIDOS");

            migrationBuilder.DropTable(
                name: "TB_LUCROS");

            migrationBuilder.DropTable(
                name: "TB_PRECOS");

            migrationBuilder.DropTable(
                name: "TB_FORNECEDORES");

            migrationBuilder.DropTable(
                name: "TB_PEDIDOS");

            migrationBuilder.DropTable(
                name: "TB_PRODUTOS");

            migrationBuilder.DropTable(
                name: "TB_CLIENTES_CNPJ");

            migrationBuilder.DropTable(
                name: "TB_CLIENTES_CPF");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIAS");

            migrationBuilder.DropTable(
                name: "TB_ESTOQUE");
        }
    }
}
