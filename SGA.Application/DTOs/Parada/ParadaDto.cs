
namespace SGA.Application.DTOs.Parada
{
    public class ParadaDto
    {
        
        public int Id { get; set; }
        public int RutaId { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string OrdenParada { get; set; } 
        public string Estado { get; set; }
    }
}
