using System.ComponentModel.DataAnnotations;
using Final_Web_Carlos.Models.Enums;

namespace Final_Web_Carlos.DTOs
{
    public class HorarioDentistaCreateDto
    {
        [Required]
        public int DentistaId { get; set; }

        [Required]
        public DiaSemana Dia { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }
    }
}
