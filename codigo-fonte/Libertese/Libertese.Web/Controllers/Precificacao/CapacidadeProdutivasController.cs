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

    [Authorize(Policy = "RequireCapacidadeProdutivas")]
    public class CapacidadeProdutivasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CapacidadeProdutivasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CapacidadeProdutivas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CapacidadeProdutivas.ToListAsync());
        }

        // GET: CapacidadeProdutivas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacidadeProdutiva = await _context.CapacidadeProdutivas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (capacidadeProdutiva == null)
            {
                return NotFound();
            }

            return View(capacidadeProdutiva);
        }

        // GET: CapacidadeProdutivas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CapacidadeProdutivas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Quantidade,Mes,Ano,Tempo,Custo,Id,DataCriacao,DataAtualizacao")] CapacidadeProdutiva capacidadeProdutiva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capacidadeProdutiva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(capacidadeProdutiva);
        }

        // GET: CapacidadeProdutivas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacidadeProdutiva = await _context.CapacidadeProdutivas.FindAsync(id);
            if (capacidadeProdutiva == null)
            {
                return NotFound();
            }
            return View(capacidadeProdutiva);
        }

        // POST: CapacidadeProdutivas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Quantidade,Mes,Ano,Tempo,Custo,Id,DataCriacao,DataAtualizacao")] CapacidadeProdutiva capacidadeProdutiva)
        {
            if (id != capacidadeProdutiva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capacidadeProdutiva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapacidadeProdutivaExists(capacidadeProdutiva.Id))
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
            return View(capacidadeProdutiva);
        }

        // GET: CapacidadeProdutivas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacidadeProdutiva = await _context.CapacidadeProdutivas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (capacidadeProdutiva == null)
            {
                return NotFound();
            }

            return View(capacidadeProdutiva);
        }

        // POST: CapacidadeProdutivas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capacidadeProdutiva = await _context.CapacidadeProdutivas.FindAsync(id);
            if (capacidadeProdutiva != null)
            {
                _context.CapacidadeProdutivas.Remove(capacidadeProdutiva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapacidadeProdutivaExists(int id)
        {
            return _context.CapacidadeProdutivas.Any(e => e.Id == id);
        }
    }
}
