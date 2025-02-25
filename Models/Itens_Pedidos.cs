using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace marktplace_sistem.models
{

    public class Itens_Pedidos
    {
        public int Id { get; set; }
        public int Id_pedido { get; set; }
        
        [JsonIgnore]
        public Pedidos Pedidos { get; set; }
        public int Id_produto { get; set; }

        [JsonIgnore]
        public Produto Produto { get; set; }
        public int quantidade { get; set; }
        public double preco_unitario { get; set; }
    }
}