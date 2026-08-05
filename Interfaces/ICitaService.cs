using Final_Web_Carlos.DTOs;

namespace Final_Web_Carlos.Interfaces
{
    public interface ICitaService
    {
        Task<List<CitaResponseDto>> ObtenerTodasAsync();

        Task<CitaResponseDto?> ObtenerPorIdAsync(int id);

        Task<CitaResponseDto> CrearAsync(CitaCreateDto dto);

        Task<CitaResponseDto?> ActualizarAsync(int id, CitaUpdateDto dto);

        Task<bool> EliminarAsync(int id);
    }
}