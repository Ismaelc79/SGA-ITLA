using SGA.Application.DTOs.Bus;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Trip
{
    public interface IBusService 
      
    {
        Task<OperationResult<IEnumerable<BusDto>>> GetAllAsync();
        Task<OperationResult<BusDto>> GetByIdAsync(int id);
        Task<OperationResult<BusDto>> CreateAsync(CreateBusDto dto);
        Task<OperationResult<BusDto>> UpdateAsync(int id, UpdateBusDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);
        Task<OperationResult<IEnumerable<BusDto>>> GetByActivosAsync();
        Task<OperationResult<BusDto>> ChangeStatusAsync(int id, BusStatusChangeDto dto);
        Task<OperationResult<BusDto>> GetByPlacaAsync(string placa);

    }
}
