using Microsoft.AspNetCore.Mvc;
using Libertese.ViewModels;
using Libertese.Domain.Entities.Cadastro;
using Libertese.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace Libertese.Web.Controllers.Cadastro
{
    [ApiController]
    [Route("api/v1/user")]
    public class CadastroController : ControllerBase
    {

        private readonly IUsuarioRepository _userRepository;

        public CadastroController(IUsuarioRepository userRepository)
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

            var user = new Usuario(userView.Nome, userView.Email, userView.Senha);
            _userRepository.Add(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginView)
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
            
            else 
            {
            
                var claims = new List<Claim>
			    {
			    	new Claim(ClaimTypes.Name, user.Email),
                    new Claim("EmpresasParceiras", "EMPP"),
                    new Claim("Funcionarios", "FUNC"),
                    new Claim("Classificacoes", "CLAF"),
                    new Claim("Clientes", "CLIE"),
                    new Claim("ContaBancarias", "COBA"),
                    new Claim("Despesas", "DESP"),
                    new Claim("FormaPagamentos", "FOPA"),
                    new Claim("Fornecedores", "FORN"),
                    new Claim("Receitas", "RECE"),
                    new Claim("CapacidadeProdutivas", "CAPP"),
                    new Claim("Categorias", "CATE"),
                    new Claim("Materiais", "MATE"),
                    new Claim("Precos", "PREC"),
                    new Claim("Produtos", "PROD"),
                    new Claim("Vendas", "VEND"),
                    new Claim("Rateios", "RATE"),
                    new Claim("Relatorios", "RELA"),
                    new Claim("Vendas", "VEND"),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var authProperties = new AuthenticationProperties
				{
					IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
                };

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity), authProperties);

				return Ok();
			}
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Usuarios = _userRepository.Get();
            return Ok(Usuarios);
        }
    }
}
