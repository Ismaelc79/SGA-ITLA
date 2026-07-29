using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Horario
{
    public class CreateHorarioDto
    {
        public int Id { get; set; }
        public int RutaId { get; set; }
        public DiasOperacion DiasOperacion { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
    }
}
