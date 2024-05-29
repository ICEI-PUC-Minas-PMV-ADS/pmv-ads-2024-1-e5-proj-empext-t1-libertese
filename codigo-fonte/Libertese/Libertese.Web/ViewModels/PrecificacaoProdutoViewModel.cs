using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class PrecificacaoProdutoViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Display(Name = "Tempo de Produção")]
        public int TempoProducao { get; set; }

        [Display(Name = "Tempo de Produção Total")]
        public int TempoProducaoTotal { get; set; }

        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Margem")]
        public decimal Margem { get; set; }

        [Display(Name = "Custo Por Peça")]
        public decimal Custo { get; set; }

        [Display(Name = "Custo Total")]
        public decimal Total { get; set; }

    }
}


