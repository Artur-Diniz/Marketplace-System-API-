using System.Text.Json.Serialization;

namespace marktplace_sistem.models
{

    public class Impostos
    {
        public int Id { get; set; }
        public int Id_produto { get; set; }
        [JsonIgnore]
        public Produto Produto { get; set; }
        public double percentual { get; set; }
        public bool status { get; set; }
        public DateTime data_inicio { get; set; }

    }
}