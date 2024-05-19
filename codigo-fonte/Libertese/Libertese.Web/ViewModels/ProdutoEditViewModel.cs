using Libertese.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class ProdutoEditViewModel : BaseEntity
    {
        public ProdutoEditViewModel()
        {
            Materiais = new List<MaterialViewModel>();
        }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        [Display (Name = "Tempo de Produção")]
        public int TempoProducao { get; set;}
        public int Empresa { get; set; }
        [Display (Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Margem de Lucro")]
        public decimal Margem { get; set; }

        [Display(Name = "Rateio de custos fixos")]
        public decimal Rateio { get; set; }

        [Display(Name = "Custo de Materiais")]
        public decimal CustoTotalMateriais { get; set; }

        [Display(Name = "Materiail")]
        public string? Materiail { get; set; }

        [Display(Name = "Quantidade")]
        public int? Quantidade { get; set; }

        [Display(Name = "Materiais")]
        public List<MaterialViewModel> Materiais { get; set; }


    }
}
