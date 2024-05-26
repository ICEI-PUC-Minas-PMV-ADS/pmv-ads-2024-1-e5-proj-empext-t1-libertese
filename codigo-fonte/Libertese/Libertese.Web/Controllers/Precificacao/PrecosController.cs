﻿using System;
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
