using SGA.Application.Dtos.Auth;
using SGA.Application.Interfaces;
using SGA.Persistence.Interfaces.Users;

namespace SGA.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<TokenDto> LoginAsync(LoginDto loginDto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(loginDto.Correo);

            if (usuario == null)
                throw new Exception("Usuario no encontrado.");

            if (usuario.PasswordHash != loginDto.Password)
                throw new Exception("Contraseña incorrecta.");

            return new TokenDto
            {
                Token = "TOKEN_TEMPORAL",
                Expiration = DateTime.Now.AddHours(1)
            };
        }
    }
}