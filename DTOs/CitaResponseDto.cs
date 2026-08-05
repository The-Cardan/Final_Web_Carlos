namespace Final_Web_Carlos.DTOs
{
    public class CitaResponseDto
    {
        public int Id { get; set; }

        public string Paciente { get; set; } = string.Empty;

        public string Dentista { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

        public string Motivo { get; set; } = string.Empty;

        public string Servicio { get; set; } = string.Empty;

        public string Consultorio { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        public int Duracion { get; set; }

        public string Estado { get; set; } = string.Empty;

        public string DiasHorasRestantes { get; set; } = string.Empty;
    }
}