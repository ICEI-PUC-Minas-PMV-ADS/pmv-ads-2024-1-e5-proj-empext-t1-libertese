using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Domain.Entities.Precificacao;
using Libertese.Domain.Enums;

namespace Libertese.Web.Controllers.Financeiro
{
    public class FornecedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FornecedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fornecedores
        public async Task<IActionResult> Index()
        {
            List<Fornecedor> listaFornecedores = await _context.Fornecedores.ToListAsync();
            List<Material> listaMateriais = await _context.Materiais.ToListAsync();
            List<FornecedorDTO> listaFornecedorDTO = listaFornecedores.Select(fornecedor => new FornecedorDTO
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Endereco = fornecedor.Endereco,
                Cep = fornecedor.Cep,
                Cpf = fornecedor.Cpf,
                Cnpj = fornecedor.Cnpj,
                Telefone = fornecedor.Telefone,
                TelefoneDois = fornecedor.TelefoneDois,
                Email = fornecedor.Email,
                DadosBancariosId = fornecedor.DadosBancariosId,
                MaterialFornecido = listaMateriais.Find(x => x.Id == fornecedor.MaterialFornecidoId)?.Nome ?? "Sem Material",
            }).ToList();
            return View(listaFornecedorDTO);
        }

        // GET: Fornecedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        private async Task<List<Material>> GetListaMatereiais()
        {
            return await _context.Materiais.ToListAsync();
        }

        // GET: Fornecedores/Create
        public async Task<IActionResult> CreateAsync()
        {
            List<Material> listaMateriais = await GetListaMatereiais();
            ViewBag.Material = listaMateriais;
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Endereco,Cep,Cpf,Cnpj,Telefone,TelefoneDois,Email,DadosBancariosId,MaterialFornecidoId,Id,DataCriacao,DataAtualizacao")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<Material> listaMateriais = await GetListaMatereiais();
            ViewBag.Material = listaMateriais;
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Endereco,Cep,Cpf,Cnpj,Telefone,TelefoneDois,Email,DadosBancariosId,MaterialFornecidoId,Id,DataCriacao,DataAtualizacao")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.Id))
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
            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
