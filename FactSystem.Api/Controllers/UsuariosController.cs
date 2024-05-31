using FactSystem.Application.Interfaces;
using FactSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FactSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            var usuarios = _service.GetAll();

            return Ok(usuarios);
        }

       
    }
}
