using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGA.Application.DTOs.Viaje;
using SGA.Application.Interfaces.Trips;
using SGA.Domain.Enums;

namespace SGA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly IViajeService _viajeService;

        public ViajeController(IViajeService viajeService)
        {
            _viajeService = viajeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _viajeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _viajeService.GetByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("string/{estado}")]
        public async Task<IActionResult> Get(EstadoViaje estado)
        {
            var result = await _viajeService.GetByEstadoAsync(estado);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateViajeDto dto)
        {
            var result = await _viajeService.CreateAsync(dto);
            if (!result.Success) 
            { 
                return BadRequest(result);
            }
            return CreatedAtAction(nameof(GetById), new {id = result.Data.Id}, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateViajeDto dto)
        {
            var result = await _viajeService.UpdateAsync(id, dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        { 
            var result = await _viajeService.DeleteAsync(id);
            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
