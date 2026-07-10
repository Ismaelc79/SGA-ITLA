using SGA.Application.DTOs.Viaje;
using SGA.Domain.Base;


namespace SGA.Application.Interfaces.Trips
{
    public interface IViajeService 
        
    {
        Task<OperationResult<IEnumerable<ViajeDto>>> GetAllAsync();
        Task<OperationResult<ViajeDto>> GetByIdAsync(int id);
        Task<OperationResult<ViajeDto>> CreateAsync(CreateViajeDto dto);
        Task<OperationResult<ViajeDto>> UpdateAsync(int id, UpdateViajeDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);

    }
}
