using SGA.Domain.Base;
using SGA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Domain.Entities.Users
{
    public class Usuario : AuditEntity
    {
        public int RolId { get; set; }
        public string Nombre { get; set; } 
        public string Email { get; set; } 
        public string PasswordHash { get; set; }
        public EstadoUsuario Estado { get; set; }
        public bool EstaRestringido { get; set; }

    }
}
