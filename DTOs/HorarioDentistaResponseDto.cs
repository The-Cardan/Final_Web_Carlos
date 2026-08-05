namespace Final_Web_Carlos.DTOs
{
    public class HorarioDentistaResponseDto
    {
        public int Id { get; set; }

        public int DentistaId { get; set; }

        public string Dentista { get; set; } = string.Empty;

        public DayOfWeek Dia { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin { get; set; }
    }
}