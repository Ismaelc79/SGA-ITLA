using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Users
{
    public class Estudiante : AuditEntity
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Carrera { get; set; }
        public string PeriodoAcademico { get; set; }

    }
}
