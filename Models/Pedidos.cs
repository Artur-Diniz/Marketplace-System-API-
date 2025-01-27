using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace marktplace_sistem.models
{

    public class Pedidos
    {
        public int Id { get; set; }
        
        public int? Id_Cliente_CPF { get; set; }
        [JsonIgnore]
        public Clientes_CPF Clientes_CPF { get; set; }

        public int? Id_Cliente_CNPJ { get; set; }
        [JsonIgnore]
        public Clientes_Cnpj Clientes_CNPJ { get; set; }

        
        public double Preco_Frete { get; set; }
        public DateTime Data_Pedido { get; set; }
        public DateTime? Data_Entrega { get; set; }
        public double Valor_pedido { get; set; }
        public ICollection<Itens_Pedidos> Itens_Pedidos { get; set; }
        public PedidosEnum Forma_Pagamento { get; set; }
    }
}