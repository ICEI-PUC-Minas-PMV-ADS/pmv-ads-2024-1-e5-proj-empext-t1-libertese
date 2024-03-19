using System.ComponentModel.DataAnnotations;

namespace Libertese.Domain.Entities.Precificacao
{
    public class Produto : BaseEntity
    {

        public required string Nome { get; set; }
        [Display (Name = "Tempo Produção")]
        public int TempoProducao { get; set;}

    }
}
