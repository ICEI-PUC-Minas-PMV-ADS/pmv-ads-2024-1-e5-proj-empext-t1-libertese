using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Precificacao;
using Microsoft.AspNetCore.Authorization;
using Libertese.ViewModels;
using Newtonsoft.Json;

namespace Libertese.Web.Controllers.Precificacao
{
    [Authorize(Policy = "RequirePrecos")]
    public class PrecosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrecosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Precos/Create
        public IActionResult Create()
        {
            var produto = new PrecificacaoCreateViewModel();
            produto.TotalPessoas = 1;
            produto.HorasDiarias = 8;
            produto.DiasMes = 22;
            produto.DespesaCompetencia = DateTime.Now;
            produto.Impostos = 0;
            produto.Comissao = 0;
            produto.TotalDeProdutos = 0;
            produto.TotalDeDespesas = 0;
            produto.CalcularTotalHorasMes();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TotalPessoas,HorasDiarias,DiasMes,TotalHorasMes,Impostos,Comissao,Produtos,ProdutosJson,Despesas,DespesasJson,Rateios,RateiosJson,Precos,PrecosJson")] PrecificacaoCreateViewModel preco)
        {
            //validando produtos 
            if (preco.ProdutosJson == null)
            {
                return View(preco);
            }

            var precificacaoProduto = new List<PrecificacaoProdutoViewModel>();
            preco.Produtos = preco.ProdutosJson != null ? JsonConvert.DeserializeObject<List<PrecificacaoProdutoViewModel>>(preco.ProdutosJson) : [];

            if (ModelState.ContainsKey("Produtos") && ModelState["Produtos"].Errors.Count > 0 && preco.Produtos.Count() > 0)
            {
                ModelState["Produtos"].Errors.Clear();
                preco.TotalDeProdutos = preco.Produtos.Count();
            }

            var tempoProducaoTotal = (preco.Produtos.Sum(x => x.TempoProducaoTotal) / 60);

            if (tempoProducaoTotal > preco.TotalHorasMes)
            {
                ModelState.AddModelError("Produtos", "O tempo de produção não pode exceder o total de horas mês.");
              
            }

            //validando despesas 
            if (preco.DespesasJson == null)
            {
                return View(preco);
            }

            var precificacaoDespesas = new List<PrecificacaoDespesaViewModel>();
            preco.Despesas = preco.DespesasJson != null ? JsonConvert.DeserializeObject<List<PrecificacaoDespesaViewModel>>(preco.DespesasJson) : [];

            if (ModelState.ContainsKey("Despesas") && ModelState["Despesas"].Errors.Count > 0 && preco.Despesas.Count() > 0)
            {
                ModelState["Despesas"].Errors.Clear();
                preco.TotalDeDespesas = preco.Despesas.Count();
            }

            //validando rateio 
            if (preco.RateiosJson == null)
            {
                return View(preco);
            }

            var precificacaoRateios = new List<PrecificacaoRateioViewModel>();
            preco.Rateios = preco.RateiosJson != null ? JsonConvert.DeserializeObject<List<PrecificacaoRateioViewModel>>(preco.RateiosJson) : [];

            if (ModelState.ContainsKey("Rateios") && ModelState["Rateios"].Errors.Count > 0 && preco.Rateios.Count() > 0)
            {
                ModelState["Rateios"].Errors.Clear();
                preco.TotalDeRateios = preco.Rateios.Count();
            }

            //validando precos 
            if (preco.PrecosJson == null)
            {
                return View(preco);
            }

            var precificacaoPrecos = new List<PrecificacaoPrecoViewModel>();
            preco.Precos = preco.PrecosJson != null ? JsonConvert.DeserializeObject<List<PrecificacaoPrecoViewModel>>(preco.PrecosJson) : [];

            if (ModelState.ContainsKey("Precos") && ModelState["Precos"].Errors.Count > 0 && preco.Precos.Count() > 0)
            {
                ModelState["Precos"].Errors.Clear();
                preco.TotalDePrecos = preco.Precos.Count();
            }

            if (ModelState.Values.Sum(v => v.Errors.Count) == 0)
            {
                var _now = DateTime.Now;

                foreach (var item in preco.Precos)
                {
                    var _deletarRateios = _context.Rateios.Where(p => p.ProdutoId == item.Id).ToList();
                    var _deletarCapacidadeProdutiva = _context.CapacidadeProdutivas.Where(p => p.ProdutoId == item.Id).ToList();
                    var _deletarPrecos = _context.Precos.Where(p => p.ProdutoId == item.Id).ToList();

                    if (_deletarRateios.Count() > 0) _context.Rateios.RemoveRange(_deletarRateios);
                    if (_deletarCapacidadeProdutiva.Count() > 0) _context.CapacidadeProdutivas.RemoveRange(_deletarCapacidadeProdutiva);
                    if (_deletarPrecos.Count() > 0) _context.Precos.RemoveRange(_deletarPrecos);


                    var _capacidadeProdutiva = new CapacidadeProdutiva();
                    var _produtoViewModel = preco.Produtos.FirstOrDefault(x => x.Id == item.Id);
                    var _rateioViewModel = preco.Rateios.FirstOrDefault(x => x.Id == item.Id);
                    _capacidadeProdutiva.DataCriacao = _now;
                    _capacidadeProdutiva.DataAtualizacao = _now;
                    _capacidadeProdutiva.ProdutoId = item.Id;
                    _capacidadeProdutiva.Quantidade = item.Quantidade;
                    _capacidadeProdutiva.Mes = _now.Month;
                    _capacidadeProdutiva.Ano = _now.Year;
                    _capacidadeProdutiva.Tempo = _produtoViewModel.TempoProducaoTotal;
                    _capacidadeProdutiva.Custo = Math.Round((decimal)(_produtoViewModel.Quantidade * _produtoViewModel.Custo), 2);
                    _context.Add(_capacidadeProdutiva);
                    await _context.SaveChangesAsync();

                    var _rateio = new Rateio();
                    _rateio.ProdutoId = _produtoViewModel.Id;
                    _rateio.CapacidadeProdutivaId = _capacidadeProdutiva.Id;
                    _rateio.CustoFixo = (decimal)_rateioViewModel.CustoProducao;
                    _rateio.Valor = (decimal)_rateioViewModel.ValorRateio;
                    _rateio.Percentual = (float)_rateioViewModel.PercentualProducao;
                    _rateio.CustoUnitario = (decimal)_rateioViewModel.CustoProdutoUnitario;
                    _rateio.DataCriacao = _now;
                    _rateio.DataAtualizacao = _now;
                    _context.Add(_rateio);
                    await _context.SaveChangesAsync();


                    var _preco = new Preco();
                    _preco.ProdutoId = _produtoViewModel.Id;  
                    _preco.RateioId = _rateio.Id;
                    _preco.Vigencia = _now;
                    _preco.DataCriacao = _now;
                    _preco.DataAtualizacao = _now;
                    _preco.Valor = (decimal)item.PrecoSugerido;
                    _context.Add(_preco);
                    await _context.SaveChangesAsync();
                
                }

                return RedirectToAction("Index", "Produtos");
            }

            return View(preco);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CalcularRateio([Bind("TotalDeProdutos,TotalDeDespesas,TotalPessoas,HorasDiarias,DiasMes,TotalHorasMes,Impostos,Comissao,Produtos,ProdutosJson,Despesas,DespesasJson")] PrecificacaoCreateViewModel preco)
        {
            //validando produtos 
            if (preco.ProdutosJson == null)
            {
                return View("~/Views/Precos/Create.cshtml", preco);
            }

            var precificacaoProduto = new List<PrecificacaoProdutoViewModel>();
            preco.Produtos = preco.ProdutosJson != null ? JsonConvert.DeserializeObject<List<PrecificacaoProdutoViewModel>>(preco.ProdutosJson) : [];

            if (ModelState.ContainsKey("Produtos") && ModelState["Produtos"].Errors.Count > 0 && preco.Produtos.Count() > 0)
            {
                ModelState["Produtos"].Errors.Clear();
                preco.TotalDeProdutos = preco.Produtos.Count();
            }

            var tempoProducaoTotal = (preco.Produtos.Sum(x => x.TempoProducaoTotal) / 60);

            if (tempoProducaoTotal > preco.TotalHorasMes)
            {
                ModelState.AddModelError("Produtos", "O tempo de produção não pode exceder o total de horas mês.");

            }

            //validando despesas 
            if (preco.DespesasJson == null)
            {
                return View("~/Views/Precos/Create.cshtml", preco);
            }

            var precificacaoDespesas = new List<PrecificacaoDespesaViewModel>();
            preco.Despesas = preco.DespesasJson != null ? JsonConvert.DeserializeObject<List<PrecificacaoDespesaViewModel>>(preco.DespesasJson) : [];

            if (ModelState.ContainsKey("Despesas") && ModelState["Despesas"].Errors.Count > 0 && preco.Despesas.Count() > 0)
            {
                ModelState["Despesas"].Errors.Clear();
                preco.TotalDeDespesas = preco.Despesas.Count();
            }


            // rateio (inicio)

            var custosFixos = preco.Despesas.Sum(x => x.Valor);
            var totalCustosDeProducao = preco.Produtos.Sum(x => x.Total);
            var precificacaoRateios = new List<PrecificacaoRateioViewModel>();

            foreach (var item in preco.Produtos)
            {
                var _percentualProducao = (item.Total / totalCustosDeProducao);
                var _valorRateio = (_percentualProducao * custosFixos);
                var _custoProdutoTotal = item.Total + _valorRateio;

                precificacaoRateios.Add(new PrecificacaoRateioViewModel
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    CustoProducao = item.Total,
                    Margem = item.Margem,
                    Quantidade = item.Quantidade,
                    PercentualProducao = _percentualProducao,
                    ValorRateio = Math.Round((decimal)(_valorRateio), 2),
                    CustoProdutoTotal = Math.Round((decimal)(_custoProdutoTotal), 2),
                    CustoProdutoUnitario = Math.Round((decimal)(_custoProdutoTotal /  item.Quantidade), 2)
                });
            }


            preco.Rateios = precificacaoRateios;
            var precificacaoPrecos = new List<PrecificacaoPrecoViewModel>();

            foreach (var item in preco.Rateios)
            {
                var _precoSugerido = ((item.CustoProdutoUnitario / 100) * item.Margem) + item.CustoProdutoUnitario;
                var _comissao = Math.Round((decimal)((preco.Comissao * _precoSugerido ) / 100), 2);
                var _imposto = Math.Round((decimal)((preco.Impostos * _precoSugerido) / 100), 2);
                _precoSugerido = Math.Round((decimal)(_precoSugerido), 2);
                var _lucro = Math.Round((decimal)(_precoSugerido - (_comissao + _imposto) - item.CustoProdutoUnitario), 2);
                var _lucroTotal = Math.Round((decimal)(_lucro * item.Quantidade), 2);

                precificacaoPrecos.Add(new PrecificacaoPrecoViewModel
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    CustoUnitario = item.CustoProdutoUnitario,
                    Comissao = _comissao,
                    Imposto = _imposto,
                    Margem = item.Margem,
                    PrecoSugerido = _precoSugerido,
                    Lucro = _lucro,
                    LucroTotal = _lucroTotal,
                    ValorRateio = item.ValorRateio,
                    Quantidade = item.Quantidade
                });
            }

            preco.Precos = precificacaoPrecos;


            return View("~/Views/Precos/Create.cshtml", preco);
        }
    }
}
