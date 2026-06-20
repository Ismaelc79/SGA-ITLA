using SGA.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Domain.Entities.Trip
{
    public class Viaje : AuditEntity
    {
        public int ViajeId { get; set; }
        public int RutaId { get; set; }
        public int AutobusId { get; set; }
        public int ConductorId { get; set; }
        public int HorarioId { get; set; }
        public string Estado { get; set; }
        public DateTime? HoraSalidaEstimada { get; set; }
        public DateTime? HoraLlegadaEstimada { get; set; }
        
    }
}
