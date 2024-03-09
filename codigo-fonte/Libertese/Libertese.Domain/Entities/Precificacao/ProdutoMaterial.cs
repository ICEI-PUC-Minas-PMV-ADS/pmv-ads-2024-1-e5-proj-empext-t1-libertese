using System.ComponentModel.DataAnnotations.Schema;

namespace Libertese.Domain.Entities.Precificacao
{
    public class ProdutoMaterial : BaseEntity
    {
        public int ProdutoId { get; set; }

        public int MateriaiId { get; set; }

        public int Quantidade { get; set; }
    }
}
