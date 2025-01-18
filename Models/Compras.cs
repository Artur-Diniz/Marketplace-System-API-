namespace marktplace_sistem.models
{

    public class Compras
    { 
        public int Id { get; set; }
        public int Id_fornecedor { get; set; }
        public Fornecedores Fornecedores { get; set; }
        public int Id_produto { get; set; }
        public 	Produto Produto { get; set; }
        public int Qunatidade { get; set; }
        public double preco_unitario { get; set; }
        public double preco_total { get; set; }
        public double preco_Frete { get; set; }

        
        // pendente, finalizada, cancelada
        public ComprasEnum Status { get; set; }
        
        public DateTime data_compra { get; set; }
        

    }
}