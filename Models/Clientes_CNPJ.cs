using System.ComponentModel.DataAnnotations;

namespace marktplace_sistem.models
{

    public class Clientes_Cnpj
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        //lembrar quando for terminar as tabelas antes de gerar o script limitar a 14 casas
        [Key]
        public string Cnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Telefone { get; set; }
        public DateTime data_Cadastro { get; set; }
        public DateTime data_UltimaCompra { get; set; }

        // ativo, Pedido pendente, intaivo (ultima compra em 1 ano)
        public ClientesEnum Status { get; set; }
    }
}