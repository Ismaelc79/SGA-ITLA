using Microsoft.AspNetCore.Mvc;
using SGA.Application.Dtos.Notification;
using SGA.Application.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class NotificacionesController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificacionesController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var notifications = await _notificationService.GetAllAsync();
        return Ok(notifications);
    }

    [HttpPost]
    public async Task<IActionResult> Add(SaveNotificationDto notificationDto)
    {
        await _notificationService.AddAsync(notificationDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateNotificationDto notificationDto)
    {
        await _notificationService.UpdateAsync(notificationDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _notificationService.DeleteAsync(id);
        return Ok();
    }
}