using SGA.Application.DTOs.Viaje;
using SGA.Application.Interfaces.Trips;
using SGA.Domain.Base;

namespace SGA.Application.Services.Trips
{
    public class ViajeService : IViajeService
    {
        public Task<OperationResult<ViajeDto>> CreateAsync(CreateViajeDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<ViajeDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ViajeDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ViajeDto>> UpdateAsync(int id, UpdateViajeDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
