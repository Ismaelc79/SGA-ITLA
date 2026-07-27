using SGA.Application.DTOs.Notification;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Notification
{
    public interface INotificationService
    {
        Task<OperationResult<IEnumerable<NotificationDto>>> GetAllAsync();
        Task<OperationResult<NotificationDto>> GetByIdAsync(int id);
        Task<OperationResult<NotificationDto>> CreateAsync(CreateNotificationDto dto);
        Task<OperationResult<NotificationDto>> UpdateAsync(int id, UpdateNotificationDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);
    }
}
