using System.ComponentModel.DataAnnotations;

namespace marktplace_sistem.models
{

    public class Clientes_CPF
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        // lembrar de configurar o numero de casas (num de casas=11) 
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Telefone { get; set; }
        public DateTime data_Cadastro { get; set; }
        public DateTime data_UltimaCompra { get; set; }

        // ativo, Pedido pendente, intaivo (ultima compra em 1 ano)
        public ClientesEnum Status { get; set; }
    }
}