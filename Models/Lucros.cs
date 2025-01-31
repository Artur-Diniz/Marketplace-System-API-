using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace marktplace_sistem.models
{

    public class Lucros
    {
        public int Id { get; set; }
        public int Id_produto { get; set; }
        [JsonIgnore]
        public Produto Produto { get; set; }
        public double preco_custo { get; set; }
        public double margem_lucro_percentual { get; set; }
        public DateTime data_UltimaAtualizacao { get; set; }



    }
}