using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.DTOs
{
    public class UsuarioUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; } = string.Empty;

        [MinLength(6)]
        public string? Password { get; set; }
    }
}