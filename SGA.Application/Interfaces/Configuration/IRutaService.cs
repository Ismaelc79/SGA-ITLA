using SGA.Application.Base;
using SGA.Application.DTOs.Ruta;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Configuration
{
    public interface IRutaService : 
        IBaseService<RutaDto,CreateRutaDto, UpdateRutaDto>
    {
        Task<OperationResult<IEnumerable<RutaDto>>> GetByDisponibleAsync();

    }
}
