using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using System.Collections.Generic;
using AutoMapper;
using Libertese.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Libertese.Web.Controllers
{
    public class FluxoCaixaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FluxoCaixaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index(int? month)
        {
            // Buscar dados de despesas e funcionários
            var despesas = _context.Despesas.ToList();
            var funcionarios = _context.Funcionarios.ToList();

            // Mapear Despesa para DespesaDTO usando AutoMapper
            var despesasDTO = _mapper.Map<List<DespesaDTO>>(despesas);

            // Obter meses únicos das despesas
            var meses = despesasDTO
                .Where(d => d.DataCriacao.HasValue)
                .Select(d => d.DataCriacao.Value.Month)
                .Distinct()
                .OrderBy(m => m)
                .ToList();

            // Criar lista de nomes de meses
            var mesesNomes = meses
                .Select(m => new SelectListItem
                {
                    Value = m.ToString(),
                    Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m)
                })
                .ToList();

            // Filtrar despesas por mês se o mês for fornecido
            var filteredDespesas = month.HasValue
                ? despesasDTO.Where(d => d.DataCriacao.HasValue && d.DataCriacao.Value.Month == month.Value).ToList()
                : despesasDTO;

            // Calcular valores
            var despesasPagas = filteredDespesas.Where(d => d.Status == "Pago").Sum(d => d.Valor);
            var salariosFuncionarios = funcionarios
                .Where(f => decimal.TryParse(f.Salario, out _))
                .Sum(f => decimal.Parse(f.Salario));
            //var despesasAdicionais = filteredDespesas.Where(d => d.Status != "Pago").Sum(d => d.Valor);
            var totalSaidas = despesasPagas + salariosFuncionarios /*+ despesasAdicionais*/;

            // Calcular totais gerais
            var totalDespesasPagas = despesasDTO.Where(d => d.Status == "Pago").Sum(d => d.Valor);
            var totalDespesasAdicionais = despesasDTO.Where(d => d.Status != "Pago").Sum(d => d.Valor);
            var totalTotalSaidas = totalDespesasPagas + salariosFuncionarios + totalDespesasAdicionais;

            // Passar dados para a ViewModel
            var viewModel = new FluxoCaixaViewModel
            {
                DespesasPagas = despesasPagas,
                SalariosFuncionarios = salariosFuncionarios,
                //DespesasAdicionais = despesasAdicionais,
                TotalSaidas = totalSaidas,
                TotalDespesasPagas = totalDespesasPagas,
                TotalDespesasAdicionais = totalDespesasAdicionais,
                TotalTotalSaidas = totalTotalSaidas,
                Despesas = despesasDTO,
                Month = month,
                Meses = mesesNomes
            };

            return View(viewModel);
        }
    }
}
