using FluentValidation; 
using SGA.Application.DTOs.Bus;
using SGA.Application.Exceptions;
using SGA.Application.Interfaces.Trip;
using SGA.Domain.Base;
using SGA.Domain.Enums;
using SGA.Persistence.Interfaces.Trips;

namespace SGA.Application.Services.Trips
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;
        private readonly IValidator<CreateBusDto> _createValidator;
        private readonly IValidator<UpdateBusDto> _updateValidator;
        private readonly IValidator<BusStatusChangeDto>  _statusChangeValidator; 

        public BusService(
            IBusRepository busRepository, 
            IValidator<CreateBusDto> createValidator, 
            IValidator<UpdateBusDto> updateValidator, 
            IValidator<BusStatusChangeDto> statusChangeValidator)
        {
            _busRepository = busRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _statusChangeValidator = statusChangeValidator;
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

        public async Task<OperationResult<IEnumerable<BusDto>>> GetByActivosAsync()
        {
            var buses = await _busRepository.GetByActivosAsync();

            return new OperationResult<IEnumerable<BusDto>>
            {
                Success = true,
                Message = "Buses activos obtenidos exitosamente.",
                Data = buses.Select(MapToDto)
            };
        }
       
        public async Task<OperationResult<BusDto>> GetByPlacaAsync(string placa)
        {
            var bus = await _busRepository.GetByPlacaAsync(placa);
            if (bus == null)
            {
                return new OperationResult<BusDto>
                {
                    Success = false,
                    Message = $"No se encontró un bus con la placa '{placa}'.",
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
            //Validar formato de los datos
            var validacion = _createValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<BusDto>
                {
                    Success = false,
                    Message = "Los datos del autobús no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            await ValidarPlacaUnicaAsync(dto.Placa);

            var bus = new Domain.Entities.Trip.Bus
            {
                ConductorId = dto.ConductorId,
                Placa = dto.Placa,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
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
            var validacion = _updateValidator.Validate(dto);

            if (!validacion.IsValid) 
            {
                return new OperationResult<BusDto>
                {
                    Success = false,
                    Message = "Los datos del autobús no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var busExistente = await _busRepository.GetByIdAsync(id);

            if (busExistente == null){ 

                return new OperationResult<BusDto>
                {
                    Success = false,
                    Message = $"No se encontró un bus con el ID {id}.",
                    Errors = new List<string> { "Bus no encontrado." }
                };
            }

            await ValidarPlacaUnicaAsync(dto.Placa);

            busExistente.Placa = dto.Placa;
            busExistente.Capacidad = dto.Capacidad;
            busExistente.Marca = dto.Marca;
            busExistente.Modelo = dto.Modelo;
            busExistente.ConductorId = dto.ConductorId;
            busExistente.EstadoBus = dto.EstadoBus;

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

          public async Task<OperationResult<BusDto>> ChangeStatusAsync(int id, BusStatusChangeDto dto)
        {
            var validacion = _statusChangeValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<BusDto>
                {
                    Success = false,
                    Message = "Los datos del cambio de estado no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

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


        private async Task ValidarPlacaUnicaAsync(string placa)
        {
            var busExistente = await _busRepository.GetByPlacaAsync(placa);

            if (busExistente != null)
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
                Id = bus.Id,
                Placa = bus.Placa,
                Marca = bus.Marca,
                Modelo = bus.Modelo,
                Capacidad = bus.Capacidad,
                EstadoBus = bus.EstadoBus
            };
        }

  
    }
}
