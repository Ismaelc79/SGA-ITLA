using FluentValidation;
using SGA.Application.DTOs.Role;
using SGA.Application.Interfaces.Role;
using SGA.Domain.Base;
using SGA.Domain.Entities.Users;
using SGA.Persistence.Interfaces.Users;

namespace SGA.Application.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly IRolRepository _roleRepository;
        private readonly IValidator<CreateRoleDto> _createValidator;
        private readonly IValidator<UpdateRoleDto> _updateValidator;

        public RoleService(
            IRolRepository roleRepository,
            IValidator<CreateRoleDto> createValidator,
            IValidator<UpdateRoleDto> updateValidator)
        {
            _roleRepository = roleRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<OperationResult<IEnumerable<RoleDto>>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();

            return new OperationResult<IEnumerable<RoleDto>>
            {
                Success = true,
                Message = "Roles obtenidos exitosamente.",
                Data = roles.Select(MapToDto)
            };
        }

        public async Task<OperationResult<RoleDto>> GetByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role == null)
            {
                return new OperationResult<RoleDto>
                {
                    Success = false,
                    Message = $"No se encontró un rol con el ID {id}.",
                    Errors = new List<string> { "Rol no encontrado." }
                };
            }

            return new OperationResult<RoleDto>
            {
                Success = true,
                Message = "Rol encontrado exitosamente.",
                Data = MapToDto(role)
            };
        }

        public async Task<OperationResult<RoleDto>> CreateAsync(CreateRoleDto dto)
        {
            var validacion = _createValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<RoleDto>
                {
                    Success = false,
                    Message = "Los datos del rol no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var role = new Rol
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };

            await _roleRepository.AddAsync(role);

            return new OperationResult<RoleDto>
            {
                Success = true,
                Message = "Rol creado exitosamente.",
                Data = MapToDto(role)
            };
        }

        public async Task<OperationResult<RoleDto>> UpdateAsync(int id, UpdateRoleDto dto)
        {
            var validacion = _updateValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<RoleDto>
                {
                    Success = false,
                    Message = "Los datos del rol no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var roleExistente = await _roleRepository.GetByIdAsync(id);

            if (roleExistente == null)
            {
                return new OperationResult<RoleDto>
                {
                    Success = false,
                    Message = $"No se encontró un rol con el ID {id}.",
                    Errors = new List<string> { "Rol no encontrado." }
                };
            }

            roleExistente.Nombre = dto.Nombre;
            roleExistente.Descripcion = dto.Descripcion;

            await _roleRepository.UpdateAsync(roleExistente);

            return new OperationResult<RoleDto>
            {
                Success = true,
                Message = "Rol actualizado exitosamente.",
                Data = MapToDto(roleExistente)
            };
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role == null)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encontró un rol con el ID {id}.",
                    Errors = new List<string> { "Rol no encontrado." }
                };
            }

            await _roleRepository.DeleteAsync(role);

            return new OperationResult<bool>
            {
                Success = true,
                Message = "Rol eliminado exitosamente.",
                Data = true
            };
        }

        private static RoleDto MapToDto(Rol role)
        {
            return new RoleDto
            {
                Id = role.Id,
                Nombre = role.Nombre,
                Descripcion = role.Descripcion
            };
        }
    }
}