using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Precificacao;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Libertese.ViewModels;
using System.Text.RegularExpressions;

namespace Libertese.Web.Controllers.Precificacao
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {

            var produtos = (from produto in _context.Produtos
                            join categoria in _context.Categorias on produto.CategoriaId equals categoria.Id into cGroup
                            from categoria in cGroup.DefaultIfEmpty()
                            join preco in _context.Precos on produto.Id equals preco.ProdutoId into pGroup
                            from preco in pGroup.DefaultIfEmpty()
                            join produtoMaterial in _context.ProdutoMaterial on produto.Id equals produtoMaterial.ProdutoId into pmGroup
                            from produtoMaterial in pmGroup.DefaultIfEmpty()
                            join material in _context.Materiais on produtoMaterial.MateriaiId equals material.Id into mGroup
                            from material in mGroup.DefaultIfEmpty()
                            group new { produto, categoria, preco, produtoMaterial, material } 
                            by new { produto.Id, produto.Nome, Categoria = categoria.Nome, produto.TempoProducao, produto.DataCriacao, produto.DataAtualizacao } into gGroup
                            select new ProdutoViewModel
                            {
                                Id = gGroup.Key.Id,
                                Nome = gGroup.Key.Nome,
                                Categoria = gGroup.Key.Categoria,
                                TempoProducao = gGroup.Key.TempoProducao,
                                Custo = gGroup.Sum(x => x.produtoMaterial.Quantidade * x.material.Preco),
                                Preco = 0,
                                Rateio = 0,
                                DataAtualizacao = gGroup.Key.DataAtualizacao,
                                DataCriacao = gGroup.Key.DataCriacao                            })
                            .OrderBy(x => x.Id)
                            .ToList();





            return View(produtos);
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,TempoProducao,Id,DataCriacao,DataAtualizacao")] Produto produto)
        {

            if (ModelState.IsValid)
            {
                produto.DataCriacao = DateTime.Now;
                produto.DataAtualizacao = DateTime.Now;

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,TempoProducao,Id,DataCriacao,DataAtualizacao")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    produto.DataAtualizacao = DateTime.Now;
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Materiais/Search
        [HttpPost, ActionName("Search")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchText(string nome)
        {

            if (!string.IsNullOrEmpty(nome))
            {
                var produtos = (from produto in _context.Produtos
                                join categoria in _context.Categorias on produto.CategoriaId equals categoria.Id into cGroup
                                from categoria in cGroup.DefaultIfEmpty()
                                join preco in _context.Precos on produto.Id equals preco.ProdutoId into pGroup
                                from preco in pGroup.DefaultIfEmpty()
                                join produtoMaterial in _context.ProdutoMaterial on produto.Id equals produtoMaterial.ProdutoId into pmGroup
                                from produtoMaterial in pmGroup.DefaultIfEmpty()
                                join material in _context.Materiais on produtoMaterial.MateriaiId equals material.Id into mGroup
                                from material in mGroup.DefaultIfEmpty()
                                where EF.Functions.Like(produto.Nome.ToLower(), "%" + nome.ToLower() + "%")  
                                group new { produto, categoria, preco, produtoMaterial, material }
                                by new { produto.Id, produto.Nome, Categoria = categoria.Nome, produto.TempoProducao, produto.DataCriacao, produto.DataAtualizacao } into gGroup
                                select new ProdutoViewModel
                                {
                                    Id = gGroup.Key.Id,
                                    Nome = gGroup.Key.Nome,
                                    Categoria = gGroup.Key.Categoria,
                                    TempoProducao = gGroup.Key.TempoProducao,
                                    Custo = gGroup.Sum(x => x.produtoMaterial.Quantidade * x.material.Preco),
                                    Preco = 0,
                                    Rateio = 0,
                                    DataAtualizacao = gGroup.Key.DataAtualizacao,
                                    DataCriacao = gGroup.Key.DataCriacao
                                })
                            .OrderBy(x => x.Id)
                            .ToList();


                return View("Index", produtos);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
