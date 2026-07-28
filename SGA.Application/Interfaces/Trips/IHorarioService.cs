using SGA.Application.DTOs.Bus;
using SGA.Application.DTOs.Horario;
using SGA.Domain.Base;

namespace SGA.Application.Interfaces.Trips
{
    public interface IHorarioService 
       
    {
        Task<OperationResult<IEnumerable<HorarioDto>>> GetAllAsync();
        Task<OperationResult<HorarioDto>> GetByIdAsync(int id);
        Task<OperationResult<HorarioDto>> CreateAsync(CreateHorarioDto dto);
        Task<OperationResult<HorarioDto>> UpdateAsync(int id, UpdateHorarioDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);

    }
}
