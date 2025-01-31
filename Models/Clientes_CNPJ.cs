using System.ComponentModel.DataAnnotations;

namespace marktplace_sistem.models
{

    public class Clientes_Cnpj
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Telefone { get; set; }
        public DateTime data_Cadastro { get; set; }
        public DateTime? data_UltimaCompra { get; set; }
        public ICollection<Enderecos> Enderecos { get; set; }


        // ativo, Pedido pendente, intaivo (ultima compra em 1 ano)
        public ClientesEnum Status { get; set; }
    }
}