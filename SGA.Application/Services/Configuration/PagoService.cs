
using FluentValidation;
using SGA.Application.DTOs.Pago;
using SGA.Application.Exceptions;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Base;
using SGA.Domain.Enums;
using SGA.Persistence.Interfaces.Autorizations;

namespace SGA.Application.Services.Configuration
{
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IValidator<CreatePagoDto> _createValidator;
        private readonly IValidator<UpdatePagoDto> _updateValidator;
        private readonly IValidator<PagoStatusChangeDto> _pagoStatusChangeValidator;

        public PagoService(
            IPagoRepository pagoRepository, 
            IValidator<CreatePagoDto> createValidator,
            IValidator<UpdatePagoDto> updateValidator, 
            IValidator<PagoStatusChangeDto> pagoStatusChangeValidator)
        {
            _pagoRepository = pagoRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _pagoStatusChangeValidator = pagoStatusChangeValidator;
        }

        public async Task<OperationResult<IEnumerable<PagoDto>>> GetAllAsync()
        {
            var pagos = await _pagoRepository.GetAllAsync();

            return new OperationResult<IEnumerable<PagoDto>>
            {
                Success = true,
                Message = "Pagos obtenidos exitosamente",
                Data = pagos.Select(MapToDto)
            };
        }

        public async Task<OperationResult<PagoDto>> GetByIdAsync(int id)
        {
            var pago = await _pagoRepository.GetByIdAsync(id);
            if (pago == null) 
            {
                return new OperationResult<PagoDto>
                {
                    Success = false,
                    Message = $"No se econtró un pago con ID '{id}.'",
                    Errors = new List<string> {"Pago no encontrado"}

                };
            }

            return new OperationResult<PagoDto>
            {
                Success = true,
                Message = "Pago encontrado exitosamente",
                Data = MapToDto(pago)
            };

        }

        public async Task<OperationResult<PagoDto>> CreateAsync(CreatePagoDto dto)
        {
            var validacion = _createValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<PagoDto>
                {
                    Success = false,
                    Message = "Los datos del pago no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var pago = new Domain.Entities.Authorization.Pago
            {
                EstudianteId = dto.EstudianteId,
                MontoPago = dto.MontoPago,
                MetodoPago = dto.MetodoPago,
                EstadoPago = dto.EstadoPago,
                FechaHora = dto.FechaHora,
            };

            await _pagoRepository.AddAsync(pago);

            return new OperationResult<PagoDto>
            {
                Success = true,
                Message = "Pago creado exitosamente",
                Data = MapToDto(pago)
            };
        }

        public async Task<OperationResult<PagoDto>> UpdateAsync(int id, UpdatePagoDto dto)
        {
           var validacion = _updateValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<PagoDto>
                {
                    Success = false,
                    Message = "Los datos del pago no son válidos",
                    Errors = validacion.Errors.Select(e =>e.ErrorMessage).ToList()

                };
            }

            var pagoExistente = await _pagoRepository.GetByIdAsync(id);

            if (pagoExistente == null) 
            {
                return new OperationResult<PagoDto>
                {
                    Success = false,
                    Message = $"No se encontró un pago con ID '{id}'.",
                    Errors = new List<string> {"Pago no encontrado"}

                };
            }

            ValidarCambioEstado(pagoExistente.EstadoPago, dto.EstadoPago);

            pagoExistente.Id = dto.Id;
            pagoExistente.EstudianteId = dto.EstudianteId;
            pagoExistente.MontoPago = dto.MontoPago;
            pagoExistente.MetodoPago = dto.MetodoPago;
            pagoExistente.EstadoPago = dto.EstadoPago;
            pagoExistente.FechaHora = dto.FechaHora;

            await _pagoRepository.UpdateAsync(pagoExistente);

            return new OperationResult<PagoDto>
            {
                Success= true,
                Message = "Pago creado exitosamente",
                Data = MapToDto(pagoExistente)
            };
        }

        public async Task<OperationResult<PagoDto>> ChangeStatusAsync(int id, PagoStatusChangeDto dto)
        {
            var validacion = _pagoStatusChangeValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<PagoDto>
                {
                    Success = false,
                    Message = "Los datos del estado del pago no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()

                };
            }

            var pagoExistente = await _pagoRepository.GetByIdAsync(id);

            if (pagoExistente == null)
            {
                return new OperationResult<PagoDto>
                {
                    Success = false,
                    Message = $"No se encontró un pago con ID '{id}'.",
                    Errors = new List<string> {"Pago no encontrado"}
                };
            }

            ValidarCambioEstado(pagoExistente.EstadoPago, dto.EstadoPago);
            pagoExistente.EstadoPago = dto.EstadoPago;

            return new OperationResult<PagoDto>

            {
                Success = true,
                Message = "Estado del pago actualizado exitosamente",
                Data = MapToDto(pagoExistente)
            };
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var pagoExistente = await _pagoRepository.GetByIdAsync(id);

            if (pagoExistente == null) 
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encontró un pago con ID '{id}'.",
                    Errors = new List<string> {"Pago no encontrado"}
                };
            }

            await _pagoRepository.DeleteAsync(pagoExistente);

            return new OperationResult<bool> 
            { 
                Success = true,
                Message = "Pago eliminado exitosamente",
                Data = true
            };

        }

        private void ValidarCambioEstado(EstadoPago actual, EstadoPago nuevo)
        {
            switch (actual)
            {
                case EstadoPago.Pendiente:
                    if(nuevo != EstadoPago.Procesando)
                       
                    {
                        throw new BusinessRuleException(
                            "Un pago pendiente solamente puede pasar a Procesando");
                    }
                 break;

                case EstadoPago.Procesando:
                    if (nuevo != EstadoPago.Completado &&
                        nuevo != EstadoPago.Rechazado &&
                        nuevo != EstadoPago.Cancelado)
                    {
                        throw new BusinessRuleException(
                            "Un pago en proceso solamente puede pasar a Completado, Rechazado o Cancelado");
                    }
                    break;
                
                case EstadoPago.Completado:
                    throw new BusinessRuleException(
                        "Un pago completado no puede cambiar de estado");

                case EstadoPago.Rechazado:
                    throw new BusinessRuleException(
                        "Un pago rechazado no puede cambiar de estado");

                case EstadoPago.Cancelado:
                    throw new BusinessRuleException(
                        "Un pago cancelado no puede cambiar de estado");
            }
        }

        private PagoDto MapToDto(Domain.Entities.Authorization.Pago pago)
        {
            return new PagoDto
            {
                Id = pago.Id,
                EstudianteId = pago.EstudianteId,
                MontoPago = pago.MontoPago,
                MetodoPago = pago.MetodoPago,
                EstadoPago = pago.EstadoPago,
                FechaHora = pago.FechaHora,

            };
        }

       
    }
}
