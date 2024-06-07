using FactSystem.Application.Interfaces;
using FactSystem.Application.UsesCases;
using FactSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FactSystem.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturasController : ControllerBase
    {
        private readonly IDetFacturaService _detFacturaService;

        public DetalleFacturasController(IDetFacturaService detFacturaService)
        {
            _detFacturaService = detFacturaService;
        }
        // POST api/<ClientesController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] DetFactura detail)
        {
            if (detail == null)
                return BadRequest();
            var response = await _detFacturaService.Create(detail);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DetFactura detail)
        {
            var detailExists = await _detFacturaService.GetById(id);
            if (detailExists.Data == null)
                return NotFound(detailExists);

            if (detail == null)
                return BadRequest();
            var response = await _detFacturaService.Update(detail);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // GET: api/<ClientesController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _detFacturaService.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // GET api/<ClientesController>/5
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _detFacturaService.GetById(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }


        // DELETE api/<ClientesController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _detFacturaService.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // GET: api/<ClientesController>
        [HttpGet("GetLastId")]
        public async Task<IActionResult> GetLastId()
        {
            var response = await _detFacturaService.GetLastId();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
