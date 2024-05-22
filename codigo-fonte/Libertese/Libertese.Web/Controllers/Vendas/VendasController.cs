using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Venda;
using Libertese.ViewModels;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Domain.Entities.Precificacao;
using Newtonsoft.Json;

namespace Libertese.Web.Controllers.Vendas
{
    public class VendasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var vendas = (from venda in _context.Vendas
                          join cliente in _context.Clientes on venda.ClienteId equals cliente.Id into cGroup
                          from cliente in cGroup.DefaultIfEmpty()
                          join produto in _context.Produtos on venda.ProdutoId equals produto.Id into pGroup
                          from produto in pGroup.DefaultIfEmpty()
                          group new { venda, cliente, produto }
                          by new { cliente.Nome, venda.Identificador } into gGroup
                          select new VendaViewModel
                          {
                              Id = gGroup.Key.Identificador,
                              Cliente = gGroup.Key.Nome,
                              Itens = gGroup.Count(x => x.produto != null),
                              Cancelamento = gGroup.Select(x => x.venda.DataCancelamento).Distinct().FirstOrDefault(),
                              Data = (DateTime)gGroup.Select(x => x.venda.DataCriacao).Distinct().FirstOrDefault(),
                              Hora = (DateTime)gGroup.Select(x => x.venda.DataCriacao).Distinct().FirstOrDefault(),
                              Valor = gGroup.Sum(x => x.venda.ValorTotal),
                              Produtos = gGroup.Where(x => x.produto != null)
                                        .Select(x => new ProdutoVendaViewModel
                                        {
                                            Id = x.produto.Id,
                                            Nome = x.produto.Nome,
                                            Quantidade = x.venda.Quantidade,
                                            Preco = x.venda.ValorUnitario,
                                            ValorTotal = x.venda.ValorTotal,
                                        }).ToList()
                          })
                          .OrderBy(x => x.Id)
                          .ToList();

               return View(vendas);
        }

    
        // GET: Vendas/Create
        public IActionResult Create()
        {
            var formaPagamento = _context.FormaPagamentos.ToList();
            var model = new VendaCreateViewModel();
            model.FormaPagamento = formaPagamento;
            return View(model);
        }


        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cliente,SearchCliente,Produtos,ProdutosJson,FormaPagamentoId,ClienteId,Id")] VendaCreateViewModel venda)
        {

            if (venda.ProdutosJson == null)
            {
                var formaPagamento = _context.FormaPagamentos.ToList();
                venda.FormaPagamento = formaPagamento;
                return View(venda);
            }

            venda.Produtos = venda.ProdutosJson != null ? JsonConvert.DeserializeObject<List<ProdutoVendaViewModel>>(venda.ProdutosJson) : [];

            if (ModelState.ContainsKey("Produtos") && ModelState["Produtos"].Errors.Count > 0 && venda.Produtos.Count > 0)
            {
                ModelState["Produtos"].Errors.Clear();
            }

            if (ModelState.Values.Sum(v => v.Errors.Count) == 0)
            {
                var dataCriacao = DateTime.Now;
                var dataAtualizacao = DateTime.Now;

                foreach (var item in venda.Produtos)
                {
                    var _venda = new Venda();
                    _venda.ProdutoId = item.Id;
                    _venda.ClienteId = venda.ClienteId;
                    _venda.Quantidade = item.Quantidade;
                    _venda.ValorUnitario = item.Preco;
                    _venda.ValorTotal = item.Quantidade * item.Preco;
                    _venda.DataCriacao = dataCriacao;
                    _venda.DataAtualizacao = dataAtualizacao;
                    _venda.Identificador = ((DateTimeOffset)dataCriacao).ToUnixTimeSeconds().ToString();
                    _context.Add(_venda);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }
        
        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dataCancelamento = DateTime.Now;
            var vendas = await _context.Vendas.Where(x => x.Identificador == id).ToListAsync();

            if (vendas != null)
            {
                foreach (var venda in vendas)
                {
                    venda.DataCancelamento = dataCancelamento;
                }
                
                _context.UpdateRange(vendas);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }

        // POST: Materiais/Search
        [HttpPost, ActionName("Search")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchText(string nome)
        {

            if (!string.IsNullOrEmpty(nome))
            {

                var vendas = (from venda in _context.Vendas
                              join cliente in _context.Clientes on venda.ClienteId equals cliente.Id into cGroup
                              from cliente in cGroup.DefaultIfEmpty()
                              join produto in _context.Produtos on venda.ProdutoId equals produto.Id into pGroup
                              from produto in pGroup.DefaultIfEmpty()
                              where EF.Functions.Like(cliente.Nome.ToLower(), "%" + nome.ToLower() + "%")
                              group new { venda, cliente, produto }
                              by new { cliente.Nome, venda.Identificador } into gGroup
                              select new VendaViewModel
                              {
                                  Id = gGroup.Key.Identificador,
                                  Cliente = gGroup.Key.Nome,
                                  Itens = gGroup.Count(x => x.produto != null),
                                  Cancelamento = gGroup.Select(x => x.venda.DataCancelamento).Distinct().FirstOrDefault(),
                                  Data = (DateTime)gGroup.Select(x => x.venda.DataCriacao).Distinct().FirstOrDefault(),
                                  Hora = (DateTime)gGroup.Select(x => x.venda.DataCriacao).Distinct().FirstOrDefault(),
                                  Valor = gGroup.Sum(x => x.venda.ValorTotal),
                                  Produtos = gGroup.Where(x => x.produto != null)
                                            .Select(x => new ProdutoVendaViewModel
                                            {
                                                Id = x.produto.Id,
                                                Nome = x.produto.Nome,
                                                Quantidade = x.venda.Quantidade,
                                                Preco = x.venda.ValorUnitario,
                                                ValorTotal = x.venda.ValorTotal,
                                            }).ToList()
                              })
              .OrderBy(x => x.Id)
              .ToList();

                return View("Index", vendas);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }


        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.Id == id);
        }
    }
}
