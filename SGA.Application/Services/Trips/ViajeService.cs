using FluentValidation;
using SGA.Application.DTOs.Viaje;
using SGA.Application.Exceptions;
using SGA.Application.Interfaces.Trips;
using SGA.Application.Validators.Trips;
using SGA.Domain.Base;
using SGA.Domain.Enums;
using SGA.Persistence.Interfaces;
using SGA.Persistence.Interfaces.Trips;
using SGA.Persistence.Interfaces.Users;

namespace SGA.Application.Services.Trips
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeRepository _viajeRepository;
        private readonly IRutaRepository _rutaRepository;
        private readonly IBusRepository _busRepository;
        private readonly IConductorRepository _conductorRepository;
        private readonly IHorarioRepository _horarioRepository;
        private readonly IIncidenciaRepository _incidenciaRepository;
        private readonly IValidator<CreateViajeDto> _createValidator;
        private readonly IValidator<UpdateViajeDto> _updateValidator;
        private readonly IValidator<ViajeStatusChangeDto> _statusChangeValidator;

        public ViajeService(
            IViajeRepository viajeRepository,
            IRutaRepository rutaRepository,
            IBusRepository busRepository,
            IConductorRepository conductorRepository,
            IHorarioRepository horarioRepository,
            IIncidenciaRepository incidenciaRepository,
            IValidator<CreateViajeDto> createViaje,
            IValidator<UpdateViajeDto> updateViaje,
            IValidator<ViajeStatusChangeDto> viajeStatusChange)
        {
            _viajeRepository = viajeRepository;
            _rutaRepository = rutaRepository;
            _busRepository = busRepository;
            _conductorRepository = conductorRepository;
            _horarioRepository = horarioRepository;
            _incidenciaRepository = incidenciaRepository;
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
            
            await ValidarRutaExistente(dto.RutaId);
            await ValidarAutobusExistente(dto.AutobusId);
            await ValidarConductorExistente(dto.ConductorId);
            await ValidarHorarioExistente(dto.HorarioId);

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
            await ValidarIncidenciaExistente(dto.IncidenciaId);

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

        private async Task ValidarRutaExistente(int rutaId)
        {
            var ruta = await _rutaRepository.GetByIdAsync(rutaId);

            if (ruta == null)
            {
                throw new BusinessRuleException($"No existe una ruta con el ID {rutaId}");
            }
        }

        private async Task ValidarAutobusExistente(int autobusId)
        {
            var autobus = await _busRepository.GetByIdAsync(autobusId);

            if (autobus == null)
            {
                throw new BusinessRuleException($"No existe un autobús con el ID {autobusId}");
            }
        }

        private async Task ValidarConductorExistente(int conductorId)
        {
            var conductor = await _conductorRepository.GetByIdAsync(conductorId);

            if (conductor == null)
            {
                throw new BusinessRuleException($"No existe un conductor con el ID {conductorId}");
            }
        }

        private async Task ValidarHorarioExistente(int horarioId)
        {
            var horario = await _horarioRepository.GetByIdAsync(horarioId);

            if (horario == null)
            {
                throw new BusinessRuleException($"No existe un horario con el ID {horarioId}");
            }
        }

        private async Task ValidarIncidenciaExistente(int incidenciaId)
        {
            var incidencia = await _incidenciaRepository.GetByIdAsync(incidenciaId);

            if (incidencia == null)
            {
                throw new BusinessRuleException($"No existe una incidencia con el ID {incidenciaId}");
            }
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
