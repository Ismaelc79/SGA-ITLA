using SGA.Application.Dtos.Role;
using SGA.Application.Interfaces;
using SGA.Domain.Entities.Users;
using SGA.Persistence.Interfaces.Users;

namespace SGA.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRolRepository _roleRepository;

        public RoleService(IRolRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();

            return roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion
            }).ToList();
        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role == null)
                return null;

            return new RoleDto
            {
                Id = role.Id,
                Nombre = role.Nombre,
                Descripcion = role.Descripcion
            };
        }

        public async Task AddAsync(SaveRoleDto roleDto)
        {
            var role = new Rol
            {
                Nombre = roleDto.Nombre,
                Descripcion = roleDto.Descripcion
            };

            await _roleRepository.AddAsync(role);
        }

        public async Task UpdateAsync(UpdateRoleDto roleDto)
        {
            var role = new Rol
            {
                Id = roleDto.Id,
                Nombre = roleDto.Nombre,
                Descripcion = roleDto.Descripcion
            };

            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role != null)
            {
                await _roleRepository.DeleteAsync(role);
            }
        }
    }
}