
using SGA.Application.Base;
using SGA.Application.DTOs.Bus;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Configuration
{
    public interface IBusService : 
        IBaseService<BusDto, CreateBusDto, UpdateBusDto>
    {
      Task<OperationResult<IEnumerable<BusDto>>> GetActiveAsync();
      Task<OperationResult<BusDto>> ChangeStatusAsync(int id, BusStatusChangeDto dto);
    }
}
