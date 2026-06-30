using SGA.Application.Dtos.Notification;

namespace SGA.Application.Interfaces
{
    public interface INotificationService
    {
        Task<List<NotificationDto>> GetAllAsync();
        Task AddAsync(SaveNotificationDto notificationDto);
        Task UpdateAsync(UpdateNotificationDto notificationDto);
        Task DeleteAsync(int id);
    }
}