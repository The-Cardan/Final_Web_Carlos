using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.DTOs
{
    public class DentistaUpdateDto
    {
        [Required]
        [StringLength(120)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required]
        public string Telefono { get; set; } = string.Empty;

        public string? Correo { get; set; }

        [Required]
        public int EspecialidadId { get; set; }
    }
}