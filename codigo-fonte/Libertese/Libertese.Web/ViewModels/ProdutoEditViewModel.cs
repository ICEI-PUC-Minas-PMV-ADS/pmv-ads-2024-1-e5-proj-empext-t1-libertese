using Libertese.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class ProdutoEditViewModel : BaseEntity
    {

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Categoria é obrigatório.")]
        public int CategoriaId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome do produto é obrigatório.")]
        public string? Nome { get; set; }

        [Display (Name = "Tempo de Produção")]
        [Required(ErrorMessage = "Tempo de produção é obrigatório.")]
        public int TempoProducao { get; set;}

        [Display(Name = "Margem de Lucro")]
        [Required(ErrorMessage = "Margem de lucro é obrigatório.")]
        public decimal Margem { get; set; }

        [Display(Name = "Materiail")]
        public int MaterialId { get; set; }

        [Display(Name = "Quantidade")]
        public int? Quantidade { get; set; }

        [Display(Name = "Materiais")]
        public List<MaterialViewModel> Materiais { get; set; } = new List<MaterialViewModel>();

        [Required(ErrorMessage = "Incluir Materiais é obrigatório.")]
        public string? MateriaisJson { get; set; }
        public string? SearchCategoria { get; set; }

    }
}
