using Libertese.Domain.Enums;

namespace Libertese.Domain.Entities.Financeiro
{
    public class ReceitaDTO : BaseEntity
    {
        public required string Classificacao { get ; set; } 
        public int ClienteId { get; set; }
        public required string FormaPagamento { get; set; }
        public required string DataPrevisao { get; set; }
        public required string DataRecebimento { get; set; }
        public required string DataCompetencia { get; set; }
        public required string DataAtualizacao { get; set; }
        public decimal Valor {  get; set; }
        public required string Descricao { get; set; }
        public required string Status { get; set; }
    }
}
