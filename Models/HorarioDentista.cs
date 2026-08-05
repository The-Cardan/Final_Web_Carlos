
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Final_Web_Carlos.Models.Enums;

namespace Final_Web_Carlos.Models
{
    public class HorarioDentista
    {
        [Key]
        public int Id { get; set; }

        public int DentistaId { get; set; }

        [ForeignKey("DentistaId")]
        public Dentista? Dentista { get; set; }

        [Required]
        public DiaSemana Dia { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }
    }
}