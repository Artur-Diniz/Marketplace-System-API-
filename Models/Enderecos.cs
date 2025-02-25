using System.ComponentModel.DataAnnotations;

namespace marktplace_sistem.models
{

    public class Enderecos
    {
        public int Id { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public int numero { get; set; }
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;

        public int Cep { get; set; }

        public int? Clientes_Cnpj_Id { get; set; }
        public Clientes_Cnpj Clientes_Cnpj { get; set; }
        public int? Clientes_CPF_Id { get; set; }
        public Clientes_CPF Clientes_CPF { get; set; }



    }
}