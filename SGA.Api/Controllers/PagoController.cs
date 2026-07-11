using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGA.Application.DTOs.Pago;
using SGA.Application.Interfaces.Configuration;
using SGA.Persistence.Interfaces.Autorizations;

namespace SGA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        { 
            var result = await _pagoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) 
        { 
            var result = await _pagoService.GetByIdAsync(id);

            if(!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost] 
        public async Task<IActionResult> Post([FromBody] CreatePagoDto dto)
        {
            var result = await _pagoService.CreateAsync(dto);
            if (!result.Success) 
            { 
                return BadRequest(result);
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePagoDto dto)
        {   
            var result = await _pagoService.UpdateAsync(id,dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        { 
            var result = await _pagoService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
