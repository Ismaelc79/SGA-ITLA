using SGA.Application.DTOs.User;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.User
{
    public interface IUserService
    {
        Task<OperationResult<IEnumerable<UserDto>>> GetAllAsync();
        Task<OperationResult<UserDto>> GetByIdAsync(int id);
        Task<OperationResult<UserDto>> CreateAsync(CreateUserDto dto);
        Task<OperationResult<UserDto>> UpdateAsync(int id, UpdateUserDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);
    }
}