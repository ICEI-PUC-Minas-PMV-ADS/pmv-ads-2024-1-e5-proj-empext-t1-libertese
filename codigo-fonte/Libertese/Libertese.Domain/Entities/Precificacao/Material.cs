using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Libertese.Domain.Entities.Precificacao
{
    public class Material : BaseEntity
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public required string Nome { get; set; }

        [DisplayName("Preço")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo Preço deve ser maior do que zero.")]
        [Required(ErrorMessage = "O campo preço é obrigatório.")]
        public decimal Preco { get; set; }
    }
}