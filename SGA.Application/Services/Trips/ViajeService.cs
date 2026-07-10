using SGA.Application.DTOs.Viaje;
using SGA.Application.Exceptions;
using SGA.Application.Interfaces.Trips;
using SGA.Domain.Base;
using SGA.Domain.Enums;
using SGA.Persistence.Interfaces.Trips;

namespace SGA.Application.Services.Trips
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeRepository _viajeRepository;

        public ViajeService(IViajeRepository viajeRepository)
        {
            _viajeRepository = viajeRepository;
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
            var viaje = await _viajeRepository.GetByIdAsync(id);
            if (viaje == null)
            {
                return new OperationResult<ViajeDto>
                {
                    Success = false,
                    Message = $"No se encontró un viaje con ID '{id}'.",
                    Errors = new List<string> { "Viaje no encontrado" }
                };
            }
            
            ValidarCambioEstado(viaje.EstadoViaje, dto.EstadoViaje);
            viaje.EstadoViaje = dto.EstadoViaje;

            await _viajeRepository.UpdateAsync(viaje);

            return new OperationResult<ViajeDto>
            {
                Success = true,
                Message = "Estado del viaje actualizado exitosamente",
                Data = MapToDto(viaje)
            };

        }

        private void ValidarCambioEstado(EstadoViaje actual, EstadoViaje nuevo)
        {
            if (actual == nuevo)
            {
                throw new BusinessRuleException($"El viaje ya se encuentra en el estado '{actual}'.");
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
