using System.Net.NetworkInformation;

namespace marktplace_sistem.models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Codigo { get; set; }//Código único de identificação do produto (SKU).
        public int Categoria_Id { get; set; }
        public string? Image_Url { get; set; } = string.Empty;
        public bool Produto_Ativo { get; set; } // status do produto 
        
        public string Tamanho { get; set; } = string.Empty;
        public string Cor { get; set; }  = string.Empty;

        public int Id_Estoque { get; set; }
        public Estoque Estoque { get; set; }

        public int Id_Precos { get; set; }
        public Precos Precos { get; set; }
        
        public ICollection<Lucros> Lucros { get; set; }
        public ICollection<Historico_precos> Historico_Precos { get; set; }
        public ICollection<Compras> Compras { get; set; }
        public ICollection<Itens_Pedidos> Itens_Pedidos { get; set; }
        public Categoria  categoria { get; set; }
        public DateTime data_criacao { get; set; }
        public DateTime data_ultimaAlteracao { get; set; }

        public Impostos Impostos { get; set; }
        public List<Fornecedor_Produto> Fornecedor_Produto { get; set; }

    }
}