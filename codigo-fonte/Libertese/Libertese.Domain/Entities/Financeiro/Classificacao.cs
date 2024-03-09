namespace Libertese.Domain.Entities.Financeiro
{
    public class Classificacao : BaseEntity
    {
        public int Tipo  { get; set; }

        public required string Descricao { get; set; }
    }
}
