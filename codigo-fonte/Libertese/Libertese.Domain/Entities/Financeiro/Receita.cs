using Libertese.Domain.Enums;

namespace Libertese.Domain.Entities.Financeiro
{
    public class Receita : BaseEntity
    {
        public int ClassificacaoId { get ; set; }
        public int FormaPagamentoId { get; set; }
        public DateTimeOffset? DataPrevisao { get; set; }
        public DateTimeOffset? DataRecebimento { get; set; }
        public DateTimeOffset? DataCompetencia { get; set; }
        public ReceitaStatus Status { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
