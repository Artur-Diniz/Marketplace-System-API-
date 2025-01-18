using System.Text.Json.Serialization;

namespace marktplace_sistem.models
{

    public class Estoque
    { 
        public int Id{ get; set; }


        [JsonIgnore]
        public Produto Produto { get; set; }
        public int Id_Produto { get; set; }

        
        public int Quantidade { get; set; }
        public int Quantidade_reservada { get; set; }// quantidade vendinda porém ainda no estoque
        public int Quantidade_disponivel { get; set; }// Quantidade - quantidade Reservada 
        public DateTime Ultima_Atualicacao { get; set; }

    }


}