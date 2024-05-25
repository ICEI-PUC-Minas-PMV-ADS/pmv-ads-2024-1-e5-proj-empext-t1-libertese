using Microsoft.AspNetCore.Mvc;

namespace Libertese.Controllers
{
    public class FluxoCaixaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}