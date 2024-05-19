using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libertese.Domain.Entities.Precificacao
{
    public class Produto : BaseEntity
    {

        [ForeignKey("Categoria")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public required string Nome { get; set; }
        [Display (Name = "Tempo de Produção")]
        public int TempoProducao { get; set;}
        public int Empresa { get; set; }
        [Display (Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Margem de Lucro")]
        public decimal Margem { get; set; }

        [Display(Name = "Rateio de custos fixos")]
        public decimal Rateio { get; set; }


    }
}
