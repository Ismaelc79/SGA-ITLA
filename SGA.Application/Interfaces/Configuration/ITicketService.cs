
using SGA.Application.DTOs.Ticket;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Configuration
{
    public interface ITicketService
    {
        Task<OperationResult<IEnumerable<TicketDto>>> GetAllAsync();
        Task<OperationResult<TicketDto>> GetByIdAsync(int id);
        Task<OperationResult<TicketDto>> CreateAsync(CreateTicketDto dto);
        Task<OperationResult<TicketDto>> UpdateAsync(int id, UpdateTicketDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);
    }
}
