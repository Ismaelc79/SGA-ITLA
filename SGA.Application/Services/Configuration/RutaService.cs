
using SGA.Application.DTOs.Ruta;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Base;
using SGA.Application.Exceptions;
using SGA.Persistence.Interfaces.Trips;
using SGA.Domain.Enums;

namespace SGA.Application.Services.Configuration
{
    public class RutaService : IRutaService
    {
        private readonly IRutaRepository _rutaRepository;

      public RutaService(IRutaRepository rutaRepository)
        {
            _rutaRepository = rutaRepository;
        }

        public async Task<OperationResult<IEnumerable<RutaDto>>> GetAllAsync()
        {
            var rutas = await _rutaRepository.GetAllAsync();

            return new OperationResult<IEnumerable<RutaDto>>
            {
                Success = true,
                Message = "Rutas obtenidas correctamente",
                Data = rutas.Select(MapToDto)
            };
        }

        public async Task<OperationResult<RutaDto>> GetByIdAsync(int id)
        {
           var ruta = await _rutaRepository.GetByIdAsync(id);

            if (ruta == null)
            {
               return new OperationResult<RutaDto>
               {
                   Success = false,
                   Message = $"No se encontró la ruta con ID {id}",
                   Errors = new List<string> { $"Ruta no encontrada"}
               };
            }

           return new OperationResult<RutaDto>
           {
               Success = true,
               Message = "Ruta obtenida correctamente",
               Data = MapToDto(ruta)
           };
        }

        public async Task<OperationResult<IEnumerable<RutaDto>>> GetByDisponibleAsync()
        {
            var ruta = await _rutaRepository.GetByDisponibleAsync();

            return new OperationResult<IEnumerable<RutaDto>>
            {
                Success = true,
                Message = "Rutas obtenidas exitosamente.",
                Data = ruta.Select(MapToDto)
            };
        }

        public async Task<OperationResult<RutaDto>> CreateAsync(CreateRutaDto dto)
        {
            await ValidarRutaUnicaAsync(dto.Nombre);

            if (dto.Nombre == "")
            {
                return new OperationResult<RutaDto>
                {
                    Success = false,
                    Message = $"El nombre de la ruta no puede estar vacío.",
                    Errors = new List<string> { "Nombre vacío o nulo" }
                };

            }

            var ruta = new Domain.Entities.Configuration.Ruta
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                RutaOrigen = dto.RutaOrigen,
                RutaDestino = dto.RutaDestino,
                EstadoRuta = EstadoRuta.Disponible //Todas las rutas comienzan con estado disponible

            };

            await _rutaRepository.AddAsync(ruta);

            return new OperationResult<RutaDto>
            {
                Success = true,
                Message = "Ruta creada exitosamente",
                Data = MapToDto(ruta)
            };
        }

        public async Task<OperationResult<RutaDto>> UpdateAsync(int id, UpdateRutaDto dto)
        {
            var rutaExistente = await _rutaRepository.GetByIdAsync(id);

            if (rutaExistente == null)
            {
                return new OperationResult<RutaDto>
                {
                    Success = false,
                    Message = $"No se encontró una ruta con el ID {id}.",
                    Errors = new List<string> {"Ruta no encontrada"}

                };

            }
            await ValidarRutaUnicaAsync(dto.Nombre,id);

            rutaExistente.Id = dto.Id;
            rutaExistente.Nombre = dto.Nombre;
            rutaExistente.RutaOrigen = dto.RutaOrigen;
            rutaExistente.RutaDestino = dto.RutaDestino;
            rutaExistente.EstadoRuta = dto.EstadoRuta;

            await _rutaRepository.UpdateAsync(rutaExistente);

            return new OperationResult<RutaDto>
            {
                Success = false,
                Message = "Ruta actualizada exitosamente",
                Data = MapToDto(rutaExistente)
            };
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var ruta = await _rutaRepository.GetByIdAsync(id);

            if (ruta == null)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encuentró una ruta con el ID {id}.",
                    Errors = new List<string> { "Ruta no encontrada" }
                };

            }

            await _rutaRepository.DeleteAsync(ruta);

            return new OperationResult<bool>
            {
                Success = true,
                Message = "Ruta eliminada exitosamente",
                Data = true
            };
        }



        private async Task ValidarRutaUnicaAsync(string nombre, int? idExcluir = null)
        {
            var rutaExistente = await _rutaRepository.GetByNombreAsync(nombre.Trim());

            if (rutaExistente != null && rutaExistente.Id != idExcluir)
            {
                throw new BusinessRuleException($"Ya existe una ruta con el nombre '{nombre}'.");
            }
        }

        private RutaDto MapToDto(Domain.Entities.Configuration.Ruta ruta)
        {
            return new RutaDto
            {
                Id = ruta.Id,
                Nombre = ruta.Nombre,
                EstadoRuta = ruta.EstadoRuta,
                RutaOrigen = ruta.RutaOrigen,
                RutaDestino = ruta.RutaDestino
            };
        }

    }
}
