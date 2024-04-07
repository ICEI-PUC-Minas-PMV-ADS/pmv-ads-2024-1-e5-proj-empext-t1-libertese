using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Cadastro;

namespace Libertese.Web.Controllers.Cadastro
{
    public class EmpresaParceirasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpresaParceirasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmpresaParceiras
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmpresasParceiras.ToListAsync());
        }

        // GET: EmpresaParceiras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaParceira = await _context.EmpresasParceiras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresaParceira == null)
            {
                return NotFound();
            }

            return View(empresaParceira);
        }

        // GET: EmpresaParceiras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpresaParceiras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Telefone,Cnpj,Email,Id,DataCriacao,DataAtualizacao")] EmpresaParceira empresaParceira)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresaParceira);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresaParceira);
        }

        // GET: EmpresaParceiras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaParceira = await _context.EmpresasParceiras.FindAsync(id);
            if (empresaParceira == null)
            {
                return NotFound();
            }
            return View(empresaParceira);
        }

        // POST: EmpresaParceiras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Telefone,Cnpj,Email,Id,DataCriacao,DataAtualizacao")] EmpresaParceira empresaParceira)
        {
            if (id != empresaParceira.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresaParceira);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaParceiraExists(empresaParceira.Id))
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
            return View(empresaParceira);
        }

        // GET: EmpresaParceiras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaParceira = await _context.EmpresasParceiras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresaParceira == null)
            {
                return NotFound();
            }

            return View(empresaParceira);
        }

        // POST: EmpresaParceiras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresaParceira = await _context.EmpresasParceiras.FindAsync(id);
            if (empresaParceira != null)
            {
                _context.EmpresasParceiras.Remove(empresaParceira);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaParceiraExists(int id)
        {
            return _context.EmpresasParceiras.Any(e => e.Id == id);
        }
    }
}
