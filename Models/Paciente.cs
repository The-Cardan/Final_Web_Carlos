using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Telefono { get; set; } = string.Empty;

        [EmailAddress]
        public string? Correo { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}