using Final_Web_Carlos.DTOs;

namespace Final_Web_Carlos.Interfaces
{
    public interface IDentistaService
    {
        Task<List<DentistaResponseDto>> ObtenerTodosAsync();

        Task<DentistaResponseDto?> ObtenerPorIdAsync(int id);

        Task<DentistaResponseDto> CrearAsync(DentistaCreateDto dto);

        Task<DentistaResponseDto?> ActualizarAsync(int id, DentistaUpdateDto dto);

        Task<bool> EliminarAsync(int id);
    }
}