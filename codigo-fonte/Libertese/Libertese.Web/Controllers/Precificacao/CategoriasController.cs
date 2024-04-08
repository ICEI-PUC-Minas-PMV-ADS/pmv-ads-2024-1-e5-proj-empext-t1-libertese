using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libertese.Data;
using Libertese.Domain.Entities.Precificacao;
using Libertese.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Libertese.Data.Repositories.Interfaces;
using Libertese.Data.Services.Interfaces;
using System.Data.Entity;

namespace Libertese.Web.Controllers.Precificacao
{
    public class CategoriasController : Controller
    {
        private readonly IProdutoService _service;
        private readonly ICategoriaRepository<Categoria> _repository;

        public CategoriasController(IProdutoService service, ICategoriaRepository<Categoria> repository)
        {
            _service = service;
            _repository = repository;
        }

        public async Task<IActionResult> Index() => View(await _repository.GetAll());
        public async Task<IActionResult> Details(int id) => HandleResult(await _service.BuscarCategoria(id));
        public async Task<IActionResult> Deletar(int id) => HandleOperationResult(await _service.DeletarCategoria(id));
        
        private IActionResult HandleOperationResult(OperationResult result)
        {
            if (result.Error) return BadRequest(new { Message = result.Message, Errors = result.Errors });
            if (!result.Error) return Ok(new { Data = result.Data, Message = result.Message });
            if (!result.Error && result.Data == null) return NotFound();

            return StatusCode(422, new {Message = "Não foi possível processar a requisição." });
        }

        private IActionResult HandleResult(OperationResult result)
        {
            if (result.Error && (result.Message.IndexOf("não encontrada.")) == -1) return NotFound();
            if (result.Error) return BadRequest(new { Message = result.Message, Errors = result.Errors });
            if (!result.Error) return View(result.Data); ;
            if (!result.Error && result.Data == null) return NotFound();

            return StatusCode(422, new { Message = "Não foi possível processar a requisição." });
        }
    }
}
