using Libertese.Domain.Enums;

namespace Libertese.Domain.Entities.Financeiro
{
    public class Receita : BaseEntity
    {
        public int ClassificacaoId { get ; set; }
        public int ClienteId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int ContaBancariaId { get; set; }
        public DateTimeOffset? DataEmissao { get; set; }
        public DateTimeOffset? DataPrevisao { get; set; }
        public DateTimeOffset? DataVencimento { get; set; }
        public DateTimeOffset? DataRecebimento { get; set; }
        public required string Descricao { get; set; }
        public ReceitaStatus Status { get; set; }
    }
}
