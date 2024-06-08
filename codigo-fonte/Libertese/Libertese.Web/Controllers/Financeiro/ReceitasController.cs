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
using System.Collections;
using Microsoft.AspNetCore.Authorization;
using Libertese.ViewModels;

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

        // GET: Receita
        public async Task<IActionResult> Index()
        {
            List<Receita> listaReceita = await _context.Receitas.ToListAsync();
            List<Classificacao> listaClassificacoes = await GetListaClassificacoesReceita();
            List<FormaPagamento> listaFormaPagamento = await GetListaFormaPagamento();
            List<ReceitaDTO> listaReceitaDTO = listaReceita.Select(receita => new ReceitaDTO
            {
                Id = receita.Id,
                Valor = receita.Valor,
                Status = convertReceitaStatusToNome(receita.Status),
                FormaPagamento = listaFormaPagamento.Find(x => x.Id == receita.FormaPagamentoId)?.Descricao ?? "Sem Forma de Pagamento",
                Descricao = receita.Descricao ?? "Sem observações",
                DataPrevisao = receita.DataPrevisao?.ToString("dd/MM/yyyy") ?? "Sem data",
                DataRecebimento = receita.DataRecebimento?.ToString("dd/MM/yyyy") ?? "Sem data",
                DataCompetencia = receita.DataCompetencia?.ToString("dd/MM/yyyy") ?? "Sem data",
                DataAtualizacao = receita.DataAtualizacao?.ToString("dd/MM/yyyy") ?? "Sem Data",
                Classificacao = listaClassificacoes.Find(x => x.Id == receita.ClassificacaoId)?.Descricao ?? "Sem Classificação",

            }).ToList();
            return View(listaReceitaDTO);
        }

        // GET: Receita/Create
        public async Task<IActionResult> Create()
        {
            List<Classificacao> listaClassificacoes = await GetListaClassificacoesReceita();
            List<FormaPagamento> listaFormaPagamento = await GetListaFormaPagamento();
            ViewBag.FormaPagamento = listaFormaPagamento;
            ViewBag.Classificacao = listaClassificacoes;
            return View();
        }

        // POST: Receita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FornecedorId,FormaPagamentoId,ClassificacaoId,Tipo,Descricao,Status,DataPrevisao,DataRecebimento,DataCompetencia,Descricao,Id,DataCriacao,DataAtualizacao,Valor")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<Classificacao> listaClassificacoes = await GetListaClassificacoesReceita();
            List<FormaPagamento> listaFormaPagamento = await GetListaFormaPagamento();
            ViewBag.FormaPagamento = listaFormaPagamento;
            ViewBag.Classificacao = listaClassificacoes;
            return View(receita);
        }

        // GET: Receita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<Classificacao> listaClassificacoes = await GetListaClassificacoesReceita();
            List<FormaPagamento> listaFormaPagamento = await GetListaFormaPagamento();
            ViewBag.FormaPagamento = listaFormaPagamento;
            ViewBag.Classificacao = listaClassificacoes;
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

        // POST: Receita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FornecedorId,FormaPagamentoId,ClassificacaoId,Tipo,Descricao,Status,DataPrevisao,DataRecebimento,DataCompetencia,Id,DataCriacao,DataAtualizacao,Valor")] Receita receita)
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
            List<Classificacao> listaClassificacoes = await GetListaClassificacoesReceita();
            List<FormaPagamento> listaFormaPagamento = await GetListaFormaPagamento();
            ViewBag.FormaPagamento = listaFormaPagamento;
            ViewBag.Classificacao = listaClassificacoes;
            return View(receita);
        }

        // POST: Receita/Delete/5
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

        private async Task<List<Classificacao>> GetListaClassificacoesReceita()
        {
            return await _context.Classificacoes.Where(x => x.Tipo == (int)ClassificacaoTipo.Receitas).ToListAsync();
        }
        private async Task<List<FormaPagamento>> GetListaFormaPagamento()
        {
            return await _context.FormaPagamentos.ToListAsync();
        }


        private string convertReceitaStatusToNome(ReceitaStatus ReceitaStatus)
        {
            switch (ReceitaStatus)
            {
                case ReceitaStatus.Recebido:
                    return ReceitaStatusNomes.Recebido;
                case ReceitaStatus.AReceber:
                    return ReceitaStatusNomes.AReceber;
                default:
                    return "Undefinded";
            }
        }
    }
}
