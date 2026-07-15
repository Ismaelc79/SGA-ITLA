using Microsoft.AspNetCore.Mvc;
using SGA.Application.Dtos.Notification;
using SGA.Application.Interfaces;

namespace SGA.Api.Desktop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var notifications = await _notificationService.GetAllAsync();
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveNotificationDto notificationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _notificationService.AddAsync(notificationDto);

            return Ok("Notificación creada correctamente");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateNotificationDto notificationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _notificationService.UpdateAsync(notificationDto);

            return Ok("Notificación actualizada correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("El ID de la notificación no es válido.");

            await _notificationService.DeleteAsync(id);

            return Ok("Notificación eliminada correctamente");
        }
    }
}