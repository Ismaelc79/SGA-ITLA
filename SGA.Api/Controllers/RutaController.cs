using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGA.Application.DTOs.Ruta;
using SGA.Application.Interfaces.Trips;
using SGA.Persistence.Interfaces.Trips;

namespace SGA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        private readonly IRutaService _rutaService;

        public RutaController(IRutaService rutaService)
        {
            _rutaService = rutaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _rutaService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _rutaService.GetByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("estado/{estado}")]
        public async Task<IActionResult> GetByDisponible()
        {
            var result = await _rutaService.GetByDisponibleAsync();
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRutaDto dto)
        {
            var result = await _rutaService.CreateAsync(dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return CreatedAtAction(nameof(GetById), new {id = result.Data.Id}, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRutaDto dto)
        {
            var result = await _rutaService.UpdateAsync(id, dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _rutaService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
