using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Interfaces
{
    public interface IDentistaRepository
    {
        Task<List<Dentista>> ObtenerTodosAsync();

        Task<Dentista?> ObtenerPorIdAsync(int id);

        Task<Dentista> CrearAsync(Dentista dentista);

        Task<Dentista> ActualizarAsync(Dentista dentista);

        Task<bool> EliminarAsync(int id);
    }
}