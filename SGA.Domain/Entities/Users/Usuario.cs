using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Domain.Entities.Users
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
