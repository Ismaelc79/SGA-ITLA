using FluentValidation;
using SGA.Application.DTOs.TarjetaRecargable;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Base;
using SGA.Persistence.Interfaces.Autorizations;

namespace SGA.Application.Services.Configuration
{
    public class TarjetaRecargableService : ITarjetaRecargableService
    {
        private readonly ITarjetaRecargableRepository _tarjetaRecargableRepository;
        private readonly IValidator<CreateTarjetaRecargableDto> _createValidator;
        private readonly IValidator<UpdateTarjetaRecargableDto> _updateValidator;

        public  TarjetaRecargableService(
            ITarjetaRecargableRepository tarjetaRecargableRepository, 
            IValidator<CreateTarjetaRecargableDto> createValidator,
            IValidator<UpdateTarjetaRecargableDto> updateValidator)
        {
            _tarjetaRecargableRepository = tarjetaRecargableRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<OperationResult<IEnumerable<TarjetaRecargableDto>>> GetAllAsync()
        {
            var tarjetas = await _tarjetaRecargableRepository.GetAllAsync();
            return new OperationResult<IEnumerable<TarjetaRecargableDto>>
            {
                Success = true,
                Message = "Tarjetas obtenidas exitosamente",
                Data = tarjetas.Select(MapToDto)
            };
        }

        public async Task<OperationResult<TarjetaRecargableDto>> GetByIdAsync(int id)
        {
            var tarjeta = await _tarjetaRecargableRepository.GetByIdAsync(id);
            if (tarjeta == null) 
            {
                return new OperationResult<TarjetaRecargableDto>
                {
                    Success = false,
                    Message = $"No se encontró una tarjeta con el ID '{id}'.",
                    Errors = new List<string> { "Tarjeta no encontrada" }
                };
            }
            return new OperationResult<TarjetaRecargableDto>
            {
                Success = true,
                Message = "Tarjeta encontrada exitosamente",
                Data = MapToDto(tarjeta)
            };
        }

        public async Task<OperationResult<TarjetaRecargableDto>> CreateAsync(CreateTarjetaRecargableDto dto)
        {
            var validacion = _createValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<TarjetaRecargableDto>
                {
                    Success = false,
                    Message = "Los datos de la tarjeta no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            
            var tarjeta = new Domain.Entities.Authorization.TarjetaRecargable
            {
                EstudianteId = dto.EstudianteId,
                PagoId = dto.PagoId,
                MontoTarjeta = dto.MontoTarjeta,
                EstadoTarjeta = dto.EstadoTarjeta,
                FechaVigenteInicio = dto.FechaVigenteInicio,
                FechaVigenteFin = dto.FechaVigenteFin,
            };

            await _tarjetaRecargableRepository.AddAsync(tarjeta);

            return new OperationResult<TarjetaRecargableDto>
            {
                Success = true,
                Message = "Tarjeta creada exitosamente",
                Data = MapToDto(tarjeta)
            };
        }

        public async Task<OperationResult<TarjetaRecargableDto>> UpdateAsync(int id, UpdateTarjetaRecargableDto dto)
        {
            var validacion = _updateValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<TarjetaRecargableDto>
                {
                    Success = false,
                    Message = "Los datos de la tarjeta no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var tarjetaExistente = await _tarjetaRecargableRepository.GetByIdAsync(id);

            if(tarjetaExistente == null)
            {
                return new OperationResult<TarjetaRecargableDto>
                {
                    Success = false,
                    Message = $"No se encontró una tarjeta con ID '{id}'.",
                    Errors = new List<string> {"Tarjeta no encontrada"}
                };
            }

            tarjetaExistente.Id  = dto.Id;
            tarjetaExistente.EstudianteId = dto.EstudianteId;
            tarjetaExistente.PagoId = dto.PagoId;
            tarjetaExistente.MontoTarjeta = dto.MontoTarjeta;
            tarjetaExistente.EstadoTarjeta = dto.EstadoTarjeta;
            tarjetaExistente.FechaVigenteInicio = dto.FechaVigenteInicio;
            tarjetaExistente.FechaVigenteFin = dto.FechaVigenteFin;

            await _tarjetaRecargableRepository.UpdateAsync(tarjetaExistente);

            return new OperationResult<TarjetaRecargableDto> 
            { 
                Success = false, 
                Message = "Tarjeta actualizada exitosamente",
                Data = MapToDto(tarjetaExistente)
            
            };
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var tarjeta = await _tarjetaRecargableRepository.GetByIdAsync(id);

            if(tarjeta == null)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encontró una tarjeta con ID '{id}'.",
                    Errors = new List<string> { "Tarjeta no encontrada" }
                };
            }

            await _tarjetaRecargableRepository.DeleteAsync(tarjeta);

            return new OperationResult<bool>
            {
                Success = true,
                Message = "Tarjeta eliminada exitosamente",
                Data = true
            };
        }

        private TarjetaRecargableDto MapToDto (Domain.Entities.Authorization.TarjetaRecargable tarjetaRecargable)
        {
            return new TarjetaRecargableDto
            {
                Id = tarjetaRecargable.Id,
                EstudianteId = tarjetaRecargable.EstudianteId,
                PagoId = tarjetaRecargable.PagoId,
                MontoTarjeta = tarjetaRecargable.MontoTarjeta,
                EstadoTarjeta = tarjetaRecargable.EstadoTarjeta,
                FechaVigenteInicio = tarjetaRecargable.FechaVigenteInicio,
                FechaVigenteFin = tarjetaRecargable.FechaVigenteFin
            };
        }
    }
}
