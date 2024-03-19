using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Libertese.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Criação")]
        public DateTimeOffset DataCriacao { get; set; }

        [Display(Name = "Atualização")]
        public DateTimeOffset? DataAtualizacao { get; set; }

    }
}
