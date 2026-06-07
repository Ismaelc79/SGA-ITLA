using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Domain.Entities.Trip
{
    public class Viaje
    {
        public int Id { get; set; }

        public DateTime FechaSalida { get; set; }

        public int BusId { get; set; }
    }
}
