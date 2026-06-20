using SGA.Domain.Base;

namespace SGA.Domain.Entities.Users
{
    public class Estudiante : AuditEntity
    {
        public int EstudianteId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }
        public string PeriodoAcademico { get; set; }
        public string Estado { get; set; }

    }
}
