using SGA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Application.DTOs.TarjetaRecargable
{
    public class TarjetaRecargableDto
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int PagoId { get; set; }
        public double MontoTarjeta { get; set; }
        public EstadoTarjeta EstadoTarjeta { get; set; }
        public DateTime FechaVigenteInicio { get; set; }
        public DateTime FechaVigenteFin { get; set; }
    }
}
