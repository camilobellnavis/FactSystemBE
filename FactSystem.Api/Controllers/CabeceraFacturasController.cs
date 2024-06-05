using FactSystem.Application.Interfaces;
using FactSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FactSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabeceraFacturasController : ControllerBase
    {
        private readonly ICabFacturaService _cabFacturaService;

        public CabeceraFacturasController(ICabFacturaService cabFacturaService)
        {
            _cabFacturaService = cabFacturaService;
        }
        // POST api/<ClientesController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CabFactura invoice)
        {
            if (invoice == null)
                return BadRequest();
            var response = await _cabFacturaService.Create(invoice);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CabFactura invoice)
        {
            var invoiceExists = await _cabFacturaService.GetById(id);
            if (invoiceExists.Data == null)
                return NotFound(invoiceExists);

            if (invoice == null)
                return BadRequest();
            var response = await _cabFacturaService.Update(invoice);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // GET: api/<ClientesController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _cabFacturaService.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // GET api/<ClientesController>/5
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _cabFacturaService.GetById(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }


        // DELETE api/<ClientesController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _cabFacturaService.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        // GET: api/<ClientesController>
        [HttpGet("GetLastId")]
        public async Task<IActionResult> GetLastId()
        {
            var response = await _cabFacturaService.GetLastId();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("GetLastIdF")]
        public async Task<IActionResult> GetLastIdF()
        {
            var response = await _cabFacturaService.GetLastIdF();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
