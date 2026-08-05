using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Interfaces
{
    public interface IConsultorioRepository
    {
        Task<List<Consultorio>> ObtenerTodosAsync();

        Task<Consultorio?> ObtenerPorIdAsync(int id);

        Task<Consultorio?> ObtenerPorNombreAsync(string nombre);

        Task<Consultorio> CrearAsync(Consultorio consultorio);

        Task<Consultorio> ActualizarAsync(Consultorio consultorio);

        Task<bool> EliminarAsync(int id);
    }
}