using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.DTOs
{
    public class PacienteCreateDto
    {
        [Required]
        [StringLength(120)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Telefono { get; set; } = string.Empty;

        [EmailAddress]
        public string? Correo { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
}