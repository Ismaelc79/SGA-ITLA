using FluentValidation;
using SGA.Application.DTOs.Horario;
using SGA.Application.Exceptions;
using SGA.Application.Interfaces.Trips;
using SGA.Domain.Base;
using SGA.Domain.Enums;
using SGA.Persistence.Interfaces;
using SGA.Persistence.Interfaces.Trips;

namespace SGA.Application.Services.Trips
{
    public class HorarioService : IHorarioService
    {
        private readonly IHorarioRepository _horarioRepository;
        private readonly IRutaRepository _rutaRepository;
        private readonly IValidator<CreateHorarioDto> _createValidator;
        private readonly IValidator<UpdateHorarioDto> _updateValidator;

        public HorarioService(
            IHorarioRepository horarioRepository,
            IRutaRepository rutaRepository,
            IValidator<CreateHorarioDto> createValidator,
            IValidator<UpdateHorarioDto> updateValidator)
        {
            _horarioRepository = horarioRepository;
            _rutaRepository = rutaRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<OperationResult<IEnumerable<HorarioDto>>> GetAllAsync()
        {
            var horario = await _horarioRepository.GetAllAsync();

            return new OperationResult<IEnumerable<HorarioDto>>
            {
                Success = true,
                Message = "Horarios obtenidos exitosamente.",
                Data = horario.Select(MapToDto)
            };
        }

        public async Task<OperationResult<HorarioDto>> GetByIdAsync(int id)
        {
            var horario = await _horarioRepository.GetByIdAsync(id);

            if (horario == null) {

                return new OperationResult<HorarioDto>
                {
                    Success = false,
                    Message = $"No se encontró un horario con el ID {id}",
                    Errors = new List<string> {"Horario no encontrado"}

                };
            }

            return new OperationResult<HorarioDto>
            {
                Success= true,
                Message = "Horario obtenido exitosamente",
                Data = MapToDto(horario)
            };
        }

        public async Task<OperationResult<HorarioDto>> CreateAsync(CreateHorarioDto dto)
        {
            //Validar formato de los datos
            var validacion = _createValidator.Validate(dto);

            if (!validacion.IsValid)
            {
                return new OperationResult<HorarioDto>
                {
                    Success = false,
                    Message = "Los datos del horario no son válidos",
                    Errors =   validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            await ValidarHorarioExistente(
                dto.Id,
                dto.RutaId,
                dto.DiasOperacion,
                dto.HoraInicio
                );

            await ValidarRutaExistente(dto.RutaId);

            var horario = new Domain.Entities.Configuration.Horario
            {
                RutaId = dto.RutaId,
                DiasOperacion = dto.DiasOperacion,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin,

            };

            await _horarioRepository.AddAsync(horario);

            return new OperationResult<HorarioDto>
            {
                Success = true,
                Message = "Horario creado exitosamente",
                Data = MapToDto(horario)
            };
        }

        public async Task<OperationResult<HorarioDto>> UpdateAsync(int id, UpdateHorarioDto dto)
        {
            var validacion = _updateValidator.Validate(dto);
            if (!validacion.IsValid) 
            {
                return new OperationResult<HorarioDto>
                {
                    Success = false,
                    Message = "Los datos del horario no son válidos",
                    Errors = validacion.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var horarioExistente = await _horarioRepository.GetByIdAsync(id);

            if (horarioExistente == null)
            {
                return new OperationResult<HorarioDto>
                {
                    Success = false,
                    Message = $"No se encontró un Horario con el ID '{id}'.",
                    Errors = new List<string>() {"Horario no encontrado"}
                };

            }

            await ValidarRutaExistente(dto.RutaId);

            horarioExistente.RutaId = dto.RutaId;
            horarioExistente.DiasOperacion = dto.DiasOperacion;
            horarioExistente.HoraInicio = dto.HoraInicio;
            horarioExistente.HoraFin = dto.HoraFin;

            await _horarioRepository.UpdateAsync(horarioExistente);

            return new OperationResult<HorarioDto>
            {
                Success = true,
                Message = "Horario actualizado exitosamente",
                Data = MapToDto(horarioExistente)
            };
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var horarioExistente = await _horarioRepository.GetByIdAsync(id);

            if (horarioExistente == null)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encontró un horario con el ID '{id}'",
                    Errors = new List<string> {"Horario no encontrado"}

                };
            }

            await _horarioRepository.DeleteAsync(horarioExistente);
            return new OperationResult<bool>
            {
                Success = true,
                Message = "Horario eliminado exitosamente",
                Data = true
            };
        }

        private async Task ValidarHorarioExistente(
            int Id,
            int rutaId,
            DiasOperacion diasOperacion,
            TimeOnly horaInicio,
            int? idExcluir =null) 
        {
            var horarioExistente = await _horarioRepository.GetByRutaDiaHoraAsync(
                Id, rutaId, diasOperacion, horaInicio);

            if (horarioExistente != null && horarioExistente.Id != idExcluir)
            {
                throw new BusinessRuleException($"Ya existe ese horario en la ruta");
            }
        
        }

        private async Task ValidarRutaExistente(int rutaId)
        {
            var ruta  = await _rutaRepository.GetByIdAsync(rutaId);

            if(ruta == null)
            {
                throw new BusinessRuleException($"No existe una ruta con el ID {rutaId}");
            }
        }

        private HorarioDto MapToDto(Domain.Entities.Configuration.Horario horario)
        {
            return new HorarioDto
            {
                Id = horario.Id,
                RutaId = horario.RutaId,
                RutaNombre = horario.Ruta?.Nombre,
                DiasOperacion = horario.DiasOperacion,
                HoraInicio = horario.HoraInicio,
                HoraFin = horario.HoraFin

            };
        }

    }
}
