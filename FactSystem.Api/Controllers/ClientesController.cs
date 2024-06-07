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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // POST api/<ClientesController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Cliente customer)
        {
            if (customer == null)
                return BadRequest();
            var response = await _clienteService.Create(customer);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente customer)
        {
            var customerExists = await _clienteService.GetById(id);
            if (customerExists.Data == null)
                return NotFound(customerExists);

            if (customer == null)
                return BadRequest();
            var response = await _clienteService.Update(customer);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
        
        // GET: api/<ClientesController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _clienteService.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // GET api/<ClientesController>/5
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _clienteService.GetById(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }


        // DELETE api/<ClientesController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _clienteService.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
