using Microsoft.AspNetCore.Mvc;
using SGA.Application.Interfaces;
using SGA.Application.Dtos.User;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUserService _userService;

    public UsuariosController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Add(SaveUserDto userDto)
    {
        await _userService.AddAsync(userDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserDto userDto)
    {
        await _userService.UpdateAsync(userDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok();
    }
}