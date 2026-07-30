using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Authorization
{
    public class AutorizacionDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public EstadoAutorizacion Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
    }
}