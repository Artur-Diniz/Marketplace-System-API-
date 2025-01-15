using System.ComponentModel.DataAnnotations;

namespace MarktplaceSitem.models
{

    public class Enderecos
    {
        public int Id { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public int numero { get; set; }
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;//lembrar de setar 2 casas 
        public string Pais { get; set; } = string.Empty;

    }
}