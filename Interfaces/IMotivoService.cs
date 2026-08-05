using Final_Web_Carlos.DTOs;

namespace Final_Web_Carlos.Interfaces
{
    public interface IMotivoService
    {
        Task<List<MotivoResponseDto>> ObtenerTodosAsync();

        Task<MotivoResponseDto?> ObtenerPorIdAsync(int id);

        Task<MotivoResponseDto> CrearAsync(MotivoCreateDto dto);

        Task<MotivoResponseDto?> ActualizarAsync(int id, MotivoUpdateDto dto);

        Task<bool> EliminarAsync(int id);
    }
}