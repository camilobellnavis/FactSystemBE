using FactSystem.Application.Interfaces;
using FactSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FactSystem.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        // POST api/<ClientesController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Producto product)
        {
            if (product == null)
                return BadRequest();
            var response = await _productoService.Create(product);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Producto product)
        {
            var productExists = await _productoService.GetById(id);
            if (productExists.Data == null)
                return NotFound(productExists);

            if (product == null)
                return BadRequest();
            var response = await _productoService.Update(product);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // GET: api/<ClientesController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productoService.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // GET api/<ClientesController>/5
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _productoService.GetById(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }


        // DELETE api/<ClientesController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productoService.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
