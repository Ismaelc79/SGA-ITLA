using SGA.Domain.Entities.Configuration;
using SGA.Persistence.Base;

namespace SGA.Persistence.Interfaces
{
    public interface  IHorarioRepository : IBaseRepository<Horario>
    {

        Task<Horario?> GetByRutaDiaHoraAsync(
                int rutaId,
                string diasOperacion,
                DateTime HoraInicio);
    }
}
