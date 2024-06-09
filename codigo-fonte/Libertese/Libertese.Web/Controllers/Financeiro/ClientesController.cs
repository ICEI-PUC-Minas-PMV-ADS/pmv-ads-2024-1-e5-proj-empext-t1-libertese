using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using Libertese.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Libertese.Web.Controllers.Financeiro
{

    [Authorize(Policy = "RequireClientes")]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Create()
        {
            List<Cliente> listaCliente = await _context.Clientes.ToListAsync();
            List<ClienteDTO> listaClienteDTO = listaCliente.Select(cliente => new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                CpfCnpj = cliente.CpfCnpj,
                Telefone  = cliente.Telefone,
                Email = cliente.Email,

            }).ToList();
            return View(listaClienteDTO);
        }


        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,CpfCnpj,Telefone,Email,Id,DataCriacao,DataAtualizacao")] Cliente cliente)
        {
            List<Cliente> listaCliente = await _context.Clientes.ToListAsync();
            List<ClienteDTO> listaClienteDTO = listaCliente.Select(cliente => new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                CpfCnpj = cliente.CpfCnpj,
                Telefone = cliente.Telefone,
                Email = cliente.Email,

            }).ToList();
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Clientes");
            }
            return RedirectToAction("Create", "Clientes");
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            List<Cliente> listaCliente = await _context.Clientes.ToListAsync();
            List<ClienteDTO> listaClienteDTO = listaCliente.Select(cliente => new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                CpfCnpj = cliente.CpfCnpj,
                Telefone = cliente.Telefone,
                Email = cliente.Email,

            }).ToList();
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Create", "Clientes");
        }

        [HttpGet, ActionName("SearchByText")]
        public JsonResult SearchByText([FromQuery(Name = "searchString")] string searchString)
        {
            var result = _context.Clientes
                            .Where(x => EF.Functions.Like(x.Nome.ToLower(), "%" + searchString.ToLower() + "%"))
                            .Select(x => new OptionViewModel { Id = x.Id, Nome = x.Nome })
                            .Take(10)
                            .ToList();
            return Json(result);
        }


        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
