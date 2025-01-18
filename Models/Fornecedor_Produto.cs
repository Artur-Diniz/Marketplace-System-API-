using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.models
{

    public class Fornecedor_Produto
    {

        public int Id_Produto { get; set; }
        [JsonIgnore]
        public Fornecedores Fornecedores { get; set; }

        public int Id_Fornecedor { get; set; }
        [JsonIgnore]
        public Produto Produto { get; set; }

        public string Descricao { get; set; }

    }
}