using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Interfaces
{
    public interface IEspecialidadRepository
    {
        Task<List<Especialidad>> ObtenerTodasAsync();

        Task<Especialidad?> ObtenerPorIdAsync(int id);

        Task<Especialidad?> ObtenerPorNombreAsync(string nombre);

        Task<Especialidad> CrearAsync(Especialidad especialidad);

        Task<Especialidad> ActualizarAsync(Especialidad especialidad);

        Task<bool> EliminarAsync(int id);
    }
}