using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.DTOs
{
    public class UsuarioRegisterDto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
