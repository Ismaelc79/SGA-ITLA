using SGA.Application.DTOs.Bus;
using SGA.Application.Exceptions;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Base;
using SGA.Domain.Entities.Trip;
using SGA.Domain.Enums;
using SGA.Persistence.Interfaces.Trips;

namespace SGA.Application.Services.Configuration
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task<OperationResult<IEnumerable<BusDto>>> GetAllAsync()
        {
            var buses = await _busRepository.GetAllAsync();

            return new OperationResult<IEnumerable<BusDto>>
            {
                Success = true,
                Message = "Buses obtenidos exitosamente.",
                Data = buses.Select(MapToDto)
            };
        }

        public async Task<OperationResult<BusDto>> GetByIdAsync(int id)
        {
            var bus = await _busRepository.GetByIdAsync(id);
            
            if(bus == null)
            {
                return new OperationResult<BusDto>
                {
                    Success = false,
                    Message = $"No se encontró un bus con el ID {id}.",
                    Errors = new List<string> { "Bus no encontrado." }
                };

            }

            return new OperationResult<BusDto>
            {
                Success = true,
                Message = "Bus encontrado exitosamente.",
                Data = MapToDto(bus)
            };
        }

        public async Task<OperationResult<BusDto>> CreateAsync(CreateBusDto dto)
        {
            await ValidarPlacaUnicaAsync(dto.Placa);

            if (dto.Capacidad <= 0)
            {
                return new OperationResult<BusDto>
                {
                    Success = false,
                    Message = "La capacidad del bus debe ser mayor a cero.",
                    Errors = new List<string> { "Capacidad inválida." }
                };
            }

            var bus = new Domain.Entities.Trip.Bus
            {
                ConductorId = dto.ConductorId,
                Placa = dto.Placa,
                Capacidad = dto.Capacidad,
                EstadoBus = EstadoBus.Disponible //Todo bus comienza con estado disponible
            };

            await _busRepository.AddAsync(bus);

            return new OperationResult<BusDto>
            {
                Success = true,
                Message = "Bus creado exitosamente.",
                Data = MapToDto(bus)

            };
        }

        public async Task<OperationResult<BusDto>> UpdateAsync(int id, UpdateBusDto dto)
        {
            var busExistente = await _busRepository.GetByIdAsync(id);

            if (busExistente == null){ 

                return new OperationResult<BusDto>
                {
                    Success = false,
                    Message = $"No se encontró un bus con el ID {id}.",
                    Errors = new List<string> { "Bus no encontrado." }
                };
            }

            await ValidarPlacaUnicaAsync(dto.Placa,id);

            busExistente.Placa = dto.Placa;
            busExistente.Capacidad = dto.Capacidad;
            busExistente.ConductorId = dto.ConductorId;

            await _busRepository.UpdateAsync(busExistente);
            return new OperationResult<BusDto>
            {
                Success = true,
                Message = "Bus actualizado exitosamente.",
                Data = MapToDto(busExistente)

            };

        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var bus = await _busRepository.GetByIdAsync(id);

            if (bus == null) { 

                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encontró un bus con el ID {id}.",
                    Errors = new List<string> { "Bus no encontrado." }
                };
            }

            await _busRepository.DeleteAsync(bus);

            return new OperationResult<bool>
            {
                Success = true,
                Message = "Bus eliminado exitosamente.",
                Data = true
            };
        }

        public async Task<OperationResult<IEnumerable<BusDto>>> GetActiveAsync()
        {
            var buses = await _busRepository.GetByActivosAsync();
            return new OperationResult<IEnumerable<BusDto>>
            {
                Success = true,
                Message = "Buses activos obtenidos exitosamente.",
                Data = buses.Select(MapToDto)
            };
        }

        public async Task<OperationResult<BusDto>> ChangeStatusAsync(int id, BusStatusChangeDto dto)
        {
            var bus = await _busRepository.GetByIdAsync(id);

            if (bus == null)
            {
                return
                    new OperationResult<BusDto>
                    {
                        Success = false,
                        Message = $"No se encontró un bus con el ID {id}.",
                        Errors = new List<string> { "Bus no encontrado." }
                    };
            }

            ValidarCambioEstado(bus.EstadoBus, dto.EstadoBus);
            bus.EstadoBus = dto.EstadoBus;

            await _busRepository.UpdateAsync(bus);

            return new OperationResult<BusDto>
            {
                Success = true,
                Message = "Estado del bus actualizado exitosamente.",
                Data = MapToDto(bus)

            };
        }

        private async Task ValidarPlacaUnicaAsync(string placa, int? idExcluir = null)
        {
            var busExistente = await _busRepository.GetByPlacaAsync(placa.Trim());

            if (busExistente != null && busExistente.Id != idExcluir)
            {
                throw new BusinessRuleException($"Ya existe un bus con la placa '{placa}'.");
            }
        }

        private void ValidarCambioEstado(EstadoBus actual, EstadoBus nuevo)
        {
            if(actual == nuevo)
            {
                throw new BusinessRuleException($"El bus ya se encuentra en el estado '{actual}'.");    
            }
        }

        private BusDto MapToDto(Domain.Entities.Trip.Bus bus)
        {
            return new BusDto
            {
                Id = bus.Id.ToString(),
                Placa = bus.Placa,
                Capacidad = bus.Capacidad,
                EstadoBus = bus.EstadoBus
            };
        }

  
    }
}
