using SGA.Application.Dtos.Authorization;

namespace SGA.Application.Interfaces
{
    public interface IAuthorizationService
    {
        Task<List<AutorizacionDto>> GetAllAsync();
        Task<AutorizacionDto> GetByIdAsync(int id);
        Task AddAsync(SaveAutorizacionDto autorizacionDto);
        Task UpdateAsync(UpdateAutorizacionDto autorizacionDto);
        Task DeleteAsync(int id);
    }
}