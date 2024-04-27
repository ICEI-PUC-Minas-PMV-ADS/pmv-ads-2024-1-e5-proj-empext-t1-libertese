using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Libertese.Domain.Entities.Precificacao
{
    public class Categoria : BaseEntity
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public required string Nome { get; set; }
    }
}
