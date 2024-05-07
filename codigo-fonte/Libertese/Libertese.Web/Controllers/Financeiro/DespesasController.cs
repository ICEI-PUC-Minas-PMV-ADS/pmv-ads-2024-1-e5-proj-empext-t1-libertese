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

namespace Libertese.Web.Controllers.Financeiro
{
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
            List<Fornecedor> listaFornecedores = await _context.Fornecedores.ToListAsync();
            List<Classificacao> listaClassificacoes = await _context.Classificacoes.Where(x => x.Tipo == (int)ClassificacaoTipo.Despesas).ToListAsync();
            List<DespesaDTO> listaDespesaDTO = listaDespesas.Select(despesa => new DespesaDTO
            {
                Id = despesa.Id,
                Valor = despesa.Valor,
                Tipo = convertDespesaTipoToNome(despesa.Tipo),
                Status = convertDespesaStatusToNome(despesa.Status),
                FormaPagamentoName = convertFormaPagamentoToNome(despesa.FormaPagamentoId),
                Descricao = despesa.Descricao,
                DataVencimento = despesa.DataVencimento?.ToString("dd/MM/yyyy") ?? "Sem Data",
                DataPagamento = despesa.DataPagamento?.ToString("dd/MM/yyyy") ?? "Sem Data",
                Classificacao = listaClassificacoes.Find(x => x.Id == despesa.ClassificacaoId)?.Descricao ?? "Sem Classificação",
                FornecedorName = listaFornecedores.Find(x => x.Id == despesa.FornecedorId)?.Nome ?? "Sem Fornecedor",

            }).ToList();
            return View(listaDespesaDTO);
        }

        private string convertDespesaTipoToNome(DespesaTipo despesaTipo)
        {
            switch (despesaTipo)
            {
                case DespesaTipo.Comprometido:
                    return DespesaTipoNomes.Comprometido;
                case DespesaTipo.GastoFixo:
                    return DespesaTipoNomes.GastoFixo;
                case DespesaTipo.GastoVariavel:
                    return DespesaTipoNomes.GastoVariavel;
                case DespesaTipo.Previsao:
                    return DespesaTipoNomes.Previsao;
                case DespesaTipo.Impostos:
                    return DespesaTipoNomes.Impostos;
                default:
                    return "Undefinded";
            }
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

        /*        // GET: Comprometido
                public async Task<IActionResult> Comprometido()
                {
                    List<Despesa> despesasComprometido = await _context.Despesas.ToListAsync();
                    return View(despesasComprometido.Where(x => x.Tipo == DespesaTipo.Comprometido));
                }
                // GET: Comprometido
                public async Task<IActionResult> GastoFixo()
                {
                    List<Despesa> despesasComprometido = await _context.Despesas.ToListAsync();
                    return View(despesasComprometido.Where(x => x.Tipo == DespesaTipo.GastoFixo));
                }

                // GET: Gasto Variavel
                public async Task<IActionResult> GastoVariavel()
                {
                    List<Despesa> despesasComprometido = await _context.Despesas.ToListAsync();
                    return View(despesasComprometido.Where(x => x.Tipo == DespesaTipo.GastoVariavel));
                }

                // GET: Previsao
                public async Task<IActionResult> Previsao()
                {
                    List<Despesa> despesasComprometido = await _context.Despesas.ToListAsync();
                    return View(despesasComprometido.Where(x => x.Tipo == DespesaTipo.Previsao));
                }

                // GET: Impostos
                public async Task<IActionResult> Impostos()
                {
                    List<Despesa> despesasComprometido = await _context.Despesas.ToListAsync();
                    return View(despesasComprometido.Where(x => x.Tipo == DespesaTipo.Impostos));
                }*/


        // GET: Despesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _context.Despesas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (despesa == null)
            {
                return NotFound();
            }

            return View(despesa);
        }

        // GET: Despesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Despesas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FornecedorId,FormaPagamentoId,ContaBancariaId,ClassificacaoId,Tipo,Descricao,Status,DataPagamento,DataVencimento,Observacao,Id,DataCriacao,DataAtualizacao")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(despesa);
        }

        // GET: Despesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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
        public async Task<IActionResult> Edit(int id, [Bind("FornecedorId,FormaPagamentoId,ContaBancariaId,ClassificacaoId,Tipo,Descricao,Status,DataPagamento,DataVencimento,Observacao,Id,DataCriacao,DataAtualizacao")] Despesa despesa)
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
            return View(despesa);
        }

        // GET: Despesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _context.Despesas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (despesa == null)
            {
                return NotFound();
            }

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
    }
}
