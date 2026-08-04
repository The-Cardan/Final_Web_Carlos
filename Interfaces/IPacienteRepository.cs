using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Interfaces
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> ObtenerTodosAsync();

        Task<Paciente?> ObtenerPorIdAsync(int id);

        Task<Paciente?> ObtenerPorCedulaAsync(string cedula);

        Task<Paciente> CrearAsync(Paciente paciente);

        Task<Paciente> ActualizarAsync(Paciente paciente);

        Task<bool> EliminarAsync(int id);
    }
}