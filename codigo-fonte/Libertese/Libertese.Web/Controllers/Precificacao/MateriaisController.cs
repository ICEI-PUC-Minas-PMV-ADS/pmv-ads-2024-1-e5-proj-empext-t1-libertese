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
    [Authorize(Policy = "RequireMateriais")]
    public class MateriaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Materiais
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materiais.ToListAsync());
        }

        // GET: Materiais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materiais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materiais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materiais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Preco,Id,DataCriacao,DataAtualizacao")] Material material)
        {
            if (ModelState.IsValid)
            {
                material.DataCriacao = DateTime.Now;
                material.DataAtualizacao = DateTime.Now;

                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: Materiais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materiais.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        // POST: Materiais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Material material)
        {
            var model = await _context.Materiais.FirstOrDefaultAsync(m => m.Id == id);

            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    model.DataAtualizacao = DateTime.Now;
                    model.Nome = material.Nome;
                    model.Preco = material.Preco;
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.Id))
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
            return View(material);
        }

        // GET: Materiais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materiais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materiais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _context.Materiais.FindAsync(id);
            if (material != null)
            {
                _context.Materiais.Remove(material);
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
                return View("Index", await _context.Materiais.Where(c => EF.Functions.Like(c.Nome.ToLower(), "%" + nome.ToLower() + "%")).ToListAsync());
            } 
            else 
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet, ActionName("SearchByText")]
        public JsonResult SearchByText([FromQuery(Name = "searchString")] string searchString)
        {
            var result = _context.Materiais
                            .Where(x => EF.Functions.Like(x.Nome.ToLower(), "%" + searchString.ToLower() + "%"))
                            .Select(x => new MaterialViewModel { 
                                Id = x.Id, 
                                Nome = x.Nome,
                                Quantidade = 1,
                                Preco = x.Preco,
                                ValorTotal = x.Preco * 1
                                
                            })
                            .Take(10)
                            .ToList();
            return Json(result);
        }


        private bool MaterialExists(int id)
        {
            return _context.Materiais.Any(e => e.Id == id);
        }

        
    }
}