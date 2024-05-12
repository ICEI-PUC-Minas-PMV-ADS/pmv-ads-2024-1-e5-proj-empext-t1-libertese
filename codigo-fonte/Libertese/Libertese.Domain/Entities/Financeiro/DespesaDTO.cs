using Libertese.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libertese.Domain.Entities.Financeiro
{
    public class DespesaDTO : BaseEntity
    {
        public required string FornecedorName { get; set; }
        public required string FormaPagamentoName { get; set; }
        public required string Classificacao { get; set; }
        public required string Tipo { get; set; }
        public required string Descricao { get; set; }
        public required string Status { get; set; }
        public required string DataPagamento { get; set; }
        public required string DataVencimento { get; set; }
        public decimal Valor {  get; set; }
    }
}
