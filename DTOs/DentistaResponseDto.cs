namespace Final_Web_Carlos.DTOs
{
    public class DentistaResponseDto
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string? Correo { get; set; }

        public int EspecialidadId { get; set; }

        public string Especialidad { get; set; } = string.Empty;
    }
}
