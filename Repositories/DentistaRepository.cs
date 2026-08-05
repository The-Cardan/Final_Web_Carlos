using Final_Web_Carlos.Data;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Carlos.Repositories
{
    public class DentistaRepository : IDentistaRepository
    {
        private readonly ApplicationDbContext _context;

        public DentistaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Dentista>> ObtenerTodosAsync()
        {
            return await _context.Dentistas
                .Include(d => d.Especialidad)
                .ToListAsync();
        }

        public async Task<Dentista?> ObtenerPorIdAsync(int id)
        {
            return await _context.Dentistas
                .Include(d => d.Especialidad)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Dentista> CrearAsync(Dentista dentista)
        {
            _context.Dentistas.Add(dentista);
            await _context.SaveChangesAsync();
            return dentista;
        }

        public async Task<Dentista> ActualizarAsync(Dentista dentista)
        {
            _context.Dentistas.Update(dentista);
            await _context.SaveChangesAsync();
            return dentista;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var dentista = await _context.Dentistas.FindAsync(id);

            if (dentista == null)
                return false;

            _context.Dentistas.Remove(dentista);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}