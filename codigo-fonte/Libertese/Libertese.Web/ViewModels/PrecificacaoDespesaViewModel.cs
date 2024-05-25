using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class PrecificacaoDespesaViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Despesa")]
        public string? Nome { get; set; }

        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }
        
    }
}


