namespace Libertese.Domain.Entities.Precificacao
{
    public class Produto : BaseEntity
    {
        public required string Nome { get; set; }    
        public int TempoProducao { get; set;}

    }
}
