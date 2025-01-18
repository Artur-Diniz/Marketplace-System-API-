namespace marktplace_sistem.models
{

    public class Categoria
    {
        public int Id { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}