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

    [Authorize(Policy = "Rateios")]
    public class RateiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RateiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rateios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rateios.ToListAsync());
        }

        // GET: Rateios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rateio = await _context.Rateios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rateio == null)
            {
                return NotFound();
            }

            return View(rateio);
        }

        // GET: Rateios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rateios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CapacidadeProdutivaId,CustoFixo,Valor,Percentual,CustoUnitario,Id,DataCriacao,DataAtualizacao")] Rateio rateio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rateio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rateio);
        }

        // GET: Rateios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rateio = await _context.Rateios.FindAsync(id);
            if (rateio == null)
            {
                return NotFound();
            }
            return View(rateio);
        }

        // POST: Rateios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CapacidadeProdutivaId,CustoFixo,Valor,Percentual,CustoUnitario,Id,DataCriacao,DataAtualizacao")] Rateio rateio)
        {
            if (id != rateio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rateio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RateioExists(rateio.Id))
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
            return View(rateio);
        }

        // GET: Rateios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rateio = await _context.Rateios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rateio == null)
            {
                return NotFound();
            }

            return View(rateio);
        }

        // POST: Rateios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rateio = await _context.Rateios.FindAsync(id);
            if (rateio != null)
            {
                _context.Rateios.Remove(rateio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RateioExists(int id)
        {
            return _context.Rateios.Any(e => e.Id == id);
        }
    }
}
