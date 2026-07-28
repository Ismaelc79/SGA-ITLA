using SGA.Domain.Entities.Trip;
using SGA.Domain.Enums;
using SGA.Persistence.Base;

namespace SGA.Persistence.Interfaces.Trips
{
    public interface IViajeRepository: IBaseRepository<Viaje>
    {
        Task<IEnumerable<Viaje>> GetByEstadoAsync(EstadoViaje estado);
    }
}
