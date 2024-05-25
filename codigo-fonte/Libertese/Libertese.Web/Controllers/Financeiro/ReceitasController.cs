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
using Microsoft.AspNetCore.Authorization;

namespace Libertese.Web.Controllers.Financeiro
{

    [Authorize(Policy = "RequireReceitas")]
    public class ReceitasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Receitas
        public async Task<IActionResult> Index()
        {
            List<Receita> listaReceitas = await _context.Receitas.ToListAsync();
            List<Classificacao> listaClassificacoes = await _context.Classificacoes.Where(x => x.Tipo == (int)ClassificacaoTipo.Receitas).ToListAsync();
            List<ReceitaDTO> listaReceitaDTO = listaReceitas.Select(receita => new ReceitaDTO
            {
                Id = receita.Id,
                ClienteId = receita.ClienteId,
                FormaPagamento = convertFormaPagamentoToNome(receita.FormaPagamentoId),
                DataPrevisao = receita.DataPrevisao,
                DataRecebimento = receita.DataRecebimento,
                Descricao = receita.Descricao,
                Status = convertReceitaStatusToNome(receita.Status),
                Classificacao = listaClassificacoes.Find(x => x.Id == receita.ClassificacaoId)?.Descricao ?? "Sem Classificação",
            }).ToList();
            return View(listaReceitaDTO);
        }

        private string convertFormaPagamentoToNome(int formaPagamento)
        {
            switch ((FormaPagamentoEnum)formaPagamento)
            {
                case FormaPagamentoEnum.Boleto:
                    return FormaDePagamentoNomes.Boleto;
                case FormaPagamentoEnum.Cheque:
                    return FormaDePagamentoNomes.Cheque;
                case FormaPagamentoEnum.CreditoPrazo:
                    return FormaDePagamentoNomes.CreditoPrazo;
                case FormaPagamentoEnum.CreditoVista:
                    return FormaDePagamentoNomes.CreditoVista;
                case FormaPagamentoEnum.Debito:
                    return FormaDePagamentoNomes.Debito;
                case FormaPagamentoEnum.Dinheiro:
                    return FormaDePagamentoNomes.Dinheiro;
                case FormaPagamentoEnum.Pix:
                    return FormaDePagamentoNomes.Pix;
                case FormaPagamentoEnum.Transferencia:
                    return FormaDePagamentoNomes.Transferencia;
                default:
                    return "Undefinded";
            }
        }

        private string convertReceitaStatusToNome(ReceitaStatus receitaStatus)
        {
            switch (receitaStatus)
            {
                case ReceitaStatus.Faccao:
                    return "Facção";
                case ReceitaStatus.Patrocinio:
                    return "PatrocÍnio";
                case ReceitaStatus.VendasRegistradas:
                    return "Vendas Registradas";
                default:
                    return "Undefinded";
            }
        }

        // GET: Receitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receitas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // GET: Receitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassificacaoId,ClienteId,FormaPagamentoId,DataPrevisao,DataRecebimento,Descricao,Status")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receita);
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassificacaoId,ClienteId,FormaPagamentoId,DataPrevisao,DataRecebimento,Descricao,Status")] Receita receita)
        {
            if (id != receita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(receita.Id))
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
            return View(receita);
        }

        // GET: Receitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receitas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receita = await _context.Receitas.FindAsync(id);
            if (receita != null)
            {
                _context.Receitas.Remove(receita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(int id)
        {
            return _context.Receitas.Any(e => e.Id == id);
        }
    }
}
