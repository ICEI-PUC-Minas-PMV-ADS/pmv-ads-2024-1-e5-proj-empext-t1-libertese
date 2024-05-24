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

namespace Libertese.Web.Controllers.Precificacao
{
    [Authorize(Policy = "Precos")]
    public class PrecosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrecosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Precos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Precos.ToListAsync());
        }

        // GET: Precos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preco = await _context.Precos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preco == null)
            {
                return NotFound();
            }

            return View(preco);
        }

        // GET: Precos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Precos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,RateioId,Vigencia,Id,DataCriacao,DataAtualizacao")] Preco preco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(preco);
        }

        // GET: Precos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preco = await _context.Precos.FindAsync(id);
            if (preco == null)
            {
                return NotFound();
            }
            return View(preco);
        }

        // POST: Precos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,RateioId,Vigencia,Id,DataCriacao,DataAtualizacao")] Preco preco)
        {
            if (id != preco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrecoExists(preco.Id))
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
            return View(preco);
        }

        // GET: Precos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preco = await _context.Precos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preco == null)
            {
                return NotFound();
            }

            return View(preco);
        }

        // POST: Precos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preco = await _context.Precos.FindAsync(id);
            if (preco != null)
            {
                _context.Precos.Remove(preco);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrecoExists(int id)
        {
            return _context.Precos.Any(e => e.Id == id);
        }
    }
}
