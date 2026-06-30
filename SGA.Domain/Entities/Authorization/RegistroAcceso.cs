using SGA.Domain.Base;

namespace SGA.Domain.Entities.Authorization
{
    public class RegistroAcceso : AuditEntity
    {
        public int ViajeId { get; set; }
        public int UsuarioId { get; set; }
        public int AutorizacionId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }
        public bool Resultado { get; set; }
    }
}
