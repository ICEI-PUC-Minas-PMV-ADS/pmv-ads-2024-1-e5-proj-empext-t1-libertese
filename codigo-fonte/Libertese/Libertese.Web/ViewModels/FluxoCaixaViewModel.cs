using System.Collections.Generic;
using Libertese.Domain.Entities.Financeiro;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libertese.Web.ViewModels
{
    public class FluxoCaixaViewModel
    {
        public List<DespesaDTO> Despesas { get; set; }
        public decimal DespesasPagas { get; set; }
        public decimal SalariosFuncionarios { get; set; }
        public decimal DespesasAdicionais { get; set; }
        public decimal TotalSaidas { get; set; }
        public decimal TotalDespesasPagas { get; set; }
        public decimal TotalDespesasAdicionais { get; set; }
        public decimal TotalTotalSaidas { get; set; }
        public int? Month { get; set; }
        public List<SelectListItem> Meses { get; set; }
    }
}
