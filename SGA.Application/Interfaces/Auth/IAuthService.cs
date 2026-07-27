using SGA.Application.DTOs.Auth;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<OperationResult<TokenDto>> LoginAsync(LoginDto loginDto);
    }
}
