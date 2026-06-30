using SGA.Application.Dtos.User;

namespace SGA.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task AddAsync(SaveUserDto userDto);
        Task UpdateAsync(UpdateUserDto userDto);
        Task DeleteAsync(int id);
    }
}