using System.ComponentModel.DataAnnotations;
using marktplace_sistem.models;
using Microsoft.EntityFrameworkCore;


namespace marktplace_sistem.models
{

    public class Fornecedores
    {
        [Key]
        public int Id { get; set; }

        public string cnpj { get; set; }

        public string Nome { get; set; } = string.Empty;
        public int Telefone { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool Fornecedor_Ativo { get; set; }

        public ICollection<Compras> Compras { get; set; }

        public List<Fornecedor_Produto> Fornecedor_Produto { get; set; }


    }
}