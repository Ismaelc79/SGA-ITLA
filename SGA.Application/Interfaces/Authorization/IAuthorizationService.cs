using SGA.Application.DTOs.Authorization;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Authorization
{
    public interface IAuthorizationService
    {
        Task<OperationResult<IEnumerable<AutorizacionDto>>> GetAllAsync();
        Task<OperationResult<AutorizacionDto>> GetByIdAsync(int id);
        Task<OperationResult<AutorizacionDto>> CreateAsync(CreateAutorizacionDto dto);
        Task<OperationResult<AutorizacionDto>> UpdateAsync(int id, UpdateAutorizacionDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);
        Task<OperationResult<AutorizacionDto>> ChangeStatusAsync(int id, AutorizacionStatusChangeDto dto);
    }
}
