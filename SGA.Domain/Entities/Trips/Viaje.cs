using SGA.Domain.Base;
using SGA.Domain.Entities.Authorization;
using SGA.Domain.Entities.Configuration;
using SGA.Domain.Entities.Users;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Trip
{
    public class Viaje : AuditEntity
    {
        public int RutaId { get; set; }
        public Ruta Ruta { get; set; }
        public int AutobusId { get; set; }
        public Bus Autobus { get; set; }
        public int ConductorId { get; set; }
        public Conductor Conductor { get; set; }
        public int HorarioId { get; set; }
        public Horario Horario { get; set; }
        public int IncidenciaId { get; set; }
        public Incidencia Incidencia { get; set; }
        public EstadoViaje EstadoViaje { get; set; }
        public DateTime? HoraSalidaEstimada { get; set; }
        public DateTime? HoraLlegadaEstimada { get; set; }
        public ICollection<RegistroAcceso> RegistrosAcceso { get; set; } = new List<RegistroAcceso>();

    }
}
