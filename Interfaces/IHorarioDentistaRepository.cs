using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Interfaces
{
    public interface IHorarioDentistaRepository
    {
        Task<List<HorarioDentista>> ObtenerTodosAsync();

        Task<HorarioDentista?> ObtenerPorIdAsync(int id);

        Task<HorarioDentista> CrearAsync(HorarioDentista horario);

        Task<HorarioDentista> ActualizarAsync(HorarioDentista horario);

        Task<bool> EliminarAsync(int id);
    }
}
