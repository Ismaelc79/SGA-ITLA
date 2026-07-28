
using SGA.Application.DTOs.Bus;
using SGA.Application.DTOs.Parada;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Trips
{
    public interface IParadaService 
        
    {
        Task<OperationResult<IEnumerable<ParadaDto>>> GetAllAsync();
        Task<OperationResult<ParadaDto>> GetByIdAsync(int id);
        Task<OperationResult<ParadaDto>> CreateAsync(CreateParadaDto dto);
        Task<OperationResult<ParadaDto>> UpdateAsync(int id, UpdateParadaDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);

    }
}
