using FactSystem.Api.Helpers;
using FactSystem.Application.Interfaces;
using FactSystem.Application.UsesCases;
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
        private readonly IUsuarioService _usuarioService;
        private readonly AppSettings _appSettings;

        public UsuariosController(IUsuarioService usuarioService, IOptions<AppSettings> appSettings)
        {
            _usuarioService = usuarioService;
            _appSettings = appSettings.Value;
        }
        // POST api/<UsuariosController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Usuario user)
        {
            if (user == null)
                return BadRequest();
            var response = await _usuarioService.Create(user);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [AllowAnonymous]
        // POST api/<UsuariosController>
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Usuario user)
        {
            var userAuth = await _usuarioService.Authenticate(user.NombreUsuario,user.Contraseña);
            if (userAuth.IsSuccess)
            {
                if(userAuth.Data != null)
                {
                    userAuth.Token = BuildToken(userAuth.Data);
                    return Ok(userAuth);
                }
                return Ok(userAuth);
            }

            return BadRequest(userAuth.Message);
        }
        
        // GET: api/<UsuariosController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _usuarioService.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
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
                Expires = DateTime.UtcNow.AddMinutes(5),
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
