using Final_Web_Carlos.DTOs;

namespace Final_Web_Carlos.Interfaces
{
    public interface IEspecialidadService
    {
        Task<List<EspecialidadResponseDto>> ObtenerTodasAsync();

        Task<EspecialidadResponseDto?> ObtenerPorIdAsync(int id);

        Task<EspecialidadResponseDto> CrearAsync(EspecialidadCreateDto dto);

        Task<EspecialidadResponseDto?> ActualizarAsync(int id, EspecialidadUpdateDto dto);

        Task<bool> EliminarAsync(int id);
    }
}