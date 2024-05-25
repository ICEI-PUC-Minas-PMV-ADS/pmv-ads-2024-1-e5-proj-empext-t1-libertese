using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using Microsoft.AspNetCore.Authorization;

namespace Libertese.Web.Controllers.Financeiro
{

    [Authorize(Policy = "RequireFormaPagamentos")]
    public class FormaPagamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormaPagamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormaPagamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormaPagamentos.ToListAsync());
        }

        // GET: FormaPagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormaPagamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            return View(formaPagamento);
        }

        // GET: FormaPagamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormaPagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Id,DataCriacao,DataAtualizacao")] FormaPagamento formaPagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formaPagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaPagamento);
        }

        // GET: FormaPagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormaPagamentos.FindAsync(id);
            if (formaPagamento == null)
            {
                return NotFound();
            }
            return View(formaPagamento);
        }

        // POST: FormaPagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descricao,Id,DataCriacao,DataAtualizacao")] FormaPagamento formaPagamento)
        {
            if (id != formaPagamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formaPagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaPagamentoExists(formaPagamento.Id))
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
            return View(formaPagamento);
        }

        // GET: FormaPagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormaPagamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            return View(formaPagamento);
        }

        // POST: FormaPagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formaPagamento = await _context.FormaPagamentos.FindAsync(id);
            if (formaPagamento != null)
            {
                _context.FormaPagamentos.Remove(formaPagamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaPagamentoExists(int id)
        {
            return _context.FormaPagamentos.Any(e => e.Id == id);
        }
    }
}
