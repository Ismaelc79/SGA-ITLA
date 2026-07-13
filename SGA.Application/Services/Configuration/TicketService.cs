using SGA.Application.DTOs.Ticket;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Base;
using SGA.Persistence.Interfaces.Autorizations;

namespace SGA.Application.Services.Configuration
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<OperationResult<IEnumerable<TicketDto>>> GetAllAsync()
        {
            var ticket = await _ticketRepository.GetAllAsync();

            return new OperationResult<IEnumerable<TicketDto>>()
            {
                Success = true,
                Message = "Tickets obtenidos exitosamente",
                Data = ticket.Select(MapToDto)
            };

        }
        public async Task<OperationResult<TicketDto>> GetByIdAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);

            if (ticket == null)
            {
                return new OperationResult<TicketDto>
                {
                    Success = false,
                    Message = $"No se encontró un ticket con ID '{id}'.",
                    Errors = new List<string> { "Ticket no encontrado" }
                };
            }
            return new OperationResult<TicketDto>
            {
                Success = true,
                Message = "Ticket encontrado exitosamente",
                Data = MapToDto(ticket)
            };

        }
        public async Task<OperationResult<TicketDto>> CreateAsync(CreateTicketDto dto)
        {
            var ticket = new Domain.Entities.Authorization.Ticket
            {
                EstudianteId = dto.EstudianteId,
                RutaId = dto.RutaId,
                ParadaId = dto.ParadaId,
                PagoId = dto.PagoId,
                Tipo = dto.Tipo,
                EstadoTicket = dto.EstadoTicket,
                FechaInicio = dto.FechaInicio,
                FechaCierre = dto.FechaCierre,
            };

            await _ticketRepository.AddAsync(ticket);

            return new OperationResult<TicketDto>
            {
                Success = true,
                Message = "Ticket creado exitosamente",
                Data = MapToDto(ticket)
            };
        }

        public async Task<OperationResult<TicketDto>> UpdateAsync(int id, UpdateTicketDto dto)
        {
            var ticketExistente = await _ticketRepository.GetByIdAsync(id);

            if (ticketExistente == null)
            {
                return new OperationResult<TicketDto>
                {
                    Success = false,
                    Message = $"No se encontró un ticket con ID '{id}'.",
                    Errors = new List<string> { "Ticket no encontrado" }
                };
            }

            ticketExistente.EstudianteId = dto.Id;
            ticketExistente.RutaId = dto.RutaId;
            ticketExistente.ParadaId = dto.ParadaId;
            ticketExistente.PagoId = dto.PagoId;
            ticketExistente.Tipo = dto.Tipo;
            ticketExistente.EstadoTicket = dto.EstadoTicket;
            ticketExistente.FechaInicio = dto.FechaInicio;
            ticketExistente.FechaCierre = dto.FechaCierre;

            await _ticketRepository.UpdateAsync(ticketExistente);

            return new OperationResult<TicketDto>
            {
                Success = true,
                Message = "Ticket actualizado exitosamente",
                Data = MapToDto(ticketExistente)
            };
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            var ticketExistente = await _ticketRepository.GetByIdAsync(id);

            if(ticketExistente == null)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"No se encontró un ticket con ID '{id}'.",
                    Errors = new List<string> {"Ticket no encontrado"}
                };
            }

            await _ticketRepository.DeleteAsync(ticketExistente);

            return new OperationResult<bool>
            {
                Success = true,
                Message = "Ticket eliminado exitosamente",
                Data = true
            };
        }

        private TicketDto MapToDto (Domain.Entities.Authorization.Ticket ticket)
        {
            return new TicketDto
            {
                Id = ticket.Id,
                EstudianteId = ticket.EstudianteId,
                RutaId = ticket.RutaId,
                ParadaId = ticket.ParadaId,
                PagoId = ticket.PagoId,
                Tipo  = ticket.Tipo,
                EstadoTicket = ticket.EstadoTicket,
                FechaInicio = ticket.FechaInicio,
                FechaCierre = ticket.FechaCierre,
            };

        }
        
    }
}
