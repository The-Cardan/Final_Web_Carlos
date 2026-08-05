using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Interfaces
{
    public interface IMotivoRepository
    {
        Task<List<Motivo>> ObtenerTodosAsync();

        Task<Motivo?> ObtenerPorIdAsync(int id);

        Task<Motivo?> ObtenerPorDescripcionAsync(string descripcion);

        Task<Motivo> CrearAsync(Motivo motivo);

        Task<Motivo> ActualizarAsync(Motivo motivo);

        Task<bool> EliminarAsync(int id);
    }
}