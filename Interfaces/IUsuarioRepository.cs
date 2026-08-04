using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObtenerPorCorreoAsync(string correo);

        Task<Usuario?> ObtenerPorIdAsync(int id);

        Task<List<Usuario>> ObtenerTodosAsync();

        Task<Usuario> CrearAsync(Usuario usuario);

        Task<Usuario> ActualizarAsync(Usuario usuario);

        Task<bool> EliminarAsync(int id);

        Task<bool> ExisteCorreoAsync(string correo);
    }
}
