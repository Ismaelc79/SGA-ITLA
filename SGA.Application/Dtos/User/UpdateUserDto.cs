using System.ComponentModel.DataAnnotations;

namespace SGA.Application.Dtos.User
{
    public class UpdateUserDto : SaveUserDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "El ID del usuario es obligatorio.")]
        public int Id { get; set; }
    }
}