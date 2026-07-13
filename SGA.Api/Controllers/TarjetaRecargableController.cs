using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGA.Application.DTOs.TarjetaRecargable;
using SGA.Application.Interfaces.Configuration;

namespace SGA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaRecargableController : ControllerBase
    {
        private readonly ITarjetaRecargableService _tarjetaRecargableService;

        public TarjetaRecargableController(ITarjetaRecargableService tarjetaRecargableService)
        {
            _tarjetaRecargableService = tarjetaRecargableService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        { 
            var result = await _tarjetaRecargableService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _tarjetaRecargableService.GetByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTarjetaRecargableDto dto)
        {
            var result = await _tarjetaRecargableService.CreateAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetById), new {id = result.Data.Id},result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] UpdateTarjetaRecargableDto dto)
        {
            var result = await _tarjetaRecargableService.UpdateAsync(id, dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            var result = await _tarjetaRecargableService.DeleteAsync(id);
            if (result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
