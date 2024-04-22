using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libertese.Domain.Entities.Precificacao
{
    public class Produto : BaseEntity
    {

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public required string Nome { get; set; }
        [Display (Name = "Tempo Produção")]
        public int TempoProducao { get; set;}
        public int Empresa { get; set; }
        [Display (Name = "Preço")]
        public decimal Preco { get; set; }
        

    }
}
