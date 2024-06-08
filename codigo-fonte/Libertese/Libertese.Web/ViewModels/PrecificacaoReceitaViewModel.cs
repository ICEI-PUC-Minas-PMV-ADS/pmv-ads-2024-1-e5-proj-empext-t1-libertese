using System.ComponentModel.DataAnnotations;

namespace Libertese.Web.ViewModels
{
    public class PrecificacaoReceitaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Receita")]
        public string? Nome { get; set; }

        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }

    }
}
