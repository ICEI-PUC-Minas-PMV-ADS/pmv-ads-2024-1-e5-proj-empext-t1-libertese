using Libertese.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Libertese.Web.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult AccessDenided()
        {
            return View("~/Views/Usuarios/Login.cshtml");
        }
    }
}
