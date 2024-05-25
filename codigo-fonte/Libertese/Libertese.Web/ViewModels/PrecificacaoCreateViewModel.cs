using Libertese.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class PrecificacaoCreateViewModel : BaseEntity
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


        // ########################### CONTEXTO PRODUTOS ###########################


        // Composição de produtos da precificação (inicio) 

        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        [Display(Name = "Produtos")]
        [Required(ErrorMessage = "Produtos são obrigatórios.")]
        [MinLength(1, ErrorMessage = "Escolha pelo menos um produto para compor a precificação.")]
        public List<PrecificacaoDespesaViewModel> Despesas { get; set; } = new List<PrecificacaoDespesaViewModel>();

        [Required(ErrorMessage = "Incluir Produtos é obrigatório.")]
        public string? ProdutoJson { get; set; }

        // Composição de produtos da precificação (fim)


        // ########################### CONTEXTO DESPESAS ###########################


        // Composição de despesas da precificação (inicio) 

        [Display(Name = "Competência")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DespesaCompetencia { get; set; }

        [Display(Name = "Despesa")]
        public int DespesaId { get; set; }

        [Display(Name = "Despesas")]
        [Required(ErrorMessage = "Despesas são obrigatórios.")]
        [MinLength(1, ErrorMessage = "Escolha pelo menos uma despesa para compor a precificação.")]
        public List<PrecificacaoDespesaViewModel> Produtos { get; set; } = new List<PrecificacaoDespesaViewModel>();

        [Required(ErrorMessage = "Incluir Despesas é obrigatório.")]
        public string? DespesaJson { get; set; }

        // Composição de despesas da precificação (fim)













        [Display(Name = "Materiais")]
        [Required(ErrorMessage = "Materiais são obrigatórios.")]
        [MinLength(1, ErrorMessage = "Escolha pelo menos um material para compor o produto.")]
        public List<MaterialViewModel> Materiais { get; set; } = new List<MaterialViewModel>();

        [Required(ErrorMessage = "Incluir Materiais é obrigatório.")]
        public string? MateriaisJson { get; set; }

    }
}
