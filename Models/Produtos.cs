using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace marktplace_sistem.models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Codigo { get; set; }//Código único de identificação do produto (SKU).
#pragma warning disable CS8632
        public string? Image_Url { get; set; } = string.Empty;
        public bool Produto_Ativo { get; set; } // status do produto 

        public string Tamanho { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;

        public int Id_Estoque { get; set; }
        [JsonIgnore]
#pragma warning disable CS8632
        public Estoque? Estoque { get; set; }

        [JsonIgnore]
        public ICollection<Precos> Precos { get; set; }

#pragma warning disable CS8632
        public ICollection<Lucros>? Lucros { get; set; }
        public ICollection<Historico_precos> Historico_Precos { get; set; }
        public ICollection<Compras> Compras { get; set; }
        public ICollection<Itens_Pedidos> Itens_Pedidos { get; set; }
        public int Id_categoria { get; set; }

        [JsonIgnore]
        public Categoria categoria { get; set; }
        public DateTime data_criacao { get; set; }
        public DateTime data_ultimaAlteracao { get; set; }

        [JsonIgnore]
#pragma warning disable CS8632
        public Impostos? Impostos { get; set; }
        public List<Fornecedor_Produto> Fornecedor_Produto { get; set; }

        //categoria, Impostos, Itens_Pedidos,Compras,Historico_Precos,Lucros,Precos,Estoque
    }
}