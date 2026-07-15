using SGA.Application.Dtos.Notification;
using SGA.Application.Interfaces;
using SGA.Persistence.Interfaces.Notifications;
using SGA.Domain.Notifications;
using SGA.Domain.Enums;

namespace SGA.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificacionRepository _notificationRepository;

        public NotificationService(INotificacionRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<List<NotificationDto>> GetAllAsync()
        {
            var notifications = await _notificationRepository.GetAllAsync();

            return notifications.Select(n => new NotificationDto
            {
                Id = n.Id,
                Message = n.Descripcion
            }).ToList();
        }

        public async Task AddAsync(SaveNotificationDto notificationDto)
        {
            if (notificationDto.UserId <= 0)
                throw new Exception("El usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(notificationDto.Message))
                throw new Exception("El mensaje es obligatorio.");

            var notification = new Notificaciones
            {
                UsuarioId = notificationDto.UserId,
                Nombre = notificationDto.Message,
                Descripcion = notificationDto.Message,
                TipoNotificacion = TipoNotificacion.Informativa,
                FechaHora = DateTime.Now
            };

            await _notificationRepository.AddAsync(notification);
        }

        public async Task UpdateAsync(UpdateNotificationDto notificationDto)
        {
            if (notificationDto.Id <= 0)
                throw new Exception("El ID de la notificación no es válido.");

            var notification = await _notificationRepository.GetByIdAsync(notificationDto.Id);

            if (notification == null)
                throw new Exception("Notificación no encontrada.");

            if (notificationDto.UserId <= 0)
                throw new Exception("El usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(notificationDto.Message))
                throw new Exception("El mensaje es obligatorio.");

            notification.UsuarioId = notificationDto.UserId;
            notification.Nombre = notificationDto.Message;
            notification.Descripcion = notificationDto.Message;
            notification.TipoNotificacion = TipoNotificacion.Informativa;
            notification.FechaHora = DateTime.Now;

            await _notificationRepository.UpdateAsync(notification);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new Exception("El ID de la notificación no es válido.");

            var notification = await _notificationRepository.GetByIdAsync(id);

            if (notification == null)
                throw new Exception("Notificación no encontrada.");

            await _notificationRepository.DeleteAsync(notification);
        }
    }
}