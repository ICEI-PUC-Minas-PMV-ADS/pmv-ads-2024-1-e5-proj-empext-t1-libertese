using Libertese.Domain.Entities;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Libertese.ViewModels
{
    public class VendaCreateViewModel : BaseEntity
    {

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Cliente é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Cliente é obrigatório.")]
        public int ClienteId { get; set; }

        [Display(Name = "Forma de Pagamento")]
        [Required(ErrorMessage = "Forma de pagamento é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "Forma de pagamento é obrigatória.")]
        public int? FormaPagamentoId { get; set; }

        public List<FormaPagamento> FormaPagamento { get; set; } = new List<FormaPagamento>();

        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        [Display(Name = "Quantidade")]
        public int? Quantidade { get; set; }

        [Display(Name = "Produtos")]
        [Required(ErrorMessage = "Produtos são obrigatórios.")]
        [MinLength(1, ErrorMessage = "Escolha pelo menos um produto para incluir no registro de venda.")]
        public List<ProdutoVendaViewModel> Produtos { get; set; } = new List<ProdutoVendaViewModel>();

        [Required(ErrorMessage = "Incluir Produtos é obrigatório.")]
        public string? ProdutosJson { get; set; }

        public string? SearchCliente { get; set; }

    }
}
