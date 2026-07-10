using Microsoft.AspNetCore.Mvc;
using SGA.Application.Dtos.Role;
using SGA.Application.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _roleService.GetAllAsync();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var role = await _roleService.GetByIdAsync(id);

        if (role == null)
            return NotFound();

        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Add(SaveRoleDto roleDto)
    {
        await _roleService.AddAsync(roleDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateRoleDto roleDto)
    {
        await _roleService.UpdateAsync(roleDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _roleService.DeleteAsync(id);
        return Ok();
    }
}