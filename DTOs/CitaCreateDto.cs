using System.ComponentModel.DataAnnotations;

namespace Final_Web_Carlos.DTOs
{
    public class CitaCreateDto
    {
        [Required]
        public int PacienteId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Hora { get; set; }

        [Required]
        [Range(1, 480)]
        public int Duracion { get; set; }

        [Required]
        public int DentistaId { get; set; }

        [Required]
        public int MotivoId { get; set; }

        [Required]
        public int ServicioId { get; set; }

        [Required]
        public int ConsultorioId { get; set; }
    }
}