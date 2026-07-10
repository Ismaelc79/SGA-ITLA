using SGA.Application.Dtos.Role;

namespace SGA.Application.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllAsync();
        Task<RoleDto> GetByIdAsync(int id);
        Task AddAsync(SaveRoleDto roleDto);
        Task UpdateAsync(UpdateRoleDto roleDto);
        Task DeleteAsync(int id);
    }
}