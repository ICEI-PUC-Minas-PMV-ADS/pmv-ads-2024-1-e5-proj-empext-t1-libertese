using Libertese.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Libertese.Web.Controllers
{
    public class HomeController : Controller
    {

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("~/Views/Usuarios/Login.cshtml");
        }

        public IActionResult Registro()
        {
            return View("~/Views/Usuarios/Registro.cshtml");
        }
    }
}
