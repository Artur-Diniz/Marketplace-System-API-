using System.ComponentModel.DataAnnotations;

namespace MarktplaceSitem.models
{

    public class Pedidos
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public DateTime data_Pedido { get; set; }
        public DateTime data_Entrega { get; set; }
        public double valor_pedido { get; set; }

        public PedidosEnum Forma_Pagamento { get; set; }
    }
}