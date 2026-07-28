using SGA.Application.DTOs.TarjetaRecargable;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Configuration
{
    public interface ITarjetaRecargableService
    {
        Task<OperationResult<IEnumerable<TarjetaRecargableDto>>> GetAllAsync();
        Task<OperationResult<TarjetaRecargableDto>> GetByIdAsync(int id);
        Task<OperationResult<TarjetaRecargableDto>> CreateAsync(CreateTarjetaRecargableDto dto);
        Task<OperationResult<TarjetaRecargableDto>> UpdateAsync(int id, UpdateTarjetaRecargableDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);
    }
}
