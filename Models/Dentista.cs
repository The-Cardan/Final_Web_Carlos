using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Web_Carlos.Models
{
    public class Dentista
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Phone]
        public string Telefono { get; set; } = string.Empty;

        [EmailAddress]
        public string? Correo { get; set; }

        // Foreign Key
        public int EspecialidadId { get; set; }

        [ForeignKey("EspecialidadId")]
        public Especialidad? Especialidad { get; set; }

        public ICollection<Cita>? Citas { get; set; }

        public ICollection<HorarioDentista>? Horarios { get; set; }
    }
}