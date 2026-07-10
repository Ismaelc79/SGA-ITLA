using System.Linq;
using SGA.Application.Dtos.User;
using SGA.Application.Interfaces;
using SGA.Domain.Entities.Users;
using SGA.Domain.Enums;
using SGA.Persistence.Interfaces.Users;

namespace SGA.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UserService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            var resultado = usuarios.Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.Nombre,
                Email = u.Email
            }).ToList();

            return resultado;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
                return null;

            return new UserDto
            {
                Id = usuario.Id,
                UserName = usuario.Nombre,
                Email = usuario.Email
            };
        }

        public async Task AddAsync(SaveUserDto userDto)
        {
            var usuario = new Usuario
            {
                Nombre = userDto.UserName,
                Email = userDto.Email,
                PasswordHash = userDto.Password,
                RolId = 1,
                Estado = EstadoUsuario.Activo,
                EstaRestringido = false
            };

            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateAsync(UpdateUserDto userDto)
        {
        
        }

        public async Task DeleteAsync(int id)
        {
            
        }
    }
}