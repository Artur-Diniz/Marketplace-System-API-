using System.ComponentModel.DataAnnotations;

namespace MarktplaceSitem.models
{

    public class Itens_Pedidos
    {
        public int Id { get; set; }
        public int Id_pedido { get; set; }
        public int Id_produto { get; set; }
        public int quantidade { get; set; }
        public int preco_unitario { get; set; }
    }
}