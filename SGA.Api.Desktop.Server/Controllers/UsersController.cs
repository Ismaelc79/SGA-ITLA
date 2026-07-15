using Microsoft.AspNetCore.Mvc;
using SGA.Application.Dtos.User;
using SGA.Application.Interfaces;

namespace SGA.Api.Desktop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.AddAsync(dto);

            return Ok("Usuario creado correctamente.");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.UpdateAsync(dto);

            return Ok("Usuario actualizado correctamente.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);

            return Ok("Usuario eliminado correctamente.");
        }
    }
}