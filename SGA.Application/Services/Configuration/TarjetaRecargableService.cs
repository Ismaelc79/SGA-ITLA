using SGA.Application.DTOs.TarjetaRecargable;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Base;

namespace SGA.Application.Services.Configuration
{
    internal class TarjetaRecargableService : ITarjetaRecargableService
    {
        public Task<OperationResult<TarjetaRecargableDto>> CreateAsync(CreateTarjetaRecargableDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<TarjetaRecargableDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TarjetaRecargableDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TarjetaRecargableDto>> UpdateAsync(int id, UpdateTarjetaRecargableDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
