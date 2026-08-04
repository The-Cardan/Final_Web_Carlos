using Final_Web_Carlos.Data;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Carlos.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> ObtenerTodosAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente?> ObtenerPorIdAsync(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task<Paciente?> ObtenerPorCedulaAsync(string cedula)
        {
            return await _context.Pacientes
                .FirstOrDefaultAsync(p => p.Cedula == cedula);
        }

        public async Task<Paciente> CrearAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);

            await _context.SaveChangesAsync();

            return paciente;
        }

        public async Task<Paciente> ActualizarAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);

            await _context.SaveChangesAsync();

            return paciente;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
                return false;

            _context.Pacientes.Remove(paciente);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
