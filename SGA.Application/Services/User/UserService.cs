using FluentValidation;
using SGA.Application.DTOs.User;
using SGA.Application.Interfaces.User;
using SGA.Domain.Base;
using SGA.Domain.Entities.Users;
using SGA.Domain.Enums;
using SGA.Persistence.Interfaces.Users;

namespace SGA.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IValidator<CreateUserDto> _createValidator;
        private readonly IValidator<UpdateUserDto> _updateValidator;

        public UserService(
            IUsuarioRepository usuarioRepository,
            IValidator<CreateUserDto> createValidator,
            IValidator<UpdateUserDto> updateValidator)
        {
            _usuarioRepository = usuarioRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<OperationResult<IEnumerable<UserDto>>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            return new OperationResult<IEnumerable<UserDto>>
            {
                Success = true,
                Message = "Usuarios obtenidos exitosamente.",
                Data = usuarios.Select(MapToDto)
            };
        }

        public async Task<OperationResult<UserDto>> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
            {
                return new OperationResult<UserDto>
                {
                    Success = false,
                    Message = $"No se encontró un usuario con el ID {id}.",
                    Errors = new List<string> { "Usuario no encontrado." }
                };
            }

            return new OperationResult<UserDto>
            {
                Success = true,
                Message = "Usuario encontrado exitosamente.",
                Data = MapToDto(usuario)
            };
        }

        public async Task<OperationResult<UserDto>> CreateAsync(CreateUserDto dto)
        {
            var validacion = _createValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<UserDto>
                {
                    Success = false,
                    Message = "Los datos del usuario no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var usuario = new Usuario
            {
                Nombre = dto.UserName,
                Email = dto.Email,
                PasswordHash = dto.Password,
                RolId = 4,
                Estado = EstadoUsuario.Activo,
                EstaRestringido = false
            };

            await _usuarioRepository.AddAsync(usuario);

            return new OperationResult<UserDto>
            {
                Success = true,
                Message = "Usuario creado exitosamente.",
                Data = MapToDto(usuario)
            };
        }

        public async Task<OperationResult<UserDto>> UpdateAsync(int id, UpdateUserDto dto)
        {
            var validacion = _updateValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<UserDto>
                {
                    Success = false,
                    Message = "Los datos del usuario no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);

            if (usuarioExistente == null)
            {
                return new OperationResult<UserDto>
                {
                    Success = false,
                    Message = $"No se encontró un usuario con el ID {id}.",
                    Errors = new List<string> { "Usuario no encontrado." }
                };
            }

            usuarioExistente.Nombre = dto.UserName;
            usuarioExistente.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                usuarioExistente.PasswordHash = dto.Password;
            }

            await _usuarioRepository.UpdateAsync(usuarioExistente);

            return new OperationResult<UserDto>
            {
                Success = true,
                Message = "Usuario actualizado exitosamente.",
                Data = MapToDto(usuarioExistente)
            };
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encontró un usuario con el ID {id}.",
                    Errors = new List<string> { "Usuario no encontrado." }
                };
            }

            await _usuarioRepository.DeleteAsync(usuario);

            return new OperationResult<bool>
            {
                Success = true,
                Message = "Usuario eliminado exitosamente.",
                Data = true
            };
        }

        private static UserDto MapToDto(Usuario usuario)
        {
            return new UserDto
            {
                Id = usuario.Id,
                UserName = usuario.Nombre,
                Email = usuario.Email
            };
        }
    }
}
