namespace Libertese.Domain.Entities.Precificacao
{
    public class Rateio : BaseEntity
    {
        public int CapacidadeProdutivaId { get; set; }

        public decimal CustoFixo { get; set; }

        public decimal Valor { get; set; }

        public float Percentual { get; set; }

        public decimal CustoUnitario { get; set; }
    }
}
