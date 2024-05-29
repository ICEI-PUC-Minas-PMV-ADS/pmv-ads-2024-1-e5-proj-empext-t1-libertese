using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class ProdutoVendaViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Produto")]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Total")]
        public decimal ValorTotal { get; set; }

        public int? Tempo { get; set; }

        public int? TempoTotal { get; set; }
    }
}


