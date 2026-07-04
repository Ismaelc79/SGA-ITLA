using SGA.Application.Exceptions;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Entities.Configuration;
using SGA.Domain.Enums;
using SGA.Persistence.Interfaces.Trips;

namespace SGA.Application.Rules.Configuration
{
    public class BusBusinessRules
    {
        private readonly IBusRepository _busRepository;

        public BusBusinessRules(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task ValidarPlacaUnicaAsync(string placa, int? idAExcluir = null)
        {
            var existente = await _busRepository.GetByPlacaAsync(placa.Trim());
            if (existente is not null && existente.Id != idAExcluir)
            {
                throw new DuplicateResourceException(
                    $"Un autobús con la placa: '{placa}' ya existe.");
            }
        }

        public void ValidarTransicionEstado(EstadoBus estadoActual, EstadoBus nuevoEstado)
        {
            if (estadoActual == nuevoEstado)
            {
                throw new BusinessRuleException(
                    $"El autobús ya se encuentra en estado '{nuevoEstado}'.");
                   
            }
        }

        public async Task ObtenerExistenteAsync(int id)
        {
            var bus = await _busRepository.GetByIdAsync(id);
            if (bus is null)
            {
                throw new NotFoundException("Autobús", id);
            }
        }
    }
}
