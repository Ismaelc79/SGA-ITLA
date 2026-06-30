using SGA.Application.Dtos.Notification;
using SGA.Application.Interfaces;

namespace SGA.Application.Services
{
    public class NotificationService : INotificationService
    {
        public async Task<List<NotificationDto>> GetAllAsync() { return new List<NotificationDto>(); }
        public async Task AddAsync(SaveNotificationDto notificationDto) { }
        public async Task UpdateAsync(UpdateNotificationDto notificationDto) { }
        public async Task DeleteAsync(int id) { }
    }
}