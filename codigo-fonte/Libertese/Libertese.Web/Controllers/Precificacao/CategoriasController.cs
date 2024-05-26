using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Precificacao;
using Libertese.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Libertese.Web.Controllers.Precificacao
{
    [Authorize(Policy = "RequireCategorias")]
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Id,DataCriacao,DataAtualizacao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.DataCriacao = DateTime.Now;
                categoria.DataAtualizacao = DateTime.Now;

                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Id,DataCriacao,DataAtualizacao")] Categoria categoria)
        {

            var model = await _context.Categorias.FirstOrDefaultAsync(m => m.Id == id);

            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid && model != null)
            {
                try
                {
                    model.DataAtualizacao = DateTime.Now;
                    model.Nome = categoria.Nome;
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id))
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
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            bool existeProdutoComEssaCategoria = await _context.Produtos.AnyAsync(pm => pm.CategoriaId == id);
            if (categoria != null)
            {
                if (existeProdutoComEssaCategoria)
                {
                    var categorias = await _context.Categorias.ToListAsync();
                    ViewData["ErrorMessage"] = $"A categoria {categoria.Nome} está associado a um produto e não pode ser deletada.";
                    return View(nameof(Index), categorias);
                }

                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["ErrorMessage"] = $"A categoria ID: {id} informado não foi encontrado.";
                return View("ErrorView");
            }
        }

        // POST: Categorias/Search
        [HttpPost, ActionName("Search")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchText(string nome)
        {

            if (!string.IsNullOrEmpty(nome))
            {
                return View("Index", await _context.Categorias.Where(c => EF.Functions.Like(c.Nome.ToLower(), "%" + nome.ToLower() + "%")).ToListAsync());
            } 
            else 
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet, ActionName("SearchByText")]
        public JsonResult SearchByText([FromQuery(Name = "searchString")] string searchString)
        {
            var result  = _context.Categorias
                            .Where(x => EF.Functions.Like(x.Nome.ToLower(), "%" + searchString.ToLower() + "%"))
                            .Select(x => new OptionViewModel { Id = x.Id, Nome = x.Nome })
                            .Take(10)
                            .ToList();
            return Json(result);
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}