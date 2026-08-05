using System.ComponentModel.DataAnnotations;


namespace Final_Web_Carlos.DTOs
{
    public class HorarioDentistaCreateDto
    {
        [Required]
        public int DentistaId { get; set; }

        [Required]
        public DayOfWeek Dia { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }
    }
}
