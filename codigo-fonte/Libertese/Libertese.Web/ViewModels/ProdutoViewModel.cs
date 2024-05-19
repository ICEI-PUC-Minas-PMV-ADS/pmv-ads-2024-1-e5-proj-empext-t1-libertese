using Libertese.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class ProdutoViewModel : BaseEntity
    {
        public int Id { get; set; }
        
        [Display(Name = "Produto")]
        public string? Nome { get; set; }
        
        [Display(Name = "Categoria")]
        public string? Categoria { get; set; }

        [Display(Name = "Tempo Produção")]
        public int? TempoProducao { get; set; }
        
        [Display(Name = "Custo de Materiais")]
        public decimal? Custo { get; set; }

        [Display(Name = "Preço")]
        public decimal? Preco { get; set; }
        
        [Display(Name = "Rateio de Custos Fixos")]
        public decimal? Rateio { get; set; }

        [Display(Name = "Total de Materiais")]
        public int TotalMateriais { get; set; }

        [Display(Name = "Materiais")]
        public List<MaterialViewModel> Materiais { get; set; } = new List<MaterialViewModel>();
    }
}


