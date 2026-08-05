using Final_Web_Carlos.DTOs;

namespace Final_Web_Carlos.Interfaces
{
    public interface IConsultorioService
    {
        Task<List<ConsultorioResponseDto>> ObtenerTodosAsync();

        Task<ConsultorioResponseDto?> ObtenerPorIdAsync(int id);

        Task<ConsultorioResponseDto> CrearAsync(ConsultorioCreateDto dto);

        Task<ConsultorioResponseDto?> ActualizarAsync(int id, ConsultorioUpdateDto dto);

        Task<bool> EliminarAsync(int id);
    }
}