namespace marktplace_sistem.models
{

    public class Precos
    {
        public int Id { get; set; }
        public int Id_produto { get; set; }
        public double preco_base { get; set; } //sem desconto
        public double preco_venda { get; set; }// com imposto 
        public double preco_promocional { get; set; }
        public DateTime data_inicial { get; set; }
        public DateTime data_fim { get; set; }// fim 
        public DateTime data_promo_inicial { get; set; }//quando começa a promo
        public DateTime data_promo_final { get; set; }//quando terimna

        public PrecosEnum Status { get; set; }
        //tem que fazer um enum com os atributos de ativo, ativo promocional e inativo

    }
}