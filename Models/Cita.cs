using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Web_Carlos.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente? Paciente { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Hora { get; set; }

        [Required]
        public int Duracion { get; set; }

        [Required]
        public int DentistaId { get; set; }

        [ForeignKey("DentistaId")]
        public Dentista? Dentista { get; set; }

        [Required]
        public int MotivoId { get; set; }

        [ForeignKey("MotivoId")]
        public Motivo? Motivo { get; set; }

        [Required]
        public int ServicioId { get; set; }

        [ForeignKey("ServicioId")]
        public Servicio? Servicio { get; set; }

        [Required]
        public int ConsultorioId { get; set; }

        [ForeignKey("ConsultorioId")]
        public Consultorio? Consultorio { get; set; }

        // Estos valores se calcularán automáticamente más adelante.
        public string Estado { get; set; } = string.Empty;

        public string DiasHorasRestantes { get; set; } = string.Empty;
    }
}
