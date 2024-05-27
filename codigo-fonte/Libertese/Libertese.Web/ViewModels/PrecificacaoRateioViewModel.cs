using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class PrecificacaoRateioViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Produto")]
        public string? Nome { get; set; }

        [Display(Name = "Margem")]
        public decimal? Margem { get; set; }

        [Display(Name = "Custo de Produção")]
        public decimal? CustoProducao { get; set; }

        [Display(Name = "Rateio Percentual")]
        public decimal? PercentualProducao { get; set; }

        [Display(Name = "Rateio")]
        public decimal? ValorRateio { get; set; }

        [Display(Name = "Custo Unitário")]
        public decimal? CustoProdutoUnitario { get; set; }

        [Display(Name = "Custo Total")]
        public decimal? CustoProdutoTotal { get; set; }

        [Display(Name = "Quantidade Produzida")]
        public int Quantidade { get; set; }

    }
}


