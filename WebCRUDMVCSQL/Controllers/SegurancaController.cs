using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebCRUDMVCSQL.Models;
//https://www.macoratti.net/19/04/aspncore_jwt1.htm parte 1 emplementada com sucesso

// falta essa parte 2 https://www.macoratti.net/19/04/aspncore_jwt2.htm


namespace WebCRUDMVCSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {
        private IConfiguration _config;
        public SegurancaController(IConfiguration Configuration)
        {
            _config = Configuration;
        }
        [HttpPost]
        public IActionResult Login([FromBody] USUARIOS loginDetalhes)
        {
            bool resultado = ValidarUsuario(loginDetalhes);
            if (resultado)
            {
                var tokenString = GerarTokenJWT();
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
        private string GerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
        private bool ValidarUsuario(USUARIOS loginDetalhes)
        {
            if (loginDetalhes.NOME_USUARIO == "Macoratti" && loginDetalhes.Senha == "Numsey$19")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
