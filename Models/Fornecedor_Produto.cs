using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.models
{

    public class Fornecedor_Produto
    {

        public int Id_Produto { get; set; }
        public Fornecedores Fornecedores { get; set; }

        public int Id_Fornecedor { get; set; }
        public Produto Produto { get; set; }

        public string Descricao { get; set; }

    }
}