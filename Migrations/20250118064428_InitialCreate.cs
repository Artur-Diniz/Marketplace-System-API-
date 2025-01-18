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
                    data_UltimaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Clientes_Cnpj_Id = table.Column<int>(type: "int", nullable: true),
                    Clientes_CPF_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECOS", x => x.Id);
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
                    Ultima_Atualicacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESTOQUE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_FORNEDORES",
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
                    table.PrimaryKey("PK_TB_FORNEDORES", x => x.Id);
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
                    Data_Entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Categoria_Id = table.Column<int>(type: "int", nullable: false),
                    Image_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Produto_Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Estoque = table.Column<int>(type: "int", nullable: false),
                    Id_Precos = table.Column<int>(type: "int", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_ultimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PRODUTOS_TB_CATEGORIAS_Categoria_Id",
                        column: x => x.Categoria_Id,
                        principalTable: "TB_CATEGORIAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PRODUTOS_TB_ESTOQUE_Id_Estoque",
                        column: x => x.Id_Estoque,
                        principalTable: "TB_ESTOQUE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PRODUTOS_TB_PRECOS_Id_Precos",
                        column: x => x.Id_Precos,
                        principalTable: "TB_PRECOS",
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
                        name: "FK_TB_COMPRAS_TB_FORNEDORES_Id_fornecedor",
                        column: x => x.Id_fornecedor,
                        principalTable: "TB_FORNEDORES",
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
                    Id_Produto = table.Column<int>(type: "int", nullable: false),
                    Id_Fornecedor = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FORNECEDOR_PRODUTO", x => new { x.Id_Fornecedor, x.Id_Produto });
                    table.ForeignKey(
                        name: "FK_TB_FORNECEDOR_PRODUTO_TB_FORNEDORES_Id_Fornecedor",
                        column: x => x.Id_Fornecedor,
                        principalTable: "TB_FORNEDORES",
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
                    data_finalizou = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "TB_INTES_PEDIDOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_pedido = table.Column<int>(type: "int", nullable: false),
                    Id_produto = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    preco_unitario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_INTES_PEDIDOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_INTES_PEDIDOS_TB_PEDIDOS_Id_pedido",
                        column: x => x.Id_pedido,
                        principalTable: "TB_PEDIDOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_INTES_PEDIDOS_TB_PRODUTOS_Id_produto",
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
                    preco_unitario = table.Column<double>(type: "float", nullable: false),
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

            migrationBuilder.InsertData(
                table: "TB_CATEGORIAS",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Camisas e camisetas", "Camisetas" },
                    { 2, "Calças e Shorts", "Calcas" }
                });

            migrationBuilder.InsertData(
                table: "TB_FORNEDORES",
                columns: new[] { "Id", "Email", "Fornecedor_Ativo", "Nome", "Telefone", "cnpj" },
                values: new object[,]
                {
                    { 1, "jonas@gmail.com", true, "Jonas", 1124311717, "12312312312321" },
                    { 2, "Jonathan@gmail.com", true, "Jonathan", 1124311743, "32132132132123" }
                });

            migrationBuilder.InsertData(
                table: "TB_PRODUTOS",
                columns: new[] { "Id", "Categoria_Id", "Codigo", "Cor", "Id_Estoque", "Id_Precos", "Image_Url", "Nome", "Produto_Ativo", "Tamanho", "data_criacao", "data_ultimaAlteracao" },
                values: new object[,]
                {
                    { 1, 1, 100001, "Preto", 0, 0, "camiseta_polo_Preta.com.br", "Camisa Polo Gola V", true, "Médio", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 100002, "Branco", 0, 0, "camiseta_polo_Branca.com.br", "Camisa Polo", true, "Médio", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "IX_TB_INTES_PEDIDOS_Id_pedido",
                table: "TB_INTES_PEDIDOS",
                column: "Id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_TB_INTES_PEDIDOS_Id_produto",
                table: "TB_INTES_PEDIDOS",
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
                name: "IX_TB_PRODUTOS_Categoria_Id",
                table: "TB_PRODUTOS",
                column: "Categoria_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTOS_Id_Estoque",
                table: "TB_PRODUTOS",
                column: "Id_Estoque",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTOS_Id_Precos",
                table: "TB_PRODUTOS",
                column: "Id_Precos",
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
                name: "TB_INTES_PEDIDOS");

            migrationBuilder.DropTable(
                name: "TB_LUCROS");

            migrationBuilder.DropTable(
                name: "TB_FORNEDORES");

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

            migrationBuilder.DropTable(
                name: "TB_PRECOS");
        }
    }
}
