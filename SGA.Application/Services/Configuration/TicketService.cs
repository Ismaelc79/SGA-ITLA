using SGA.Application.DTOs.Ticket;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Base;

namespace SGA.Application.Services.Configuration
{
    public class TicketService : ITicketService
    {
        public Task<OperationResult<TicketDto>> CreateAsync(CreateTicketDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<TicketDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TicketDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TicketDto>> UpdateAsync(int id, UpdateTicketDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
