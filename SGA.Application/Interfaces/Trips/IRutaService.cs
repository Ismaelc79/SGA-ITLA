using SGA.Application.DTOs.Bus;
using SGA.Application.DTOs.Ruta;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Trips
{
    public interface IRutaService 
       
    {
        Task<OperationResult<IEnumerable<RutaDto>>> GetAllAsync();
        Task<OperationResult<RutaDto>> GetByIdAsync(int id);
        Task<OperationResult<RutaDto>> CreateAsync(CreateRutaDto dto);
        Task<OperationResult<RutaDto>> UpdateAsync(int id, UpdateRutaDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);
        Task<OperationResult<IEnumerable<RutaDto>>> GetByDisponibleAsync();

    }
}
