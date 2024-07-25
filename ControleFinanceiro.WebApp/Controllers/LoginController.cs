using ControleFinanceiro.Servicos.EntidadeServico;
using ControleFinanceiro.Servicos.Interfaces;
using ControleFinanceiro.Servicos.Servicos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class LoginController : Controller
    {
        protected readonly IServicoUsuario servicoUsuario;
        public LoginController(IServicoUsuario servicoUsuario)
        {
            this.servicoUsuario = servicoUsuario;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha) 
        {
            var usuario = await servicoUsuario.ObterUsuarioPorEmailSenha(email, senha);

            string token = GeradorToken(usuario);

            //Define o Token em cookie de autenticação
            var claims = new List<Claim> 
            {
               new Claim("id", usuario.Id.ToString()),
               new Claim(ClaimTypes.Name, usuario.NomeUsuario),
               new Claim("email", usuario.EmailUsuario) 
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticateProprieties = new AuthenticationProperties
            {
                IsPersistent= true,
                ExpiresUtc= DateTime.UtcNow.AddMinutes(30)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), authenticateProprieties);

            return RedirectToAction("Index", "Home");
        }
        public string GeradorToken (UsuarioVO usuarioVO)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler ();
            byte[] Chave = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", usuarioVO.Id.ToString()),
                    new Claim("nomeUsuario", usuarioVO.NomeUsuario),
                    new Claim("email", usuarioVO.EmailUsuario)
                }),

                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Chave), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return  tokenHandler.WriteToken(token);
        }
        public async Task<IActionResult> Deslogar()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
