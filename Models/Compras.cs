namespace marktplace_sistem.models
{

    public class Compras
    { 
        public int Id { get; set; }
        public int Id_fornecedor { get; set; }
        public int Id_produto { get; set; }
        public int Qunatidade { get; set; }
        public double preco_unitario { get; set; }
        public double preco_total { get; set; }

        
        // pendente, finalizada, cancelada
        public ComprasEnum Status { get; set; }
        
        public DateTime data_compra { get; set; }
        

    }
}