using Final_Web_Carlos.Data;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Carlos.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly ApplicationDbContext _context;

        public CitaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cita>> ObtenerTodasAsync()
        {
            return await _context.Citas

                .Include(c => c.Paciente)

                .Include(c => c.Dentista)
                    .ThenInclude(d => d.Especialidad)

                .Include(c => c.Motivo)

                .Include(c => c.Servicio)

                .Include(c => c.Consultorio)

                .ToListAsync();
        }

        public async Task<Cita?> ObtenerPorIdAsync(int id)
        {
            return await _context.Citas

                .Include(c => c.Paciente)

                .Include(c => c.Dentista)
                    .ThenInclude(d => d.Especialidad)

                .Include(c => c.Motivo)

                .Include(c => c.Servicio)

                .Include(c => c.Consultorio)

                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cita> CrearAsync(Cita cita)
        {
            _context.Citas.Add(cita);

            await _context.SaveChangesAsync();

            return cita;
        }

        public async Task<Cita> ActualizarAsync(Cita cita)
        {
            _context.Citas.Update(cita);

            await _context.SaveChangesAsync();

            return cita;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var cita = await _context.Citas.FindAsync(id);

            if (cita == null)
                return false;

            _context.Citas.Remove(cita);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExisteCitaAsync(int dentistaId, DateTime fecha, TimeSpan hora)
        {
            return await _context.Citas.AnyAsync(c =>
                c.DentistaId == dentistaId &&
                c.Fecha.Date == fecha.Date &&
                c.Hora == hora);
        }

        public async Task<List<Cita>> ObtenerPorDentistaAsync(int dentistaId)
        {
            return await _context.Citas
                .Where(c => c.DentistaId == dentistaId)
                .ToListAsync();
        }
    }
}