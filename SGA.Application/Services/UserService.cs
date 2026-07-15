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

            return usuarios.Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.Nombre,
                Email = u.Email
            }).ToList();
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new Exception("El ID del usuario no es válido.");

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
            if (string.IsNullOrWhiteSpace(userDto.UserName))
                throw new Exception("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(userDto.Email))
                throw new Exception("El correo es obligatorio.");

            if (string.IsNullOrWhiteSpace(userDto.Password))
                throw new Exception("La contraseña es obligatoria.");

            var usuario = new Usuario
            {
                Nombre = userDto.UserName,
                Email = userDto.Email,
                PasswordHash = userDto.Password,
                RolId = 4,
                Estado = EstadoUsuario.Activo,
                EstaRestringido = false
            };

            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateAsync(UpdateUserDto userDto)
        {
            if (userDto.Id <= 0)
                throw new Exception("El ID del usuario no es válido.");

            var usuario = await _usuarioRepository.GetByIdAsync(userDto.Id);

            if (usuario == null)
                throw new Exception("Usuario no encontrado.");

            if (string.IsNullOrWhiteSpace(userDto.UserName))
                throw new Exception("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(userDto.Email))
                throw new Exception("El correo es obligatorio.");

            usuario.Nombre = userDto.UserName;
            usuario.Email = userDto.Email;

            if (!string.IsNullOrWhiteSpace(userDto.Password))
            {
                usuario.PasswordHash = userDto.Password;
            }

            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new Exception("El ID del usuario no es válido.");

            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
                throw new Exception("Usuario no encontrado.");

            await _usuarioRepository.DeleteAsync(usuario);
        }
    }
}