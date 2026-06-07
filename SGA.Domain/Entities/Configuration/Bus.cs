using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Domain.Entities.Configuration
{
    public class Bus
    {
        public int Id { get; set; }

        public string Placa { get; set; } = string.Empty;

        public int Capacidad { get; set; }
    }
}
