using SGA.Domain.Base;
namespace SGA.Domain.Entities.Authorization
{
    public class Autorizacion : AuditEntity
    {
        public int AutorizacionId { get; set; }
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }

    }
}
