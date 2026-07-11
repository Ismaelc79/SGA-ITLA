namespace SGA.Application.Dtos.Authorization
{
    public class SaveAutorizacionDto
    {
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
    }
}