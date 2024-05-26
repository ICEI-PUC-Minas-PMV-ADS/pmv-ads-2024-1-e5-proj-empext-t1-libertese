namespace Libertese.ViewModels
{
    public class PrecificacaoPrecoViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal? CustoUnitario { get; set; }
        public decimal? Comissao { get; set; }
        public decimal? Imposto { get; set; }
        public decimal? Margem { get; set; }
        public decimal? PrecoSugerido { get; set; }
        public decimal? Lucro { get; set; }
        public decimal? LucroTotal { get; set; }

    }
}