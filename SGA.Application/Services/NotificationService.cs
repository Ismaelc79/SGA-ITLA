using SGA.Application.Dtos.Notification;
using SGA.Application.Interfaces;
using SGA.Persistence.Interfaces.Notifications;
using SGA.Domain.Notifications;

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
                Message = n.Message,
                IsRead = n.IsRead
            }).ToList();
        }

        public async Task AddAsync(SaveNotificationDto notificationDto)
        {
            var notification = new Notificacion
            {
                Message = notificationDto.Message,
                UserId = notificationDto.UserId,
                IsRead = false
            };

            await _notificationRepository.AddAsync(notification);
        }

        public async Task UpdateAsync(UpdateNotificationDto notificationDto)
        {
            var notification = new Notificacion
            {
                Id = notificationDto.Id,
                Message = notificationDto.Message,
                UserId = notificationDto.UserId,
                IsRead = false
            };

            await _notificationRepository.UpdateAsync(notification);
        }

        public async Task DeleteAsync(int id)
        {
            var notification = await _notificationRepository.GetByIdAsync(id);

            if (notification != null)
            {
                await _notificationRepository.DeleteAsync(notification);
            }
        }
    }
}