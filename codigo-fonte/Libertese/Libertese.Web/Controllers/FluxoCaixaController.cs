using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Libertese.Web.ViewModels;
using Libertese.Domain.Enums;
using Microsoft.Extensions.Logging;
using System.Globalization;


namespace Libertese.Web.Controllers
{
    public class FluxoCaixaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FluxoCaixaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fornecedor>> GetListaFornecedores()
        {
            var fornecedores = await _context.Fornecedores.ToListAsync();
            return fornecedores;
        }

        public async Task<List<Classificacao>> GetListaClassificacoesDespesas()
        {
            var classificacoes = await _context.Classificacoes.ToListAsync();
            return classificacoes;
        }

        public async Task<List<FormaPagamento>> GetListaFormaPagamento()
        {
            var formasPagamento = await _context.FormaPagamentos.ToListAsync();
            return formasPagamento;
        }

        public async Task<List<ContaBancaria>> GetListaContaBancaria()
        {
            var contasBancarias = await _context.ContasBancarias.ToListAsync();
            return contasBancarias;
        }

        public IActionResult Index(DateTime? periodoInicio, DateTime? periodoFim)
        {
            var despesas = _context.Despesas.ToList();
            var listaFornecedores = GetListaFornecedores().Result;
            var listaClassificacoes = GetListaClassificacoesDespesas().Result;
            var listaFormaPagamento = GetListaFormaPagamento().Result;
            var listaContaBancaria = GetListaContaBancaria().Result;

            var despesasDTO = new List<DespesaDTO>();

            foreach (var despesa in despesas)
            {
                var despesaDTO = new DespesaDTO
                {
                    Id = despesa.Id,
                    Valor = despesa.Valor,
                    Status = convertDespesaStatus(despesa.Status),
                    FormaPagamentoName = listaFormaPagamento.Find(x => x.Id == despesa.FormaPagamentoId)?.Descricao ?? "Sem Forma de Pagamento",
                    Observacao = despesa.Observacao ?? "Sem Observações",
                    DataVencimento = despesa.DataVencimento?.ToString("dd/MM/yyyy") ?? "Sem Data",
                    DataCompetencia = despesa.DataCompetencia?.ToString("dd/MM/yyyy") ?? "Sem Data",
                    DataPagamento = despesa.DataPagamento?.ToString("dd/MM/yyyy") ?? "Sem Data",
                    DataAtualiza = despesa.DataAtualizacao?.ToString("dd/MM/yyyy") ?? "Sem Data",
                    Classificacao = listaClassificacoes.Find(x => x.Id == despesa.ClassificacaoId)?.Descricao ?? "Sem Classificação",
                    FornecedorName = listaFornecedores.Find(x => x.Id == despesa.FornecedorId)?.Nome ?? "Sem Fornecedor",
                    ContaBancariaName = listaContaBancaria.Find(x => x.Id == despesa.ContaBancariaId)?.Nome ?? "Sem Conta Bancária",
                };

                despesasDTO.Add(despesaDTO);
            }

            var listaReceita = _context.Receitas.ToList();
            var receitasDTO = new List<ReceitaDTO>();

            foreach (var receita in listaReceita)
            {
                var lista = new ReceitaDTO
                {
                    Id = receita.Id,
                    Valor = receita.Valor,
                    Status = convertReceitaStatus(receita.Status),
                    FormaPagamento = listaFormaPagamento.Find(x => x.Id == receita.FormaPagamentoId)?.Descricao ?? "Sem Forma de Pagamento",
                    Descricao = receita.Descricao ?? "Sem observações",
                    DataPrevisao = receita.DataPrevisao?.ToString("dd/MM/yyyy") ?? "Sem Data",
                    DataRecebimento = receita.DataRecebimento?.ToString("dd/MM/yyyy") ?? "Sem Data",
                    DataCompetencia = receita.DataCompetencia?.ToString("dd/MM/yyyy") ?? "Sem Data",
                    Classificacao = listaClassificacoes.Find(x => x.Id == receita.ClassificacaoId)?.Descricao ?? "Sem Classificação",
                };

                receitasDTO.Add(lista);
            }

            //var despesasNoPeriodo = despesasDTO.Where(d => d.DataCriacao >= periodoInicio && d.DataCriacao <= periodoFim);

            // Selecionar as classificações distintas das despesas filtradas


            if (!periodoInicio.HasValue || !periodoFim.HasValue)
            {
                periodoInicio = DateTime.Today;
                periodoFim = DateTime.Today;
            }

            var despesasNoPeriodo = despesasDTO.Where(d => DateTime.TryParseExact(d.DataCompetencia, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data) &&
                                               data >= periodoInicio &&
                                               data <= periodoFim)
                                    .ToList();

            var categoriasDespesas = despesasNoPeriodo.Select(d => d.Classificacao).Distinct().ToList();


            var receitasNoPeriodo = receitasDTO.Where(d => DateTime.TryParseExact(d.DataCompetencia, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data) &&
                                               data >= periodoInicio &&
                                               data <= periodoFim)
                                    .ToList();


            // Selecionar as classificações distintas das despesas filtradas
            var categoriasReceitas = receitasNoPeriodo.Select(d => d.Classificacao).Distinct().ToList();

            // Filtrar despesas pelo período, se os parâmetros de período forem fornecidos
            var filteredDespesas = despesasDTO;
            if (periodoInicio.HasValue && periodoFim.HasValue)
            {
                filteredDespesas = despesasDTO.Where(d => d.DataCriacao.HasValue &&
                                             d.DataCriacao.Value.Date >= periodoInicio.Value.Date &&
                                             d.DataCriacao.Value.Date <= periodoFim.Value.Date)
                                              .ToList();
            }

            // Passar dados para a ViewModel
            var viewModel = new FluxoCaixaViewModel
            {
                Despesas = despesasDTO,
                Receitas = receitasDTO,
                PeriodoInicio = periodoInicio,
                PeriodoFim = periodoFim,
                CategoriasDespesas = categoriasDespesas.ToList(),
                CategoriasReceitas = categoriasReceitas.ToList()
            };

            return View(viewModel);
        }

        private string convertDespesaStatus(DespesaStatus despesaStatus)
        {
            switch (despesaStatus)
            {
                case DespesaStatus.Pago:
                    return DespesaStatusNomes.Pago;
                case DespesaStatus.APagar:
                    return DespesaStatusNomes.APagar;
                case DespesaStatus.Agendado:
                    return DespesaStatusNomes.Agendado;
                default:
                    return "Undefinded";
            }
        }

        private string convertReceitaStatus(ReceitaStatus ReceitaStatus)
        {
            switch (ReceitaStatus)
            {
                case ReceitaStatus.Recebido:
                    return ReceitaStatusNomes.Recebido;
                case ReceitaStatus.AReceber:
                    return ReceitaStatusNomes.AReceber;
                default:
                    return "Undefinded";
            }
        }
    }
}

