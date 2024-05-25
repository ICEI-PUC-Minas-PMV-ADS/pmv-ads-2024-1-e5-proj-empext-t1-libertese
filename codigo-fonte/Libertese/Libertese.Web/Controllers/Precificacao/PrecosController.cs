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
using Libertese.ViewModels;

namespace Libertese.Web.Controllers.Precificacao
{
    [Authorize(Policy = "RequirePrecos")]
    public class PrecosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrecosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Precos/Create
        public IActionResult Create()
        {
            var produto = new PrecificacaoCreateViewModel();
            return View(produto);
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
    }
}
