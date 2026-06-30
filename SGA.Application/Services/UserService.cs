using SGA.Application.Dtos.User;
using SGA.Application.Interfaces;

namespace SGA.Application.Services
{
    public class UserService : IUserService
    {
       
        public async Task<List<UserDto>> GetAllAsync()
        {
            return new List<UserDto>(); 
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            return new UserDto();
        }

        public async Task AddAsync(SaveUserDto userDto)
        {
          
        }

        public async Task UpdateAsync(UpdateUserDto userDto)
        {
        
        }

        public async Task DeleteAsync(int id)
        {
            
        }
    }
}