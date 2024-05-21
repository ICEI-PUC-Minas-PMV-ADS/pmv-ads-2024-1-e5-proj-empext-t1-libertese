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
            return View(await _context.Vendas.ToListAsync());
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
                    _context.Add(_venda);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Quantidade,ValorUnitario,ValorTotal,Id,DataCriacao,DataAtualizacao")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.Id == id);
        }
    }
}
