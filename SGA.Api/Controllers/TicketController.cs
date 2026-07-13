using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGA.Application.DTOs.Ticket;
using SGA.Application.Interfaces.Configuration;

namespace SGA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _ticketService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ticketService.GetByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTicketDto dto)
        {
            var result = await _ticketService.CreateAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
             return CreatedAtAction(nameof(GetById), new {id = result.Data.Id}, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTicketDto dto)
        {
            var result = await _ticketService.UpdateAsync(id, dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ticketService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
