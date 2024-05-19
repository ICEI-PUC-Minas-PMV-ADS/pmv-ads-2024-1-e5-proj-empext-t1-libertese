using Libertese.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class ProdutoCreateViewModel : BaseEntity
    {
        public ProdutoCreateViewModel()
        {
            DataAtualizacao = DateTime.Now;
            DataCriacao = DateTime.Now;
            Materiais = new List<MaterialViewModel>();
        }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        [Display (Name = "Tempo de Produção")]
        public int TempoProducao { get; set;}

        [Display(Name = "Margem de Lucro")]
        public decimal Margem { get; set; }

        [Display(Name = "Materiail")]
        public int MaterialId { get; set; }

        [Display(Name = "Quantidade")]
        public int? Quantidade { get; set; }

        [Display(Name = "Materiais")]
        public List<MaterialViewModel> Materiais { get; set; }


    }
}
