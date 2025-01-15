namespace MarktplaceSitem.models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Codigo { get; set; }//Código único de identificação do produto (SKU).
        public int Categoria_Id { get; set; }
        public string Image_Url { get; set; } = string.Empty;
        public bool Produto_Ativo { get; set; } // status do produto 

        public DateTime data_criacao { get; set; }
        public DateTime data_ultimaAlteracao { get; set; }
    }
}