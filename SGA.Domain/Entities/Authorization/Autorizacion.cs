using SGA.Domain.Base;
using SGA.Domain.Enums;
namespace SGA.Domain.Entities.Authorization
{
    public class Autorizacion : AuditEntity
    {
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public EstadoAutorizacion EstadoAutorizacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }

    }
}
