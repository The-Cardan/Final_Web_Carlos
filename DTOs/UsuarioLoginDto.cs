using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.DTOs
{
    public class UsuarioLoginDto
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
