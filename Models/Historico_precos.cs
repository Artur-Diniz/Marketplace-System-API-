namespace marktplace_sistem.models
{

    public class Historico_precos
    {
        public int Id { get; set; }
        public int Id_produto { get; set; }
        public Produto Produto { get; set; }
        public double preco_base { get; set; }
        public double preco_venda { get; set; }//com imposto adicionado

        public DateTime data_inicio { get; set; }
        public DateTime data_finalizou { get; set; }
        public string Motivo { get; set; } = string.Empty; //motivação pela alteração do preço
    }
}