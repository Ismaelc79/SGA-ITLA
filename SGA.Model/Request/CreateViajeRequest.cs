using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Model.Request
{
    public class CreateViajeRequest
    {
        public DateTime FechaSalida { get; set; }

        public int BusId { get; set; }
    }
}
