namespace Final_Web_Carlos.DTOs
{
    public class PacienteResponseDto
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public string Cedula { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string? Correo { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}
