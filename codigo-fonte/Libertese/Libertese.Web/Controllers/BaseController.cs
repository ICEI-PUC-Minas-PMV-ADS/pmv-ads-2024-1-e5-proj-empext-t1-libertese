using Libertese.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Libertese.Web.Controllers
{
    [Authorize]
    public class BaseController<T> : Controller
    {
        protected readonly T _service;
        public BaseController(T service) => _service = service;

        protected IActionResult HandleOperationResult(OperationResult result, bool json = false)
        {
            if (result.Error == true && result.Data == null && result.Message.Contains("n�o encontrad")) return NotFound();
            if (result.Error == true && result.Data == null) return NotFound();
            if (result.Error) return BadRequest(new { Message = result.Message, Errors = result.Errors });
            if (!result.Error && json == true) return Ok(new { Data = result.Data, Message = result.Message });
            if (result.Error == false && result.Data != null && json == false) return View(result.Data);

            return StatusCode(422, new { Message = "N�o foi poss�vel processar a requisi��o." });
        }
    }
}
