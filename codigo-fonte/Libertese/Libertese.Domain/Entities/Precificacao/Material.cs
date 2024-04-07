namespace Libertese.Domain.Entities.Precificacao
{
    public class Material : BaseEntity
    {
        public required string Nome { get; set; }

        public decimal Preco { get; set; }
    }
}
