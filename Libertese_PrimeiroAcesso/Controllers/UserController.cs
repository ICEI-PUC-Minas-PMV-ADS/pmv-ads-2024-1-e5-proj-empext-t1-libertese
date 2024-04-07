using Libertese_PrimeiroAcesso.Model;
using Libertese_PrimeiroAcesso.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Libertese_PrimeiroAcesso.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpPost]
        public IActionResult Add([FromForm] UserViewModel userView)
        {
            var user = new User(userView.Nome, userView.Email, userView.Senha);
            _userRepository.Add(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Usuarios = _userRepository.Get();
            return Ok(Usuarios);
        }
    }
}
