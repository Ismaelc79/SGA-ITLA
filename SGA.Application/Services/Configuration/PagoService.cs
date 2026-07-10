
using SGA.Application.DTOs.Pago;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Base;

namespace SGA.Application.Services.Configuration
{
    public class PagoService : IPagoService
    {
        public Task<OperationResult<PagoDto>> CreateAsync(CreatePagoDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<PagoDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<PagoDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<PagoDto>> UpdateAsync(int id, UpdatePagoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
