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

    [Authorize(Policy = "ContaBancarias")]
    public class ContaBancariasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContaBancariasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContaBancarias
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContasBancarias.ToListAsync());
        }

        // GET: ContaBancarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContasBancarias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contaBancaria == null)
            {
                return NotFound();
            }

            return View(contaBancaria);
        }

        // GET: ContaBancarias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContaBancarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Agencia,Conta,Pix,Id,DataCriacao,DataAtualizacao")] ContaBancaria contaBancaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contaBancaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contaBancaria);
        }

        // GET: ContaBancarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContasBancarias.FindAsync(id);
            if (contaBancaria == null)
            {
                return NotFound();
            }
            return View(contaBancaria);
        }

        // POST: ContaBancarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Agencia,Conta,Pix,Id,DataCriacao,DataAtualizacao")] ContaBancaria contaBancaria)
        {
            if (id != contaBancaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contaBancaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaBancariaExists(contaBancaria.Id))
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
            return View(contaBancaria);
        }

        // GET: ContaBancarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContasBancarias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contaBancaria == null)
            {
                return NotFound();
            }

            return View(contaBancaria);
        }

        // POST: ContaBancarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contaBancaria = await _context.ContasBancarias.FindAsync(id);
            if (contaBancaria != null)
            {
                _context.ContasBancarias.Remove(contaBancaria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaBancariaExists(int id)
        {
            return _context.ContasBancarias.Any(e => e.Id == id);
        }
    }
}
