using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Libertese.Data;
using Libertese.Data.Services.Interfaces;
using Libertese.Domain.Entities.Precificacao;

namespace Libertese.Web.Controllers.Precificacao
{
    public class CategoriasController : Controller
    {
        private readonly IProdutoService _service;
        public CategoriasController(IProdutoService service) => _service = service;

        [Authorize, HttpGet, ActionName("Create")]
        public IActionResult Create() => View();

        [Authorize, HttpGet, ActionName("index")]
        public async Task<IActionResult> Index() => HandleOperationResult(await _service.BuscarCategoria());

        [Authorize, HttpGet, ActionName("Details")]
        public async Task<IActionResult> Details(int id) => HandleOperationResult(await _service.BuscarCategoria(id));

        [Authorize, HttpGet, ActionName("Edit")]
        public async Task<IActionResult> Edit(int id) => HandleOperationResult(await _service.BuscarCategoria(id));

        [Authorize, HttpGet, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id) => HandleOperationResult(await _service.BuscarCategoria(id));

        [Authorize, HttpPost, ActionName("Create"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmed(Categoria categoria) => HandleOperationResult(await _service.CriarCategoria(categoria), true);

        [Authorize, HttpPost, ActionName("Edit"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int id, Categoria categoria) => HandleOperationResult(await _service.AtualizarCategoria(id, categoria), true);

        [Authorize, HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => HandleOperationResult(await _service.DeletarCategoria(id), true);

        private IActionResult HandleOperationResult(OperationResult result, bool json = false)
        {
            if (result.Error == true && result.Data == null && result.Message.Contains("não encontrad")) return NotFound();
            if (result.Error == true && result.Data == null) return NotFound();
            if (result.Error) return BadRequest(new { Message = result.Message, Errors = result.Errors });
            if (!result.Error && json == true) return Ok(new { Data = result.Data, Message = result.Message });
            if (result.Error == false && result.Data != null && json == false) return View(result.Data);

            return StatusCode(422, new {Message = "Não foi possível processar a requisição." });
        }
    }
}
