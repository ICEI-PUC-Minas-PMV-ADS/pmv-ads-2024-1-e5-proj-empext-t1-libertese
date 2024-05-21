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
using Newtonsoft.Json;

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
                            by new { produto.Id, produto.Nome, Categoria = categoria.Nome, produto.TempoProducao, preco.Valor, produto.DataCriacao, produto.DataAtualizacao } into gGroup
                            select new ProdutoViewModel
                            {
                                Id = gGroup.Key.Id,
                                Nome = gGroup.Key.Nome,
                                Categoria = gGroup.Key.Categoria,
                                TempoProducao = gGroup.Key.TempoProducao,
                                Custo = gGroup.Sum(x => x.produtoMaterial.Quantidade * x.material.Preco),
                                Preco = gGroup.Select(x => x.preco.Valor).Distinct().FirstOrDefault(),
                                Rateio = 0,
                                DataAtualizacao = gGroup.Key.DataAtualizacao,
                                DataCriacao = gGroup.Key.DataCriacao,
                                TotalMateriais = gGroup.Count(x => x.produtoMaterial != null && x.material != null),
                                Materiais = gGroup.Where(x => x.produtoMaterial != null && x.material != null)
                                      .Select(x => new MaterialViewModel
                                      {
                                          Id = x.material.Id,
                                          Nome = x.material.Nome,
                                          Preco = x.material.Preco,
                                          Quantidade = x.produtoMaterial.Quantidade
                                      }).ToList()
                            })
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
            var produto = new ProdutoCreateViewModel();
            return View(produto);
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Materiais,MateriaisJson,CategoriaId,Margem,TempoProducao,Id,DataCriacao,DataAtualizacao")] ProdutoCreateViewModel produto)
        {

            if(produto.MateriaisJson == null)
            {
                return View(produto);
            }            

            var materiais = new List<ProdutoMaterial>();
            produto.Materiais = produto.MateriaisJson != null ? JsonConvert.DeserializeObject<List<MaterialViewModel>>(produto.MateriaisJson) : [];

            if (ModelState.ContainsKey("Materiais") && ModelState["Materiais"].Errors.Count > 0 && produto.Materiais.Count() > 0)
            {
                ModelState["Materiais"].Errors.Clear();
            }

            if (ModelState.Values.Sum(v => v.Errors.Count) == 0)
            {
                produto.DataCriacao = DateTime.Now;
                produto.DataAtualizacao = DateTime.Now;

                var _produto = new Produto();
                _produto.DataCriacao = DateTime.Now;
                _produto.DataAtualizacao = DateTime.Now;
                _produto.Nome = produto.Nome;
                _produto.Margem = produto.Margem;
                _produto.TempoProducao = produto.TempoProducao;
                _produto.CategoriaId = (int)produto.CategoriaId;
                _context.Add(_produto);
                await _context.SaveChangesAsync();


                foreach (var item in produto.Materiais)
                {
                    var produtoMaterial = new ProdutoMaterial();
                    produtoMaterial.MateriaiId = item.Id;
                    produtoMaterial.Quantidade = item.Quantidade;
                    produtoMaterial.ProdutoId = _produto.Id;
                    produtoMaterial.DataCriacao = DateTime.Now;
                    produtoMaterial.DataAtualizacao = DateTime.Now;
                    _context.Add(produtoMaterial);
                    await _context.SaveChangesAsync();
                }

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

            var _produto = (from produto in _context.Produtos
                            join categoria in _context.Categorias on produto.CategoriaId equals categoria.Id into cGroup
                            from categoria in cGroup.DefaultIfEmpty()
                            join preco in _context.Precos on produto.Id equals preco.ProdutoId into pGroup
                            from preco in pGroup.DefaultIfEmpty()
                            join produtoMaterial in _context.ProdutoMaterial on produto.Id equals produtoMaterial.ProdutoId into pmGroup
                            from produtoMaterial in pmGroup.DefaultIfEmpty()
                            join material in _context.Materiais on produtoMaterial.MateriaiId equals material.Id into mGroup
                            from material in mGroup.DefaultIfEmpty()
                            where produto.Id == id
                            group new { produto, categoria, preco, produtoMaterial, material }
                            by new { produto.Id, produto.Nome, produto.Margem, Categoria = categoria.Nome, produto.TempoProducao, preco.Valor, produto.DataCriacao, produto.DataAtualizacao } into gGroup
                            select new ProdutoEditViewModel
                            {
                                Id = gGroup.Key.Id,
                                Nome = gGroup.Key.Nome,
                                CategoriaId = gGroup.Select(x => x.categoria.Id).Distinct().FirstOrDefault(),
                                SearchCategoria = gGroup.Key.Categoria,
                                TempoProducao = gGroup.Key.TempoProducao,
                                Margem = gGroup.Key.Margem,
                                DataAtualizacao = gGroup.Key.DataAtualizacao,
                                DataCriacao = gGroup.Key.DataCriacao,
                                MateriaisJson = JsonConvert.SerializeObject(gGroup.Where(x => x.produtoMaterial != null && x.material != null)
                                  .Select(x => new MaterialViewModel
                                  {
                                      Id = x.material.Id,
                                      Nome = x.material.Nome,
                                      Preco = x.material.Preco,
                                      Quantidade = x.produtoMaterial.Quantidade,
                                      ValorTotal = Math.Round((decimal)(x.produtoMaterial.Quantidade * x.material.Preco), 2)
                                  })),
                                Materiais = gGroup.Where(x => x.produtoMaterial != null && x.material != null)
                                  .Select(x => new MaterialViewModel
                                  {
                                      Id = x.material.Id,
                                      Nome = x.material.Nome,
                                      Preco = x.material.Preco,
                                      Quantidade = x.produtoMaterial.Quantidade,
                                      ValorTotal = Math.Round((decimal)(x.produtoMaterial.Quantidade * x.material.Preco), 2)
                                  }).ToList()
                            })
            .OrderBy(x => x.Id)
            .FirstOrDefault();

            if (_produto == null)
            {
                return NotFound();
            }
            return View(_produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SearchCategoria,Materiais,Nome,MateriaisJson,CategoriaId,Margem,TempoProducao,Id")] ProdutoEditViewModel produto)
        {

            if (id != produto.Id)
            {
                return NotFound();
            }

            var produtoExistente = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if (produto.MateriaisJson == null)
            {
                return View(produto);
            }

            var materiais = new List<ProdutoMaterial>();
            produto.Materiais = produto.MateriaisJson != null ? JsonConvert.DeserializeObject<List<MaterialViewModel>>(produto.MateriaisJson) : [];


            if (ModelState.ContainsKey("Materiais") && ModelState["Materiais"].Errors.Count > 0 && produto.Materiais.Count() > 0)
            {
                ModelState["Materiais"].Errors.Clear();
            }

            if (ModelState.Values.Sum(v => v.Errors.Count) == 0)
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        produtoExistente.DataAtualizacao = DateTime.Now;
                        produtoExistente.Nome = produto.Nome;
                        produtoExistente.Margem = produto.Margem;
                        produtoExistente.TempoProducao = produto.TempoProducao;
                        produtoExistente.CategoriaId = (int)produto.CategoriaId;
                        _context.Update(produtoExistente);
                        await _context.SaveChangesAsync();

                        var produtoMaterialParaDeletar = await _context.ProdutoMaterial.Where(p => p.ProdutoId == produtoExistente.Id).ToListAsync();
                        
                        if (produtoMaterialParaDeletar.Count() > 0)
                        {
                            _context.ProdutoMaterial.RemoveRange(produtoMaterialParaDeletar);
                        }

                        foreach (var item in produto.Materiais)
                        {
                            var produtoMaterial = new ProdutoMaterial();
                            produtoMaterial.MateriaiId = item.Id;
                            produtoMaterial.Quantidade = item.Quantidade;
                            produtoMaterial.ProdutoId = produtoExistente.Id;
                            produtoMaterial.DataCriacao = DateTime.Now;
                            produtoMaterial.DataAtualizacao = DateTime.Now;
                            _context.Add(produtoMaterial);
                            await _context.SaveChangesAsync();
                        }

                        await transaction.CommitAsync();

                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();

                        View(produto);
                    }
                }

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
                                by new { produto.Id, produto.Nome, Categoria = categoria.Nome, produto.TempoProducao, preco.Valor, produto.DataCriacao, produto.DataAtualizacao } into gGroup
                                select new ProdutoViewModel
                                {
                                    Id = gGroup.Key.Id,
                                    Nome = gGroup.Key.Nome,
                                    Categoria = gGroup.Key.Categoria,
                                    TempoProducao = gGroup.Key.TempoProducao,
                                    Custo = gGroup.Sum(x => x.produtoMaterial.Quantidade * x.material.Preco),
                                    Preco = gGroup.Select(x => x.preco.Valor).Distinct().FirstOrDefault(),
                                    Rateio = 0,
                                    DataAtualizacao = gGroup.Key.DataAtualizacao,
                                    DataCriacao = gGroup.Key.DataCriacao,
                                    TotalMateriais = gGroup.Count(x => x.produtoMaterial != null && x.material != null),
                                    Materiais = gGroup.Where(x => x.produtoMaterial != null && x.material != null)
                                      .Select(x => new MaterialViewModel
                                      {
                                          Id = x.material.Id,
                                          Nome = x.material.Nome,
                                          Preco = x.material.Preco,
                                          Quantidade = x.produtoMaterial.Quantidade
                                      }).ToList()
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
