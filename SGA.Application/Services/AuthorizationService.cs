using SGA.Application.Dtos.Authorization;
using SGA.Application.Interfaces;
using SGA.Persistence.Interfaces.Autorizations;

namespace SGA.Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAutorizacionRepository _autorizacionRepository;

        public AuthorizationService(IAutorizacionRepository autorizacionRepository)
        {
            _autorizacionRepository = autorizacionRepository;
        }

        public async Task<List<AutorizacionDto>> GetAllAsync()
        {
            return new List<AutorizacionDto>();
        }

        public async Task<AutorizacionDto> GetByIdAsync(int id)
        {
            return new AutorizacionDto();
        }

        public async Task AddAsync(SaveAutorizacionDto autorizacionDto)
        {
        }

        public async Task UpdateAsync(UpdateAutorizacionDto autorizacionDto)
        {
        }

        public async Task DeleteAsync(int id)
        {
        }
    }
}