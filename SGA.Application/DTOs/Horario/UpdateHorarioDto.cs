using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Application.DTOs.Horario
{
    public class UpdateHorarioDto
    {
        public int RutaId { get; set; }
        public string DiasOperacion { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }
}
