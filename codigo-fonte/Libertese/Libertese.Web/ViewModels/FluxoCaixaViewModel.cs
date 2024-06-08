using System.Collections.Generic;
using Libertese.Domain.Entities.Financeiro;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libertese.Web.ViewModels
{
    public class FluxoCaixaViewModel
    {
        public List<DespesaDTO> Despesas { get; set; }

        public List<ReceitaDTO> Receitas { get; set; }
        public List<string> CategoriasDespesas { get; set; }
        public List<string> CategoriasReceitas { get; set; }
        public DateTime? PeriodoInicio { get; set; }
        public DateTime? PeriodoFim { get; set; }
    }
}
