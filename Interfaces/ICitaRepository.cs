using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Interfaces
{
    public interface ICitaRepository
    {
        Task<List<Cita>> ObtenerTodasAsync();

        Task<Cita?> ObtenerPorIdAsync(int id);

        Task<Cita> CrearAsync(Cita cita);

        Task<Cita> ActualizarAsync(Cita cita);

        Task<bool> EliminarAsync(int id);
    }
}