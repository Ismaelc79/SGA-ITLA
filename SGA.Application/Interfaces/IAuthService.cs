using SGA.Application.Dtos.Auth;

namespace SGA.Application.Interfaces
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(LoginDto loginDto);
    }
}