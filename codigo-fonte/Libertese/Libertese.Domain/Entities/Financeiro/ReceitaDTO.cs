using Libertese.Domain.Enums;

namespace Libertese.Domain.Entities.Financeiro
{
    public class ReceitaDTO : BaseEntity
    {
        public required string Classificacao { get ; set; } 
        public int ClienteId { get; set; }
        public required string FormaPagamento { get; set; }
        public DateTimeOffset? DataPrevisao { get; set; }
        public DateTimeOffset? DataRecebimento { get; set; }
        public required string Descricao { get; set; }
        public required string Status { get; set; }
    }
}
