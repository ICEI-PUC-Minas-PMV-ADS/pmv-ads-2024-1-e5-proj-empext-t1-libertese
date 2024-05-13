using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Domain.Enums;

namespace Libertese.Web.Controllers.Financeiro
{
    public class ClassificacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassificacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Classificacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classificacoes.ToListAsync());
        }

        // GET: Classificacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacao = await _context.Classificacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classificacao == null)
            {
                return NotFound();
            }

            return View(classificacao);
        }

        // GET: Classificacoes/Create/1
        public async Task<IActionResult> Create(int? tipo)
        {
            if (tipo == null)
            {
                return NotFound();
            }

            ViewBag.Tipo = tipo;

            var classificacoes = await _context.Classificacoes
                                            .Where(c => c.Tipo == tipo)
                                            .ToListAsync();
            return View(classificacoes);
        }

        // POST: Classificacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tipo,Descricao,Id,DataCriacao,DataAtualizacao")] Classificacao classificacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classificacao);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Create", "Classificacoes", new { tipo = classificacao.Tipo });
        }

        // GET: Classificacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacao = await _context.Classificacoes.FindAsync(id);
            if (classificacao == null)
            {
                return NotFound();
            }
            return View(classificacao);
        }

        // POST: Classificacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tipo,Descricao,Id,DataCriacao,DataAtualizacao")] Classificacao classificacao)
        {
            if (id != classificacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classificacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassificacaoExists(classificacao.Id))
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
            return View(classificacao);
        }

        // GET: Classificacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificacao = await _context.Classificacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classificacao == null)
            {
                return NotFound();
            }

            return View(classificacao);
        }

        // POST: Classificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int tipo)
        {
            var classificacao = await _context.Classificacoes.FindAsync(id);
            if (classificacao != null)
            {
                _context.Classificacoes.Remove(classificacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Create", "Classificacoes", new { tipo });
        }

        private bool ClassificacaoExists(int id)
        {
            return _context.Classificacoes.Any(e => e.Id == id);
        }
    }
}
