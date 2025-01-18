using System.ComponentModel.DataAnnotations;

namespace marktplace_sistem.models
{

    public class Enderecos
    {
        public int Id { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public int numero { get; set; }
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;//lembrar de setar 2 casas 
        public string Pais { get; set; } = string.Empty;


        public int? Clientes_Cnpj_Id { get; set; }
        public int? Clientes_CPF_Id { get; set; }


    }
}