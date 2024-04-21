using Microsoft.AspNetCore.Mvc;
using Libertese.Data.Services.Interfaces;
using Libertese.Domain.Entities.Precificacao;

namespace Libertese.Web.Controllers.Precificacao
{
    public class CategoriasController : BaseController<IProdutoService>
    {
        public CategoriasController(IProdutoService service) : base(service) {}

        [HttpGet]
        public async Task<IActionResult> Create() => View();

        [HttpGet]
        public async Task<IActionResult> Index() => HandleOperationResult(await _service.BuscarCategoria(), false);

        [HttpGet]
        public async Task<IActionResult> Edit(int id) => HandleOperationResult(await _service.BuscarCategoria(id), false);

        [HttpGet, ValidateAntiForgeryToken]
        public async Task<IActionResult> Get(int id) => HandleOperationResult(await _service.BuscarCategoria(id));

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria) => HandleOperationResult(await _service.CriarCategoria(categoria));

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Categoria categoria) => HandleOperationResult(await _service.AtualizarCategoria(id, categoria));

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) => HandleOperationResult(await _service.DeletarCategoria(id));
    }
}
