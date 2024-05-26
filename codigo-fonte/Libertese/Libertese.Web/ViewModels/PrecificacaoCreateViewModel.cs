using Libertese.Domain.Entities;
using Libertese.Domain.Entities.Precificacao;
using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class PrecificacaoCreateViewModel : BaseEntity
    {

        public void CalcularTotalHorasMes()
        {
            TotalHorasMes = (TotalPessoas * HorasDiarias) * DiasMes;
        }

        [Display(Name = "Pessoas por produção")]
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Esse campo é obrigatório.")]
        public int? TotalPessoas { get; set; }

        [Display(Name = "Horas por dia")]
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Esse campo é obrigatório.")]
        public int? HorasDiarias { get; set; }

        [Display (Name = "Dias por mês")]
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Esse campo é obrigatório.")]
        public int? DiasMes { get; set;}

        [Display(Name = "Horas mensal")]
        public int? TotalHorasMes { get; set; }

        [Display(Name = "Comissão")]
        public int? Comissao { get; set; }

        [Display(Name = "Impostos")]
        public int? Impostos { get; set; }



        // ########################### CONTEXTO PRODUTOS ###########################


        // Composição de produtos da precificação (inicio) 

        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        [Display(Name = "Quantidade")]
        public int ProdutoQuantidade { get; set; }

        [Display(Name = "Produtos")]
        [Required(ErrorMessage = "Produtos são obrigatórios.")]
        [MinLength(1, ErrorMessage = "Escolha pelo menos um produto para compor a precificação.")]
        public List<PrecificacaoProdutoViewModel> Produtos { get; set; } = new List<PrecificacaoProdutoViewModel>();

        [Required(ErrorMessage = "Incluir Produtos é obrigatório.")]
        public string? ProdutosJson { get; set; }

        public int? TotalDeProdutos { get; set; }

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
        public List<PrecificacaoDespesaViewModel> Despesas { get; set; } = new List<PrecificacaoDespesaViewModel>();

        [Required(ErrorMessage = "Incluir Despesas é obrigatório.")]
        public string? DespesasJson { get; set; }

        public int? TotalDeDespesas { get; set; }


        // Composição de despesas da precificação (fim)



        // ########################### CONTEXTO RATEIOS ###########################


        // Composição de rateios da precificação (inicio) 

        [Display(Name = "Despesas")]
        [Required(ErrorMessage = "Despesas são obrigatórios.")]
        [MinLength(1, ErrorMessage = "Escolha pelo menos uma despesa para compor a precificação.")]
        public List<PrecificacaoRateioViewModel> Rateios { get; set; } = new List<PrecificacaoRateioViewModel>();

        [Required(ErrorMessage = "Calcular Rateios é obrigatório.")]
        public string? RateiosJson { get; set; }

        public int? TotalDeRateios { get; set; }


        // Composição de rateios da precificação (fim)













        [Display(Name = "Materiais")]
        [Required(ErrorMessage = "Materiais são obrigatórios.")]
        [MinLength(1, ErrorMessage = "Escolha pelo menos um material para compor o produto.")]
        public List<MaterialViewModel> Materiais { get; set; } = new List<MaterialViewModel>();

        [Required(ErrorMessage = "Incluir Materiais é obrigatório.")]
        public string? MateriaisJson { get; set; }

    }
}
