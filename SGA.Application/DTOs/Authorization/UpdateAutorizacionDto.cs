namespace SGA.Application.DTOs.Authorization
{
    public class UpdateAutorizacionDto
    {
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
    }
}
