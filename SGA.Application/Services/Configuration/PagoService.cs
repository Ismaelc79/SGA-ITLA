
using SGA.Application.DTOs.Pago;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Base;
using SGA.Persistence.Interfaces.Autorizations;

namespace SGA.Application.Services.Configuration
{
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _pagoRepository;

        public PagoService(IPagoRepository pagoRepository)
        {
            _pagoRepository = pagoRepository;
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
