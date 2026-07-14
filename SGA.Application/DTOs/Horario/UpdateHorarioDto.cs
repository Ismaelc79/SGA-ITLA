using SGA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Application.DTOs.Horario
{
    public class UpdateHorarioDto
    {
        public int RutaId { get; set; }
        public DiasOperacion DiasOperacion { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
    }
}
