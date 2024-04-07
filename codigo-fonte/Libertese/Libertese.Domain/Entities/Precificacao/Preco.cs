namespace Libertese.Domain.Entities.Precificacao
{
    public class Preco : BaseEntity
    {
        public int ProdutoId { get; set; }

        public int RateioId { get; set; }

        public DateTime Vigencia { get; set; }
    }
}
