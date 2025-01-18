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

        public DbSet<Fornecedores> TB_FORNEDORES { get; set; }

        public DbSet<Historico_precos> TB_HISTORICO_PRECOS { get; set; }

        public DbSet<Impostos> TB_IMPOSTOS { get; set; }

        public DbSet<Itens_Pedidos> TB_INTES_PEDIDOS { get; set; }

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
               .OnDelete(DeleteBehavior.Cascade)
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



            #region Objetos Base

            modelBuilder.Entity<Produto>().HasData
            (
                new Produto { Id = 1, Nome = "Camisa Polo Gola V", Codigo = 100001, Id_categoria = 1, Tamanho = "Médio", Cor = "Preto", Image_Url = "camiseta_polo_Preta.com.br", data_criacao = new DateTime(2025, 01, 15), data_ultimaAlteracao = new DateTime(2025, 01, 15), Produto_Ativo = true },
                new Produto { Id = 2, Nome = "Camisa Polo", Codigo = 100002, Id_categoria = 1, Tamanho = "Médio", Cor = "Branco", Image_Url = "camiseta_polo_Branca.com.br", data_criacao = new DateTime(2025, 01, 15), data_ultimaAlteracao = new DateTime(2025, 01, 15), Produto_Ativo = true }

            );
            modelBuilder.Entity<Categoria>().HasData
            (
              new Categoria { Id = 1, Nome = "Camisetas", Descricao = "Camisas e camisetas" },
              new Categoria { Id = 2, Nome = "Calcas", Descricao = "Calças e Shorts" }

            );

            modelBuilder.Entity<Fornecedores>().HasData
            (
             new Fornecedores() { Id = 1, cnpj = "12312312312321", Nome = "Jonas", Email = "jonas@gmail.com", Telefone = 1124311717, Fornecedor_Ativo = true, Fornecedor_Produto = new List<Fornecedor_Produto> { } },
             new Fornecedores() { Id = 2, cnpj = "32132132132123", Nome = "Jonathan", Email = "Jonathan@gmail.com", Telefone = 1124311743, Fornecedor_Ativo = true, Fornecedor_Produto = new List<Fornecedor_Produto> { } }
            );

            #endregion
        }

    }
}