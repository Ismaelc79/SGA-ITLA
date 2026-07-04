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
}