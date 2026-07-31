using FluentValidation;
using SGA.Application.DTOs.Auth;
using SGA.Application.Interfaces.Auth;
using SGA.Domain.Base;
using SGA.Persistence.Interfaces.Users;

namespace SGA.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IValidator<LoginDto> _loginValidator;

        public AuthService(IUsuarioRepository usuarioRepository, IValidator<LoginDto> loginValidator)
        {
            _usuarioRepository = usuarioRepository;
            _loginValidator = loginValidator;
        }

        public async Task<OperationResult<TokenDto>> LoginAsync(LoginDto loginDto)
        {
            var validacion = _loginValidator.Validate(loginDto);

            if (!validacion.IsValid)
            {
                return new OperationResult<TokenDto>
                {
                    Success = false,
                    Message = "Los datos de inicio de sesión no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var usuario = await _usuarioRepository.GetByEmailAsync(loginDto.Correo);

            if (usuario == null)
            {
                return new OperationResult<TokenDto>
                {
                    Success = false,
                    Message = "Usuario no encontrado.",
                    Errors = new List<string> { "Usuario no encontrado." }
                };
            }

            if (usuario.PasswordHash != loginDto.Password)
            {
                return new OperationResult<TokenDto>
                {
                    Success = false,
                    Message = "Contraseña incorrecta.",
                    Errors = new List<string> { "Contraseña incorrecta." }
                };
            }

            return new OperationResult<TokenDto>
            {
                Success = true,
                Message = "Inicio de sesión exitoso.",
                Data = new TokenDto
                {
                    Token = "TOKEN_TEMPORAL",
                    Expiration = DateTime.Now.AddHours(1)
                }
            };
        }
    }
}