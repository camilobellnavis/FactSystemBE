using FactSystem.Api.Helpers;
using FactSystem.Application.Interfaces;
using FactSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FactSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly AppSettings _appSettings;

        public UsuariosController(IUsuarioService service, IOptions<AppSettings> appSettings)
        {
            _service = service;
            _appSettings = appSettings.Value;
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            var usuarios = _service.GetAll();

            return Ok(usuarios);
        }

        [AllowAnonymous]
        // POST api/<UsuariosController>
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Usuario user)
        {
            var userAuth = await _service.Authenticate(user.NombreUsuario,user.Contraseña);
            if (userAuth.IsSuccess)
            {
                if(userAuth.Data != null)
                {
                    userAuth.Token = BuildToken(userAuth.Data);
                    return Ok(userAuth);
                }
                return NotFound(userAuth.Message);
            }

            return BadRequest(userAuth.Message);
        }

        private string BuildToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.NombreUsuario)
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }


    }
}
