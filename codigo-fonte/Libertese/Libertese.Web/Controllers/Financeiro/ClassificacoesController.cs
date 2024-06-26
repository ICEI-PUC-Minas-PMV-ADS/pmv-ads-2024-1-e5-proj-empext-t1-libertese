﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Domain.Enums;
using Libertese.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Libertese.Web.Controllers.Financeiro
{

    [Authorize(Policy = "RequireClassificacoes")]
    public class ClassificacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassificacoesController(ApplicationDbContext context)
        {
            _context = context;
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
