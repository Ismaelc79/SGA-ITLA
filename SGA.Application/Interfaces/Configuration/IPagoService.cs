using SGA.Application.DTOs.Pago;
using SGA.Domain.Base;


namespace SGA.Application.Interfaces.Configuration
{
    public interface IPagoService
    {
        Task<OperationResult<IEnumerable<PagoDto>>> GetAllAsync();
        Task<OperationResult<PagoDto>> GetByIdAsync(int id);
        Task<OperationResult<PagoDto>> CreateAsync(CreatePagoDto dto);
        Task<OperationResult<PagoDto>> UpdateAsync(int id, UpdatePagoDto dto);
        Task<OperationResult<PagoDto>> ChangeStatusAsync(int id, PagoStatusChangeDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);
    }
}
