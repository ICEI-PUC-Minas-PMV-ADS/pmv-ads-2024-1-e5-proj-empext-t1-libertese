using Microsoft.AspNetCore.Mvc;
using PrimeiroAcesso.Model;
using PrimeiroAcesso.ViewModel;

namespace PrimeiroAcesso.Controllers
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
        public IActionResult Add([FromBody] UserViewModel userView)
        {
            if (userView == null || string.IsNullOrWhiteSpace(userView.Nome) || string.IsNullOrWhiteSpace(userView.Email) || string.IsNullOrWhiteSpace(userView.Senha))
            {
                return BadRequest("Dados de usuário inválidos. Certifique-se de fornecer um nome, um e-mail e uma senha.");
            }

            var user = new User(userView.Nome, userView.Email, userView.Senha);
            _userRepository.Add(user);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel loginView)
        {
            if (loginView == null || string.IsNullOrWhiteSpace(loginView.Email) || string.IsNullOrWhiteSpace(loginView.Senha))
            {
                return BadRequest("Por favor, forneça um e-mail e uma senha.");
            }

            var user = _userRepository.GetByEmail(loginView.Email);

            if (user == null || user.Senha != loginView.Senha)
            {
                return Unauthorized("Credenciais inválidas. Verifique seu e-mail e senha.");
            }

            // Se as credenciais forem válidas, você pode retornar algum token de autenticação ou simplesmente Ok() para indicar sucesso.
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
