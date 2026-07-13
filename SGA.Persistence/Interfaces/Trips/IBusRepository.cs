using SGA.Domain.Entities.Trip;
using SGA.Persistence.Base;


namespace SGA.Persistence.Interfaces.Trips
{
    public interface  IBusRepository : IBaseRepository<Bus>
    {
        Task<Bus> GetByPlacaAsync(string placa);
        Task<IEnumerable<Bus>> GetByActivosAsync();

    }
}
