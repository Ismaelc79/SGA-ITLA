using SGA.Application.Base;
using SGA.Application.DTOs.Bus;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Trip
{
    public interface IBusService : 
        IBaseService<BusDto, CreateBusDto, UpdateBusDto>
    {
      Task<OperationResult<IEnumerable<BusDto>>> GetByActivosAsync();
      Task<OperationResult<BusDto>> ChangeStatusAsync(int id, BusStatusChangeDto dto);
      Task<OperationResult<BusDto>> GetByPlacaAsync(string placa);

    }
}
