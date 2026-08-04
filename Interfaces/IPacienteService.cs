using Final_Web_Carlos.DTOs;

namespace Final_Web_Carlos.Interfaces
{
    public interface IPacienteService
    {
        Task<List<PacienteResponseDto>> ObtenerTodosAsync();

        Task<PacienteResponseDto?> ObtenerPorIdAsync(int id);

        Task<PacienteResponseDto> CrearAsync(PacienteCreateDto dto);

        Task<PacienteResponseDto?> ActualizarAsync(int id, PacienteUpdateDto dto);

        Task<bool> EliminarAsync(int id);
    }
}
