using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Cadastro;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Libertese.Web.Controllers.Cadastro
{
    [Authorize(Policy = "RequireFuncionarios")]
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuncionariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionarios.ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,HorasDia,DiasMes,Cpf,Sexo,Email,Celular,Function,Pessoareclusa,Pessoaegressa,Penitenciaria,CursoLibertese,Remuneracao,Salario,Id,DataCriacao,DataAtualizacao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,HorasDia,DiasMes,Cpf,Sexo,Email,Celular,Function,Pessoareclusa,Pessoaegressa,Penitenciaria,CursoLibertese,Remuneracao,Salario,Id,DataCriacao,DataAtualizacao")] Funcionario funcionario)
        {
            
            var model = await _context.Funcionarios.FirstOrDefaultAsync(m => m.Id == id);

            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid && model != null)
            {
                try
                {
                    model.DataAtualizacao = DateTime.Now;
                    model.Nome = funcionario.Nome;
                    model.Cpf = funcionario.Cpf;
                    model.Sexo = funcionario.Sexo;
                    model.Email = funcionario.Email;
                    model.Celular = funcionario.Celular;
                    model.Function = funcionario.Function;
                    model.Pessoareclusa = funcionario.Pessoareclusa;
                    model.Pessoaegressa = funcionario.Pessoaegressa;
                    model.Penitenciaria = funcionario.Penitenciaria;
                    model.CursoLibertese = funcionario.CursoLibertese;
                    model.Salario = funcionario.Salario;
                    model.DiasMes = funcionario.DiasMes;
                    model.HorasDia = funcionario.HorasDia;
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
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
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.Id == id);
        }
    }
}
