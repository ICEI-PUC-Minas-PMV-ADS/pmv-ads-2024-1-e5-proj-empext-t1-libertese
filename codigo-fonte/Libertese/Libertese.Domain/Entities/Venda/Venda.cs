namespace Libertese.Domain.Entities.Venda
{
    public class Venda : BaseEntity
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
