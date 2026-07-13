using SGA.Application.DTOs.Viaje;
using SGA.Domain.Base;
using SGA.Domain.Enums;


namespace SGA.Application.Interfaces.Trips
{
    public interface IViajeService 
        
    {
        Task<OperationResult<IEnumerable<ViajeDto>>> GetAllAsync();
        Task<OperationResult<ViajeDto>> GetByIdAsync(int id);
        Task<OperationResult<IEnumerable<ViajeDto>>> GetByEstadoAsync(EstadoViaje estado);

        Task<OperationResult<ViajeDto>> CreateAsync(CreateViajeDto dto);
        Task<OperationResult<ViajeDto>> UpdateAsync(int id, UpdateViajeDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);
        Task<OperationResult<ViajeDto>> ChangeStatusAsync(int id, ViajeStatusChangeDto dto);

    }
}
