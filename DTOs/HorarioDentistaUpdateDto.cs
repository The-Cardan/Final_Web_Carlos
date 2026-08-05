using System.ComponentModel.DataAnnotations;
using Final_Web_Carlos.Models.Enums;

namespace Final_Web_Carlos.DTOs
{
    public class HorarioDentistaUpdateDto
    {
        [Required]
        public DiaSemana Dia { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }
    }
}