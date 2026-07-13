
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Ruta
{
    public class UpdateRutaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public EstadoRuta EstadoRuta { get; set; }
        public string RutaOrigen { get; set; }
        public string RutaDestino { get; set; }
    }
}
