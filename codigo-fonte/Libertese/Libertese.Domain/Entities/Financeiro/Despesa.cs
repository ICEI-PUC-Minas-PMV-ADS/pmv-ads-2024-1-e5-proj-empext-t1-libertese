using Libertese.Domain.Enums;

namespace Libertese.Domain.Entities.Financeiro
{
    public class Despesa : BaseEntity
    {
        public int FornecedorId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int ContaBancariaId { get; set; }
        public int ClassificacaoId { get; set; }
        public DespesaTipo Tipo { get; set; }
        public required string Descricao { get; set; }
        public DespesaStatus Status { get; set; }
        public DateTimeOffset? DataPagamento { get; set; }
        public DateTimeOffset? DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public decimal Valor {  get; set; }

    }
}
