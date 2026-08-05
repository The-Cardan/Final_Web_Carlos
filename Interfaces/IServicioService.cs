using Final_Web_Carlos.DTOs;

namespace Final_Web_Carlos.Interfaces
{
    public interface IServicioService
    {
        Task<List<ServicioResponseDto>> ObtenerTodosAsync();

        Task<ServicioResponseDto?> ObtenerPorIdAsync(int id);

        Task<ServicioResponseDto> CrearAsync(ServicioCreateDto dto);

        Task<ServicioResponseDto?> ActualizarAsync(int id, ServicioUpdateDto dto);

        Task<bool> EliminarAsync(int id);
    }
}