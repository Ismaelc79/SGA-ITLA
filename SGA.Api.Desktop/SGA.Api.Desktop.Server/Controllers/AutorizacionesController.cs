using Microsoft.AspNetCore.Mvc;
using SGA.Application.Dtos.Authorization;
using SGA.Application.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class AutorizacionesController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;

    public AutorizacionesController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var autorizaciones = await _authorizationService.GetAllAsync();
        return Ok(autorizaciones);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var autorizacion = await _authorizationService.GetByIdAsync(id);

        if (autorizacion == null)
            return NotFound();

        return Ok(autorizacion);
    }

    [HttpPost]
    public async Task<IActionResult> Add(SaveAutorizacionDto autorizacionDto)
    {
        await _authorizationService.AddAsync(autorizacionDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAutorizacionDto autorizacionDto)
    {
        await _authorizationService.UpdateAsync(autorizacionDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _authorizationService.DeleteAsync(id);
        return Ok();
    }
}