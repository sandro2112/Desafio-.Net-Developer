using Desafio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        public IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public dynamic Login([FromBody] Object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            string user = data.nameUsuario.ToString();
            string password = data.passwordUsuario.ToString();

            Usuario usuario = Usuario.DB().Where(x => x.nameUsuario == user && x.passwordUsuario == password).FirstOrDefault();

            if (usuario == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }

            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                        
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", usuario.idUsuario),
                new Claim("usuario", usuario.nameUsuario)
            };

            var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires:DateTime.Now.AddHours(1),
                    signingCredentials:signIn
                    );

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            return new
            {
                success = true,
                message = "Éxito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
