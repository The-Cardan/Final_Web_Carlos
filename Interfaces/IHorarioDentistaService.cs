using Final_Web_Carlos.DTOs;

namespace Final_Web_Carlos.Interfaces
{
    public interface IHorarioDentistaService
    {
        Task<List<HorarioDentistaResponseDto>> ObtenerTodosAsync();

        Task<HorarioDentistaResponseDto?> ObtenerPorIdAsync(int id);

        Task<HorarioDentistaResponseDto> CrearAsync(HorarioDentistaCreateDto dto);

        Task<HorarioDentistaResponseDto?> ActualizarAsync(int id, HorarioDentistaUpdateDto dto);

        Task<bool> EliminarAsync(int id);
    }
}