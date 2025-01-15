namespace MarktplaceSitem.models
{

    public class Fornecedores
    {
        public int Id { get; set; }
        public int cnpj { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Id_produto { get; set; }
        public int Telefone { get; set; }   
        public string Email { get; set; } = string.Empty;
        public bool Fornecedor_Ativo { get; set; }       
        

    }
}