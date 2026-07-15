using FluentValidation;
using SGA.Application.DTOs.Viaje;
using SGA.Application.Exceptions;
using SGA.Application.Interfaces.Trips;
using SGA.Application.Validators.Trips;
using SGA.Domain.Base;
using SGA.Domain.Enums;
using SGA.Persistence.Interfaces.Trips;

namespace SGA.Application.Services.Trips
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeRepository _viajeRepository;
        private readonly IValidator<CreateViajeDto> _createValidator;
        private readonly IValidator<UpdateViajeDto> _updateValidator;
        private readonly IValidator<ViajeStatusChangeDto> _statusChangeValidator;

        public ViajeService(
            IViajeRepository viajeRepository, 
            IValidator<CreateViajeDto> createViaje,
            IValidator<UpdateViajeDto> updateViaje, 
            IValidator<ViajeStatusChangeDto> viajeStatusChange)
        {
            _viajeRepository = viajeRepository;
            _createValidator = createViaje;
            _updateValidator = updateViaje;
            _statusChangeValidator = viajeStatusChange;
        }

        public async Task<OperationResult<IEnumerable<ViajeDto>>> GetAllAsync()
        {
            var viajes = await _viajeRepository.GetAllAsync();

            return new OperationResult<IEnumerable<ViajeDto>>
            {
                Success = true,
                Message = "Viajes obtenidos exitosamente.",
                Data = viajes.Select(MapToDto)
            };
        }

        public async Task<OperationResult<ViajeDto>> GetByIdAsync(int id)
        {
            var viaje = await _viajeRepository.GetByIdAsync(id);

            if (viaje == null)
            {
                return new OperationResult<ViajeDto>
                {
                    Success = false,
                    Message = $"No se encontró un viaje con el ID ' {id}'.",
                    Errors = new List<string> {"Viaje no encontrado"}
                };
            }
            return new OperationResult<ViajeDto>
            {
                Success = true,
                Message = "Viaje encontrado exitosamente",
                Data = MapToDto(viaje)
            };

        }
        public async Task<OperationResult<IEnumerable<ViajeDto>>> GetByEstadoAsync(EstadoViaje estado)
        {
            var viajes = await _viajeRepository.GetByEstadoAsync(estado);

            if(viajes == null)
            {
                return new OperationResult<IEnumerable<ViajeDto>>
                {
                    Success = false,
                    Message = $"No se encontraron viajes con estado '{estado}'.",
                    Errors = new List<string> {"Viajes con encontrados"}
                };
            }
            return new OperationResult<IEnumerable<ViajeDto>>
            {
                Success = true,
                Message = "Viajes encontrados exitosamente",
                Data = viajes.Select(MapToDto)
            };
        }

        public async Task<OperationResult<ViajeDto>> CreateAsync(CreateViajeDto dto)
        {
            var validacion = _createValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<ViajeDto>
                {
                    Success = false,
                    Message = "Los datos del viaje no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            
            var viaje = new Domain.Entities.Trip.Viaje
            {
                RutaId = dto.RutaId,
                AutobusId = dto.AutobusId,
                ConductorId = dto.ConductorId,
                HorarioId = dto.HorarioId,
                EstadoViaje = dto.EstadoViaje,
                HoraSalidaEstimada = dto.HoraSalidaEstimada,
                HoraLlegadaEstimada = dto.HoraLlegadaEstimada

            };

            await _viajeRepository.AddAsync(viaje);

            return new OperationResult<ViajeDto>
            {
                Success = true,
                Message = $"Viaje creado exitosamente",
                Data = MapToDto(viaje)
            };

        }

        public async Task<OperationResult<ViajeDto>> UpdateAsync(int id, UpdateViajeDto dto)
        {
            var validacion = _updateValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<ViajeDto>
                {
                    Success = false,
                    Message = "Los datos del viaje no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            
            var viajeExistente = await _viajeRepository.GetByIdAsync(id);

            if (viajeExistente == null) 
            {
                return new OperationResult<ViajeDto>
                {
                    Success = false,
                    Message = $"No se encontró un viaje con ID '{id}'.",
                    Errors = new List<string> {"Viaje no encontrado"}
                };
            }

            ValidarCambioEstado(viajeExistente.EstadoViaje, dto.EstadoViaje);

            viajeExistente.IncidenciaId = dto.IncidenciaId;
            viajeExistente.EstadoViaje = dto.EstadoViaje;
            viajeExistente.HoraSalidaEstimada = dto.HoraSalidaEstimada;
            viajeExistente.HoraLlegadaEstimada = dto.HoraLlegadaEstimada;

            await _viajeRepository.UpdateAsync(viajeExistente);

            return new OperationResult<ViajeDto>
            {
                Success = true,
                Message = "Viaje actualizado exitosamente",
                Data = MapToDto(viajeExistente)
            };
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var viaje = await _viajeRepository.GetByIdAsync(id);

            if(viaje == null)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encontró un viaje con ID '{id}'.",
                    Errors = new List<string> {"Viaje no encontrado"}

                };
            }
            
            await _viajeRepository.DeleteAsync(viaje);

            return new OperationResult<bool>
            {
                Success = true,
                Message = "Viaje eliminado exitosamente",
                Data = true
            };
        }

        public async Task<OperationResult<ViajeDto>> ChangeStatusAsync(int id, ViajeStatusChangeDto dto)
        {
            var validacion = _statusChangeValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<ViajeDto>
                {
                    Success = false,
                    Message = "Los datos del cambio de estado no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            
            var viajeExistente = await _viajeRepository.GetByIdAsync(id);
            if (viajeExistente == null)
            {
                return new OperationResult<ViajeDto>
                {
                    Success = false,
                    Message = $"No se encontró un viaje con ID '{id}'.",
                    Errors = new List<string> { "Viaje no encontrado" }
                };
            }
            
            ValidarCambioEstado(viajeExistente.EstadoViaje, dto.EstadoViaje);
            viajeExistente.EstadoViaje = dto.EstadoViaje;

            await _viajeRepository.UpdateAsync(viajeExistente);

            return new OperationResult<ViajeDto>
            {
                Success = true,
                Message = "Estado del viaje actualizado exitosamente",
                Data = MapToDto(viajeExistente)
            };

        }

        private void ValidarCambioEstado(EstadoViaje actual, EstadoViaje nuevo)
        {
            switch (actual)
            {
                case EstadoViaje.Programado:

                    if (nuevo != EstadoViaje.EnCurso &&
                        nuevo != EstadoViaje.Cancelado &&
                        nuevo != EstadoViaje.Retrasado) 
                    {
                        throw new BusinessRuleException(
                            "Un viaje programado solo puede pasar a En Curso, Retrasado o Cancelado");
                    }
                    break;

                case EstadoViaje.EnCurso:
                    if(nuevo != EstadoViaje.Completado &&
                       nuevo != EstadoViaje.Retrasado) 
                    {
                        throw new BusinessRuleException(
                            "Un viaje en curso solo puede pasar a Completado o Retrasado");
                    }
                    break;

                case EstadoViaje.Retrasado:
                    if(nuevo != EstadoViaje.EnCurso &&
                       nuevo != EstadoViaje.Cancelado)
                    {
                        throw new BusinessRuleException(
                            "Un viaje retrasado solo puede pasar a En curso o Cancelado");
                    }
                    break;

                case EstadoViaje.Completado:

                    throw new BusinessRuleException(
                        "Un viaje completado no puede cambiar de estado");

                case EstadoViaje.Cancelado:
                    throw new BusinessRuleException(
                        "Un viaje cancelado no puede cambiar de estado");
                   
            }
        }


        private ViajeDto MapToDto(Domain.Entities.Trip.Viaje viaje)
        {
            return new ViajeDto
            {
                Id = viaje.Id,
                RutaId = viaje.RutaId,
                AutobusId = viaje.AutobusId,
                ConductorId = viaje.ConductorId,
                HorarioId = viaje.HorarioId,
                IncidenciaId = viaje.IncidenciaId,
                EstadoViaje = viaje.EstadoViaje,
                HoraSalidaEstimada = viaje.HoraSalidaEstimada,
                HoraLlegadaEstimada = viaje.HoraLlegadaEstimada
            };
        }       
    }
}
