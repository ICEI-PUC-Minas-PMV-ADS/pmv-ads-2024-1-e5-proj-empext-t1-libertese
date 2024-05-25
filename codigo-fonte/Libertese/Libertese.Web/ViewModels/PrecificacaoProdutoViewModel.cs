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

        [Display(Name = "Margem de lucro")]
        public decimal Margem { get; set; }

        [Display(Name = "Total de Materiais")]
        public decimal TotalMateriais { get; set; }

    }
}


