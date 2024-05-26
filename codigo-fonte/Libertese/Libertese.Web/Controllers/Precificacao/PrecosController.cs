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
            produto.Impostos = 0;
            produto.Comissao = 0;
            produto.TotalDeProdutos = 0;
            produto.TotalDeDespesas = 0;
            produto.CalcularTotalHorasMes();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TotalPessoas,HorasDiarias,DiasMes,TotalHorasMes,Impostos,Comissao,Produtos,ProdutosJson,Despesas,DespesasJson")] PrecificacaoCreateViewModel preco)
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

            if (ModelState.Values.Sum(v => v.Errors.Count) == 0)
            {
                _context.Add(preco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
            var contator = 0;

            foreach (var item in preco.Produtos)
            {
                var _percentualProducao = (item.Total / totalCustosDeProducao);
                var _valorRateio = (_percentualProducao * custosFixos);
                var _custoProdutoTotal = item.Total + _valorRateio;
                contator += 1;

                precificacaoRateios.Add(new PrecificacaoRateioViewModel
                {
                    Id = contator,
                    Nome = item.Nome,
                    CustoProducao = item.Total,
                    Margem = item.Margem,
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

                precificacaoPrecos.Add(new PrecificacaoPrecoViewModel
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    CustoUnitario = item.CustoProdutoUnitario,
                    Comissao = _comissao,
                    Imposto = _imposto,
                    Margem = item.Margem,
                    PrecoSugerido = Math.Round((decimal)(_precoSugerido), 2),
                    Lucro = Math.Round((decimal)(_precoSugerido - (_comissao + _imposto) - item.CustoProdutoUnitario), 2),
                    LucroTotal = 0
                });
            }

            preco.Precos = precificacaoPrecos;


            return View("~/Views/Precos/Create.cshtml", preco);


            if (ModelState.Values.Sum(v => v.Errors.Count) == 0)
            {
                _context.Add(preco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Precos/Create.cshtml", preco);
        }
    }
}
