using marktplace_sistem.models;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }



        public DbSet<Produto> TB_PRODUTOS { get; set; }
        public DbSet<Categoria> TB_CATEGORIAS { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Produto>().HasData
            (
                new Produto { Id = 1, Nome = "Camisa Polo Branca", Codigo = 100001, Categoria_Id = 1, Image_Url = "camiseta_polo_Preta.com.br", data_criacao = new DateTime(2025, 01, 15), data_ultimaAlteracao = new DateTime(2025, 01, 15), Produto_Ativo = true },
                new Produto { Id = 2, Nome = "Camisa Polo preto ", Codigo = 100001, Categoria_Id = 1, Image_Url = "camiseta_polo_Branca.com.br", data_criacao = new DateTime(2025, 01, 15), data_ultimaAlteracao = new DateTime(2025, 01, 15), Produto_Ativo = true }

            );
              modelBuilder.Entity<Categoria>().HasData
            (
                new Categoria { Id = 1, Nome = "Camisetas", Descricao="Camisas e camisetas"},
                new Categoria { Id = 2, Nome = "Calcas", Descricao="Calças e Shorts"}
              

            );
        }
    }
}