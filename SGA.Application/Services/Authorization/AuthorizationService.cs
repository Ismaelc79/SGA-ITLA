using FluentValidation;
using SGA.Application.DTOs.Authorization;
using SGA.Application.Interfaces.Authorization;
using SGA.Domain.Base;
using SGA.Domain.Enums;
using SGA.Persistence.Interfaces.Autorizations;

namespace SGA.Application.Services.Authorization
{
    public class AuthorizationService : IAuthorizationsService
    {
        private readonly IAutorizacionRepository _autorizacionRepository;
        private readonly IValidator<CreateAutorizacionDto> _createValidator;
        private readonly IValidator<UpdateAutorizacionDto> _updateValidator;
        private readonly IValidator<AutorizacionStatusChangeDto> _statusChangeValidator;

        public AuthorizationService(
            IAutorizacionRepository autorizacionRepository,
            IValidator<CreateAutorizacionDto> createValidator,
            IValidator<UpdateAutorizacionDto> updateValidator,
            IValidator<AutorizacionStatusChangeDto> statusChangeValidator)
        {
            _autorizacionRepository = autorizacionRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _statusChangeValidator = statusChangeValidator;
        }

        public async Task<OperationResult<IEnumerable<AutorizacionDto>>> GetAllAsync()
        {
            var autorizaciones = await _autorizacionRepository.GetAllAsync();

            return new OperationResult<IEnumerable<AutorizacionDto>>
            {
                Success = true,
                Message = "Autorizaciones obtenidas exitosamente.",
                Data = autorizaciones.Select(MapToDto)
            };
        }

        public async Task<OperationResult<AutorizacionDto>> GetByIdAsync(int id)
        {
            var autorizacion = await _autorizacionRepository.GetByIdAsync(id);

            if (autorizacion == null)
            {
                return new OperationResult<AutorizacionDto>
                {
                    Success = false,
                    Message = $"No se encontró una autorización con el ID {id}.",
                    Errors = new List<string> { "Autorización no encontrada." }
                };
            }

            return new OperationResult<AutorizacionDto>
            {
                Success = true,
                Message = "Autorización encontrada exitosamente.",
                Data = MapToDto(autorizacion)
            };
        }

        public async Task<OperationResult<AutorizacionDto>> CreateAsync(CreateAutorizacionDto dto)
        {
            var validacion = _createValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<AutorizacionDto>
                {
                    Success = false,
                    Message = "Los datos de la autorización no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var autorizacion = new Domain.Entities.Authorization.Autorizacion
            {
                UsuarioId = dto.UsuarioId,
                Tipo = dto.Tipo,
                FechaInicio = dto.FechaInicio,
                FechaCierre = dto.FechaCierre,
                EstadoAutorizacion = EstadoAutorizacion.Pendiente
            };

            await _autorizacionRepository.AddAsync(autorizacion);

            return new OperationResult<AutorizacionDto>
            {
                Success = true,
                Message = "Autorización creada exitosamente.",
                Data = MapToDto(autorizacion)
            };
        }

        public async Task<OperationResult<AutorizacionDto>> UpdateAsync(int id, UpdateAutorizacionDto dto)
        {
            var validacion = _updateValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<AutorizacionDto>
                {
                    Success = false,
                    Message = "Los datos de la autorización no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var autorizacionExistente = await _autorizacionRepository.GetByIdAsync(id);

            if (autorizacionExistente == null)
            {
                return new OperationResult<AutorizacionDto>
                {
                    Success = false,
                    Message = $"No se encontró una autorización con el ID {id}.",
                    Errors = new List<string> { "Autorización no encontrada." }
                };
            }

            autorizacionExistente.UsuarioId = dto.UsuarioId;
            autorizacionExistente.Tipo = dto.Tipo;
            autorizacionExistente.FechaInicio = dto.FechaInicio;
            autorizacionExistente.FechaCierre = dto.FechaCierre;

            await _autorizacionRepository.UpdateAsync(autorizacionExistente);

            return new OperationResult<AutorizacionDto>
            {
                Success = true,
                Message = "Autorización actualizada exitosamente.",
                Data = MapToDto(autorizacionExistente)
            };
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var autorizacion = await _autorizacionRepository.GetByIdAsync(id);

            if (autorizacion == null)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encontró una autorización con el ID {id}.",
                    Errors = new List<string> { "Autorización no encontrada." }
                };
            }

            await _autorizacionRepository.DeleteAsync(autorizacion);

            return new OperationResult<bool>
            {
                Success = true,
                Message = "Autorización eliminada exitosamente.",
                Data = true
            };
        }

        public async Task<OperationResult<AutorizacionDto>> ChangeStatusAsync(int id, AutorizacionStatusChangeDto dto)
        {
            var validacion = _statusChangeValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<AutorizacionDto>
                {
                    Success = false,
                    Message = "Los datos del cambio de estado no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var autorizacion = await _autorizacionRepository.GetByIdAsync(id);

            if (autorizacion == null)
            {
                return new OperationResult<AutorizacionDto>
                {
                    Success = false,
                    Message = $"No se encontró una autorización con el ID {id}.",
                    Errors = new List<string> { "Autorización no encontrada." }
                };
            }

            if (autorizacion.EstadoAutorizacion == dto.Estado)
            {
                return new OperationResult<AutorizacionDto>
                {
                    Success = false,
                    Message = $"La autorización ya se encuentra en el estado '{autorizacion.EstadoAutorizacion}'.",
                    Errors = new List<string> { "El estado indicado es igual al estado actual." }
                };
            }

            autorizacion.EstadoAutorizacion = dto.Estado;

            await _autorizacionRepository.UpdateAsync(autorizacion);

            return new OperationResult<AutorizacionDto>
            {
                Success = true,
                Message = "Estado de la autorización actualizado exitosamente.",
                Data = MapToDto(autorizacion)
            };
        }

        private static AutorizacionDto MapToDto(Domain.Entities.Authorization.Autorizacion autorizacion)
        {
            return new AutorizacionDto
            {
                Id = autorizacion.Id,
                UsuarioId = autorizacion.UsuarioId,
                Tipo = autorizacion.Tipo,
                EstadoAutorizacion = autorizacion.EstadoAutorizacion,
                FechaInicio = autorizacion.FechaInicio,
                FechaCierre = autorizacion.FechaCierre
            };
        }
    }
}