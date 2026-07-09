using SGA.Application.DTOs.Parada;
using SGA.Application.Exceptions;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Base;
using SGA.Persistence.Interfaces.Trips;

namespace SGA.Application.Services.Configuration
{
    public class ParadaService : IParadaService
    {
        private readonly IParadaRepository _paradaRepository;
        public ParadaService(IParadaRepository paradaRepository)
        {
            _paradaRepository = paradaRepository;
        }

        public async Task<OperationResult<IEnumerable<ParadaDto>>> GetAllAsync()
        {
            var parada = await _paradaRepository.GetAllAsync();
            return new OperationResult<IEnumerable<ParadaDto>>
            {
                Success = true,
                Message = "Paradas obtenidas correctamente",
                Data = parada.Select(MapToDto)

            };
            
        }

        public async Task<OperationResult<ParadaDto>> GetByIdAsync(int id)
        {
           var parada = await _paradaRepository.GetByIdAsync(id);

            if (parada == null)
            {
                return new OperationResult<ParadaDto>
                {
                    Success = false,
                    Message = $"No se encontró la parada con ID {id}",
                    Errors = new List<string> {"Parada no encontrada"}
                };
            }

            return new OperationResult<ParadaDto>
            {
                Success = true,
                Message = "Parada obtenida correctamente",
                Data = MapToDto(parada)
            };
        }

        public async Task<OperationResult<ParadaDto>> CreateAsync(CreateParadaDto dto)
        {
            await ValidarParadaAsync(dto.Nombre);

            if (dto.Nombre == null)
            {
                return new OperationResult<ParadaDto>
                {
                    Success = false,
                    Message = $"El nombre de la parada no puede estar vacío",
                    Errors = new List<string> { "Nombre vacío o nulo" }
                };
            }

            var parada = new Domain.Entities.Configuration.Parada
            {
                RutaId = dto.RutaId,
                Nombre = dto.Nombre,
                Ubicacion = dto.Ubicacion,
                OrdenParada = dto.OrdenParada,
                Estado = dto.Estado

            };

            await _paradaRepository.AddAsync(parada);

            return new OperationResult<ParadaDto>
            {
                Success = true,
                Message = "Parada creada exitosamente",
                Data = MapToDto(parada)
            };
        }

        public async Task<OperationResult<ParadaDto>> UpdateAsync(int id, UpdateParadaDto dto)
        {
            var paradaExistente = await _paradaRepository.GetByIdAsync(id);

            if (paradaExistente == null)
            {
                return new OperationResult<ParadaDto>
                {
                    Success = false,
                    Message = $"No se encontró una parada con el ID {id}",
                    Errors = new List<string> {"Parada no encontrada"}
                };
            }

            await ValidarParadaAsync(dto.Nombre,id);

            paradaExistente.RutaId = dto.RutaId;
            paradaExistente.Nombre = dto.Nombre;
            paradaExistente.Ubicacion = dto.Ubicacion;
            paradaExistente.OrdenParada = dto.OrdenParada;
            paradaExistente.Estado = dto.Estado;

            await _paradaRepository.UpdateAsync(paradaExistente);

            return new OperationResult<ParadaDto>
            {
                Success = true,
                Message = "Parada actualizada exitosamente",
                Data = MapToDto(paradaExistente)
            };
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var paradaExistente = await _paradaRepository.GetByIdAsync(id);

            if (paradaExistente == null)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encontró una parada con el ID {id}",
                    Errors = new List<string> {"Parada no encontrada"}

                };

            } 
            
            await _paradaRepository.DeleteAsync(paradaExistente);

            return new OperationResult<bool>
            {
                Success = true,
                Message = "Parada eliminada exitosamente",
                Data = true
            };
        }


        private async Task ValidarParadaAsync(string nombre, int? idExcluir = null)
        {
            var paradaExistente = await _paradaRepository.GetByNombreAsync(nombre.Trim());

            if (paradaExistente != null && paradaExistente.Id != idExcluir)
            {
                throw new BusinessRuleException($"Ya existe una palabra con el nombre '{nombre}'.");
            }
            
        }

        private ParadaDto MapToDto(Domain.Entities.Configuration.Parada parada)
        {
            return new ParadaDto
            {
                Id = parada.Id,
                Nombre = parada.Nombre,
                Ubicacion = parada.Ubicacion,
                OrdenParada = parada.OrdenParada,
                Estado = parada.Estado

            };
        }
       
    }
}
