namespace Libertese.Domain.Entities.Precificacao
{
    public class CapacidadeProdutiva : BaseEntity
    {
        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; }

        public int Tempo { get; set; }

        public decimal Custo { get; set; }
    }
}
