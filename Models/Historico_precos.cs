using System.Text.Json.Serialization;

namespace marktplace_sistem.models
{

    public class Historico_precos
    {
        public int Id { get; set; }
        public int Id_produto { get; set; }
        [JsonIgnore]
        public Produto Produto { get; set; }

        public double preco_base { get; set; }
        public double preco_venda { get; set; }//com imposto adicionado

        public DateTime data_inicio { get; set; }
        public DateTime? data_finalizou { get; set; }
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Motivo { get; set; } = string.Empty; //motivação pela alteração do preço
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    }
}