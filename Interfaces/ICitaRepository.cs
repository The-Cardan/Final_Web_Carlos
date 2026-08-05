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

        // Verifica si el dentista ya tiene una cita en esa fecha y hora
        Task<bool> ExisteCitaAsync(int dentistaId, DateTime fecha, TimeSpan hora);

        // Obtiene todas las citas de un dentista
        Task<List<Cita>> ObtenerPorDentistaAsync(int dentistaId);
    }
}