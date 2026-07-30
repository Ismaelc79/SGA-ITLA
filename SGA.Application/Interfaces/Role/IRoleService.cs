using SGA.Application.DTOs.Role;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Role
{
    public interface IRoleService
    {
        Task<OperationResult<IEnumerable<RoleDto>>> GetAllAsync();
        Task<OperationResult<RoleDto>> GetByIdAsync(int id);
        Task<OperationResult<RoleDto>> CreateAsync(CreateRoleDto dto);
        Task<OperationResult<RoleDto>> UpdateAsync(int id, UpdateRoleDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);
    }
}