using Libertese.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class ProdutoCreateViewModel : BaseEntity
    {

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Categoria é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria é obrigatório.")]
        public int? CategoriaId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome do produto é obrigatório.")]
        public string? Nome { get; set; }

        [Display (Name = "Tempo de Produção")]
        [Required(ErrorMessage = "O campo Tempo de produção é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Tempo de produção deve ser maior que zero.")]
        public int TempoProducao { get; set;}

        [Display(Name = "Margem de Lucro")]
        [Required(ErrorMessage = "O Margem de lucro é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Margem de Lucro deve ser maior que zero.")]
        public decimal Margem { get; set; }

        [Display(Name = "Materiail")]
        public int MaterialId { get; set; }

        [Display(Name = "Quantidade")]
        public int? Quantidade { get; set; }

        [Display(Name = "Materiais")]
        [Required(ErrorMessage = "Materiais são obrigatórios.")]
        [MinLength(1, ErrorMessage = "Escolha pelo menos um material para compor o produto.")]
        public List<MaterialViewModel> Materiais { get; set; } = new List<MaterialViewModel>();

        [Required(ErrorMessage = "Incluir Materiais é obrigatório.")]
        public string? MateriaisJson { get; set; }

    }
}
