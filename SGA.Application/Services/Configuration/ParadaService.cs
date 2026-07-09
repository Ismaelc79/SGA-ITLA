using SGA.Application.DTOs.Parada;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Base;

namespace SGA.Application.Services.Configuration
{
    public class ParadaService : IParadaService
    {
        public Task<OperationResult<ParadaDto>> CreateAsync(CreateParadaDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<ParadaDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ParadaDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ParadaDto>> UpdateAsync(int id, UpdateParadaDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
