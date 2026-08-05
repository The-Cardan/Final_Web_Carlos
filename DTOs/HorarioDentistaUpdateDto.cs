using System.ComponentModel.DataAnnotations;


namespace Final_Web_Carlos.DTOs
{
    public class HorarioDentistaUpdateDto
    {
        [Required]
        public DayOfWeek Dia { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }
    }
}