using SGA.Domain.Entities.Configuration;
using SGA.Domain.Enums;
using SGA.Persistence.Base;

namespace SGA.Persistence.Interfaces
{
    public interface  IHorarioRepository : IBaseRepository<Horario>
    {

        Task<Horario?> GetByRutaDiaHoraAsync(
                int Id,
                int rutaId,
                DiasOperacion diasOperacion,
                TimeOnly HoraInicio);
    }
}
