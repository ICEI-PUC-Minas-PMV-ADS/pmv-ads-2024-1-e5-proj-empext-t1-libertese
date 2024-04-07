using Microsoft.AspNetCore.Mvc;

namespace Libertese_PrimeiroAcesso.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
