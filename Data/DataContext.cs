using marktplace_sistem.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace marktplace_sistem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }



        #region DbSet Tabelas
        public DbSet<Categoria> TB_CATEGORIAS { get; set; }
        public DbSet<Clientes_Cnpj> TB_CLIENTES_CNPJ { get; set; }
        public DbSet<Clientes_CPF> TB_CLIENTES_CPF { get; set; }

        public DbSet<Compras> TB_COMPRAS { get; set; }

        public DbSet<Enderecos> TB_ENDERECOS { get; set; }

        public DbSet<Estoque> TB_ESTOQUE { get; set; }

        public DbSet<Fornecedor_Produto> TB_FORNECEDOR_PRODUTO { get; set; }

        public DbSet<Fornecedores> TB_FORNECEDORES { get; set; }

        public DbSet<Historico_precos> TB_HISTORICO_PRECOS { get; set; }

        public DbSet<Impostos> TB_IMPOSTOS { get; set; }

        public DbSet<Itens_Pedidos> TB_ITENS_PEDIDOS { get; set; }

        public DbSet<Lucros> TB_LUCROS { get; set; }

        public DbSet<Pedidos> TB_PEDIDOS { get; set; }

        public DbSet<Precos> TB_PRECOS { get; set; }

        public DbSet<Produto> TB_PRODUTOS { get; set; }


        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            #region Chaves estrangeiras  
            modelBuilder.Entity<Pedidos>()
                .HasOne(p => p.Clientes_CPF)
                .WithMany()
                .HasForeignKey(p => p.Id_Cliente_CPF)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedidos>()
               .HasOne(p => p.Clientes_CNPJ)
               .WithMany()
               .HasForeignKey(p => p.Id_Cliente_CNPJ)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enderecos>()
               .HasOne(p => p.Clientes_Cnpj)
               .WithMany()
               .HasForeignKey(p => p.Clientes_Cnpj_Id)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enderecos>()
               .HasOne(p => p.Clientes_CPF)
               .WithMany()
               .HasForeignKey(p => p.Clientes_CPF_Id)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fornecedor_Produto>(entity =>
            {
                entity.HasKey(fp => new { fp.Id_Fornecedor, fp.Id_Produto });

                entity.HasOne(fp => fp.Fornecedores)
                      .WithMany(f => f.Fornecedor_Produto)
                      .HasForeignKey(fp => fp.Id_Fornecedor)
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

                entity.HasOne(fp => fp.Produto)
                      .WithMany(p => p.Fornecedor_Produto)
                      .HasForeignKey(fp => fp.Id_Produto)
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
            });


            modelBuilder.Entity<Itens_Pedidos>(entity =>
            {
                entity.HasKey(Ip => Ip.Id);
                entity.HasOne(ip => ip.Pedidos)
                .WithMany(p => p.Itens_Pedidos)
                .HasForeignKey(ip => ip.Id_pedido)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

                entity.HasOne(ip => ip.Produto)
                  .WithMany(pr => pr.Itens_Pedidos)
                  .HasForeignKey(ip => ip.Id_produto)
                  .OnDelete(DeleteBehavior.Cascade)
                  .IsRequired();
            });


            modelBuilder.Entity<Impostos>()
                .HasOne(i => i.Produto)
                .WithOne(p => p.Impostos)
                .HasForeignKey<Impostos>(p => p.Id_produto);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Estoque)
                .WithOne(e => e.Produto)
                .HasForeignKey<Produto>(e => e.Id_Estoque);

            modelBuilder.Entity<Precos>()
                .HasOne(p => p.Produto)
                .WithMany(pre => pre.Precos)
                .HasForeignKey(p => p.Id_produto)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Categoria>()
               .HasMany(c => c.Produtos)
               .WithOne(pre => pre.categoria)
               .HasForeignKey(p => p.Id_categoria)
               .IsRequired();

            modelBuilder.Entity<Produto>()
                .HasMany(l => l.Lucros)
                .WithOne(p => p.Produto)
                .HasForeignKey(p => p.Id_produto)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .HasMany(l => l.Historico_Precos)
                .WithOne(p => p.Produto)
                .HasForeignKey(p => p.Id_produto)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Fornecedores>()
               .HasMany(l => l.Compras)
               .WithOne(p => p.Fornecedores)
               .HasForeignKey(p => p.Id_fornecedor)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

            modelBuilder.Entity<Produto>()
               .HasMany(l => l.Compras)
               .WithOne(p => p.Produto)
               .HasForeignKey(p => p.Id_produto)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

            #endregion



            modelBuilder.Entity<Fornecedores>()
                .Property(f => f.cnpj)
                .HasMaxLength(14)
                .IsFixedLength()
                .IsRequired();

            modelBuilder.Entity<Clientes_Cnpj>()
               .Property(c => c.Cnpj)
               .HasMaxLength(14)
               .IsFixedLength()
               .IsRequired();

            modelBuilder.Entity<Clientes_CPF>()
                .Property(c => c.CPF)
                .HasMaxLength(11)
                .IsFixedLength()
                .IsRequired();

            modelBuilder.Entity<Enderecos>()
                .Property(e => e.UF)
                .HasMaxLength(2)
                .IsFixedLength()
                .IsRequired();

            modelBuilder.Entity<Enderecos>()
                .Property(e => e.Cep)
                .HasMaxLength(8)
                .IsFixedLength()
                .IsRequired();


            #region Objetos Base


            modelBuilder.Entity<Categoria>().HasData
            (
              new Categoria { Id = 1, Nome = "Camisetas", Descricao = "Camisas e camisetas" },
              new Categoria { Id = 2, Nome = "Calcas", Descricao = "Calças e Shorts" }

            );

            modelBuilder.Entity<Clientes_Cnpj>().HasData
            (
                new Clientes_Cnpj { Id = 1, Nome = "Jon", Cnpj = "12312312312342", Email = "jon@gmail.com", Status = ClientesEnum.Ativo, Telefone = 23312344, data_Cadastro = DateTime.Now },
                new Clientes_Cnpj { Id = 2, Nome = "Bob", Cnpj = "42123123123123", Email = "bob@gmail.com", Status = ClientesEnum.Ativo, Telefone = 44233123, data_Cadastro = DateTime.Now }
            );


            modelBuilder.Entity<Clientes_CPF>().HasData
            (
                new Clientes_CPF { Id = 1, Nome = "Julian", CPF = "23421231231231", Email = "julian@gmail.com", Status = ClientesEnum.Ativo, Telefone = 23312344, data_Cadastro = DateTime.Now },
                new Clientes_CPF { Id = 2, Nome = "Thomas", CPF = "31234212312312", Email = "thomas@gmail.com", Status = ClientesEnum.Ativo, Telefone = 44233117, data_Cadastro = DateTime.Now }
            );

            modelBuilder.Entity<Compras>().HasData
            (
                new Compras { Id = 1, data_compra = DateTime.Now, Id_fornecedor = 1, Id_produto = 1, preco_Frete = 120.00, preco_total = 360.00, preco_unitario = 12, Qunatidade = 20, Status = ComprasEnum.Finalizada },
                new Compras { Id = 2, data_compra = DateTime.Now, Id_fornecedor = 2, Id_produto = 2, preco_Frete = 120.00, preco_total = 480.00, preco_unitario = 10, Qunatidade = 36, Status = ComprasEnum.Finalizada }
            );


            modelBuilder.Entity<Enderecos>().HasData
            (
                new Enderecos { Id = 1, Clientes_CPF_Id = 1, Pais = "Brasil", UF = "SP", Cidade = "São Paulo", Bairro = "Vila Maria", Cep = 49107174, Logradouro = "Av. Guilherme Cottin", numero = 62, Complemento = "", },
                new Enderecos { Id = 2, Clientes_Cnpj_Id = 1, Pais = "Brasil", UF = "SP", Cidade = "Sorocaba", Bairro = "Centro", Cep = 74491071, Logradouro = "Av. São Pedro ", numero = 65, Complemento = "", }
            );

            modelBuilder.Entity<Estoque>().HasData
            (
                new Estoque { Id = 1, Id_Produto = 1, Quantidade = 20, Quantidade_disponivel = 20, Quantidade_reservada = 0, Ultima_Atualizacao = DateTime.Now },
                new Estoque { Id = 2, Id_Produto = 1, Quantidade = 36, Quantidade_disponivel = 36, Quantidade_reservada = 0, Ultima_Atualizacao = DateTime.Now }
            );

            modelBuilder.Entity<Fornecedor_Produto>().HasData
            (
             new Fornecedor_Produto() { Id_Fornecedor = 1, Id_Produto = 1, Descricao = "Camisestas com melhor custo beneficios" },
             new Fornecedor_Produto() { Id_Fornecedor = 2, Id_Produto = 2, Descricao = "Camisestas de Luxo" }
            );

            modelBuilder.Entity<Fornecedores>().HasData
            (
             new Fornecedores() { Id = 1, cnpj = "12312312312321", Nome = "Jonas", Email = "jonas@gmail.com", Telefone = 1124311717, Fornecedor_Ativo = true, Fornecedor_Produto = new List<Fornecedor_Produto> { } },
             new Fornecedores() { Id = 2, cnpj = "32132132132123", Nome = "Jonathan", Email = "Jonathan@gmail.com", Telefone = 1124311743, Fornecedor_Ativo = true, Fornecedor_Produto = new List<Fornecedor_Produto> { } }
            );

            modelBuilder.Entity<Historico_precos>().HasData
            (
                new Historico_precos() { Id = 1, Id_produto = 1, data_inicio = DateTime.Now, data_finalizou = DateTime.Now, Motivo = "preço está dando prejuizo a loja", preco_base = 20.01, preco_venda = 22.00 },
                new Historico_precos() { Id = 2, Id_produto = 1, data_inicio = DateTime.Now, preco_base = 20.01, preco_venda = 49.99 }
            );


            modelBuilder.Entity<Impostos>().HasData
            (
                new Impostos() { Id = 1, Id_produto = 1, data_inicio = DateTime.Now, percentual = 17, status = true },
                new Impostos() { Id = 2, Id_produto = 2, data_inicio = DateTime.Now, percentual = 20, status = true }
            );


            modelBuilder.Entity<Itens_Pedidos>().HasData
            (
                new Itens_Pedidos() { Id = 1, Id_produto = 1, Id_pedido = 1, preco_unitario = 22.00, quantidade = 2 },
                new Itens_Pedidos() { Id = 2, Id_produto = 1, Id_pedido = 1, preco_unitario = 49.99, quantidade = 1 }

            );

            modelBuilder.Entity<Pedidos>().HasData
            (
                new Pedidos() { Id = 1, Id_Cliente_CPF = 1, Id_Cliente_CNPJ = 0, Valor_pedido = 44.00, Preco_Frete = 19.00, Data_Pedido = DateTime.Now, Data_Entrega = DateTime.Now, Forma_Pagamento = PedidosEnum.Credito },
                new Pedidos() { Id = 2, Id_Cliente_CPF = 0, Id_Cliente_CNPJ = 1, Valor_pedido = 99.98, Preco_Frete = 10.00, Data_Pedido = DateTime.Now, Data_Entrega = DateTime.Now, Forma_Pagamento = PedidosEnum.Pix }

            );


            modelBuilder.Entity<Lucros>().HasData
            (
                new Lucros() { Id = 1, Id_produto = 1, data_UltimaAtualizacao = DateTime.Now, margem_lucro_percentual = 40, preco_custo = 20.00, },
                new Lucros() { Id = 2, Id_produto = 2, data_UltimaAtualizacao = DateTime.Now, margem_lucro_percentual = 36, preco_custo = 15.00, }
            );

            modelBuilder.Entity<Precos>().HasData
            (
                new Precos() { Id = 1, Id_produto = 1, preco_base = 20.01, preco_venda = 22.00, data_inicial = DateTime.Now, data_fim = DateTime.Now, data_promo_inicial = DateTime.Now, data_promo_final = DateTime.Now, preco_promocional = 21.00, Status = PrecosEnum.Intativo },
                new Precos() { Id = 2, Id_produto = 1, preco_base = 20.01, preco_venda = 49.99, data_inicial = DateTime.Now, data_promo_inicial = DateTime.Now, data_promo_final = DateTime.Now, preco_promocional = 29.99, Status = PrecosEnum.Ativo }

            );

            modelBuilder.Entity<Produto>().HasData
            (
                new Produto { Id = 1, Nome = "Camisa Polo Gola V", Codigo = 100001, Id_categoria = 1, Tamanho = "Médio", Cor = "Preto", Image_Url = "camiseta_polo_Preta.com.br", data_criacao = new DateTime(2025, 01, 15), data_ultimaAlteracao = new DateTime(2025, 01, 15), Produto_Ativo = true },
                new Produto { Id = 2, Nome = "Camisa Polo", Codigo = 100002, Id_categoria = 1, Tamanho = "Médio", Cor = "Branco", Image_Url = "camiseta_polo_Branca.com.br", data_criacao = new DateTime(2025, 01, 15), data_ultimaAlteracao = new DateTime(2025, 01, 15), Produto_Ativo = true }

            );
            #endregion
        }

    }
}