using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Interfaces
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> ObtenerTodosAsync();

        Task<Servicio?> ObtenerPorIdAsync(int id);

        Task<Servicio?> ObtenerPorNombreAsync(string nombre);

        Task<Servicio> CrearAsync(Servicio servicio);

        Task<Servicio> ActualizarAsync(Servicio servicio);

        Task<bool> EliminarAsync(int id);
    }
}