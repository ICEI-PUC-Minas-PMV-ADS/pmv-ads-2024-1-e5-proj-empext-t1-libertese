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

namespace Libertese.Web.Controllers.Financeiro
{

    [Authorize(Policy = "RequireDespesas")]
    public class DespesasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DespesasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Despesas
        public async Task<IActionResult> Index()
        {
            List<Despesa> listaDespesas = await _context.Despesas.ToListAsync();
            List<Fornecedor> listaFornecedores = await GetListaFornecedores();
            List<Classificacao> listaClassificacoes = await GetListaClassificacoesDespesas();
            List<FormaPagamento> listaFormaPagamento = await GetListaFormaPagamento();
            List<ContaBancaria> listaContaBancaria = await GetListaContaBancaria();
            List<DespesaDTO> listaDespesaDTO = listaDespesas.Select(despesa => new DespesaDTO
            {
                Id = despesa.Id,
                Valor = despesa.Valor,
                Status = convertDespesaStatusToNome(despesa.Status),
                FormaPagamentoName = listaFormaPagamento.Find(x => x.Id == despesa.FormaPagamentoId)?.Descricao ?? "Sem Forma de Pagamento",
                Observacao = despesa.Observacao ?? "Sem Observações",
                DataVencimento = despesa.DataVencimento?.ToString("dd/MM/yyyy") ?? "Sem Data",
                DataPagamento = despesa.DataPagamento?.ToString("dd/MM/yyyy") ?? "Sem Data",
                DataAtualiza = despesa.DataAtualizacao?.ToString("dd/MM/yyyy") ?? "Sem Data",
                Classificacao = listaClassificacoes.Find(x => x.Id == despesa.ClassificacaoId)?.Descricao ?? "Sem Classificação",
                FornecedorName = listaFornecedores.Find(x => x.Id == despesa.FornecedorId)?.Nome ?? "Sem Fornecedor",
                ContaBancariaName = listaContaBancaria.Find(x => x.Id == despesa.ContaBancariaId)?.Nome ?? "Sem Conta Bancária",


            }).ToList();
            return View(listaDespesaDTO);
        }

        // GET: Despesas/Create
        public async Task<IActionResult> Create()
        {
            List<Classificacao> listaClassificacoes = await GetListaClassificacoesDespesas();
            List<Fornecedor> listaFornecedores = await GetListaFornecedores();
            List<FormaPagamento> listaFormaPagamento = await GetListaFormaPagamento();
            List<ContaBancaria> listaContaBancaria = await GetListaContaBancaria();
            ViewBag.ContaBancaria = listaFormaPagamento;
            ViewBag.FormaPagamento = listaFormaPagamento;
            ViewBag.Fornecedor = listaFornecedores;
            ViewBag.Classificacao = listaClassificacoes;
            return View();
        }

        // POST: Despesas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FornecedorId,FormaPagamentoId,ContaBancariaId,ClassificacaoId,Tipo,Descricao,Status,DataPagamento,DataVencimento,Observacao,Id,DataCriacao,DataAtualizacao,Valor")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<Classificacao> listaClassificacoes = await GetListaClassificacoesDespesas();
            List<Fornecedor> listaFornecedores = await GetListaFornecedores();
            List<FormaPagamento> listaFormaPagamento = await GetListaFormaPagamento();
            List<ContaBancaria> listaContaBancaria = await GetListaContaBancaria();
            ViewBag.ContaBancaria = listaContaBancaria;
            ViewBag.FormaPagamento = listaFormaPagamento;
            ViewBag.Fornecedor = listaFornecedores;
            ViewBag.Classificacao = listaClassificacoes;
            return View(despesa);
        }

        // GET: Despesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<Classificacao> listaClassificacoes = await GetListaClassificacoesDespesas();
            List<Fornecedor> listaFornecedores = await GetListaFornecedores();
            List<FormaPagamento> listaFormaPagamento = await GetListaFormaPagamento();
            List<ContaBancaria> listaContaBancaria = await GetListaContaBancaria();
            ViewBag.ContaBancaria = listaContaBancaria;
            ViewBag.FormaPagamento = listaFormaPagamento;
            ViewBag.Fornecedor = listaFornecedores;
            ViewBag.Classificacao = listaClassificacoes;
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa == null)
            {
                return NotFound();
            }
            return View(despesa);
        }

        // POST: Despesas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FornecedorId,FormaPagamentoId,ContaBancariaId,ClassificacaoId,Tipo,Descricao,Status,DataPagamento,DataVencimento,Observacao,Id,DataCriacao,DataAtualizacao,Valor")] Despesa despesa)
        {
            if (id != despesa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesaExists(despesa.Id))
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
            List<Classificacao> listaClassificacoes = await GetListaClassificacoesDespesas();
            List<Fornecedor> listaFornecedores = await GetListaFornecedores();
            List<FormaPagamento> listaFormaPagamento = await GetListaFormaPagamento();
            List<ContaBancaria> listaContaBancaria = await GetListaContaBancaria();
            ViewBag.ContaBancaria = listaContaBancaria;
            ViewBag.FormaPagamento = listaFormaPagamento;
            ViewBag.Fornecedor = listaFornecedores;
            ViewBag.Classificacao = listaClassificacoes;
            return View(despesa);
        }

        // POST: Despesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa != null)
            {
                _context.Despesas.Remove(despesa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespesaExists(int id)
        {
            return _context.Despesas.Any(e => e.Id == id);
        }

        private async Task<List<Classificacao>> GetListaClassificacoesDespesas()
        {
            return await _context.Classificacoes.Where(x => x.Tipo == (int)ClassificacaoTipo.Despesas).ToListAsync();
        }
        private async Task<List<FormaPagamento>> GetListaFormaPagamento()
        {
            return await _context.FormaPagamentos.ToListAsync();
        }
        private async Task<List<Fornecedor>> GetListaFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }
        private async Task<List<ContaBancaria>> GetListaContaBancaria()
        {
            return await _context.ContasBancarias.ToListAsync();
        }

        private string convertDespesaStatusToNome(DespesaStatus despesaStatus)
        {
            switch (despesaStatus)
            {
                case DespesaStatus.Pago:
                    return DespesaStatusNomes.Pago;
                case DespesaStatus.APagar:
                    return DespesaStatusNomes.APagar;
                case DespesaStatus.Agendado:
                    return DespesaStatusNomes.Agendado;
                default:
                    return "Undefinded";
            }
        }
    }
}
