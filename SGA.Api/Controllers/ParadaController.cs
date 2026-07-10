using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGA.Application.DTOs.Parada;
using SGA.Application.Interfaces.Trips;
using SGA.Persistence.Interfaces.Trips;

namespace SGA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadaController : ControllerBase
    {
        private readonly IParadaService _paradaService;

        public ParadaController(IParadaService paradaService)
        {
            _paradaService = paradaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _paradaService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _paradaService.GetByIdAsync(id);

            if (!result.Success) 
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateParadaDto dto)
        {
            var result = await _paradaService.CreateAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateParadaDto dto)
        {
            var result = await _paradaService.UpdateAsync(id,dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) { 
            
            var result = await _paradaService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
