using FluentValidation;
using SGA.Application.DTOs.Notification;
using SGA.Application.Interfaces.Notification;
using SGA.Domain.Base;
using SGA.Domain.Enums;
using SGA.Domain.Notifications;
using SGA.Persistence.Interfaces.Trips;

namespace SGA.Application.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly INotificacionRepository _notificationRepository;
        private readonly IValidator<CreateNotificationDto> _createValidator;
        private readonly IValidator<UpdateNotificationDto> _updateValidator;

        public NotificationService(
            INotificacionRepository notificationRepository,
            IValidator<CreateNotificationDto> createValidator,
            IValidator<UpdateNotificationDto> updateValidator)
        {
            _notificationRepository = notificationRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<OperationResult<IEnumerable<NotificationDto>>> GetAllAsync()
        {
            var notifications = await _notificationRepository.GetAllAsync();

            return new OperationResult<IEnumerable<NotificationDto>>
            {
                Success = true,
                Message = "Notificaciones obtenidas exitosamente.",
                Data = notifications.Select(MapToDto)
            };
        }

        public async Task<OperationResult<NotificationDto>> GetByIdAsync(int id)
        {
            var notification = await _notificationRepository.GetByIdAsync(id);

            if (notification == null)
            {
                return new OperationResult<NotificationDto>
                {
                    Success = false,
                    Message = $"No se encontró una notificación con el ID {id}.",
                    Errors = new List<string> { "Notificación no encontrada." }
                };
            }

            return new OperationResult<NotificationDto>
            {
                Success = true,
                Message = "Notificación encontrada exitosamente.",
                Data = MapToDto(notification)
            };
        }

        public async Task<OperationResult<NotificationDto>> CreateAsync(CreateNotificationDto dto)
        {
            var validacion = _createValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<NotificationDto>
                {
                    Success = false,
                    Message = "Los datos de la notificación no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var notification = new Notificaciones
            {
                UsuarioId = dto.UserId,
                Nombre = dto.Message,
                Descripcion = dto.Message,
                TipoNotificacion = TipoNotificacion.Informativa,
                FechaHora = DateTime.Now
            };

            await _notificationRepository.AddAsync(notification);

            return new OperationResult<NotificationDto>
            {
                Success = true,
                Message = "Notificación creada exitosamente.",
                Data = MapToDto(notification)
            };
        }

        public async Task<OperationResult<NotificationDto>> UpdateAsync(int id, UpdateNotificationDto dto)
        {
            var validacion = _updateValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<NotificationDto>
                {
                    Success = false,
                    Message = "Los datos de la notificación no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var notificationExistente = await _notificationRepository.GetByIdAsync(id);

            if (notificationExistente == null)
            {
                return new OperationResult<NotificationDto>
                {
                    Success = false,
                    Message = $"No se encontró una notificación con el ID {id}.",
                    Errors = new List<string> { "Notificación no encontrada." }
                };
            }

            notificationExistente.UsuarioId = dto.UserId;
            notificationExistente.Nombre = dto.Message;
            notificationExistente.Descripcion = dto.Message;
            notificationExistente.FechaHora = DateTime.Now;

            await _notificationRepository.UpdateAsync(notificationExistente);

            return new OperationResult<NotificationDto>
            {
                Success = true,
                Message = "Notificación actualizada exitosamente.",
                Data = MapToDto(notificationExistente)
            };
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var notification = await _notificationRepository.GetByIdAsync(id);

            if (notification == null)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encontró una notificación con el ID {id}.",
                    Errors = new List<string> { "Notificación no encontrada." }
                };
            }

            await _notificationRepository.DeleteAsync(notification);

            return new OperationResult<bool>
            {
                Success = true,
                Message = "Notificación eliminada exitosamente.",
                Data = true
            };
        }

        private static NotificationDto MapToDto(Notificaciones notification)
        {
            return new NotificationDto
            {
                Id = notification.Id,
                Message = notification.Descripcion,
                UserId = notification.UsuarioId,
                TipoNotificacion = notification.TipoNotificacion,
                FechaHora = notification.FechaHora
            };
        }
    }
}