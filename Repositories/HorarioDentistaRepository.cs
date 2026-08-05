using Final_Web_Carlos.Data;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Carlos.Repositories
{
    public class HorarioDentistaRepository : IHorarioDentistaRepository
    {
        private readonly ApplicationDbContext _context;

        public HorarioDentistaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HorarioDentista>> ObtenerTodosAsync()
        {
            return await _context.HorariosDentistas
                .Include(h => h.Dentista)
                .ToListAsync();
        }

        public async Task<HorarioDentista?> ObtenerPorIdAsync(int id)
        {
            return await _context.HorariosDentistas
                .Include(h => h.Dentista)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<HorarioDentista> CrearAsync(HorarioDentista horario)
        {
            _context.HorariosDentistas.Add(horario);
            await _context.SaveChangesAsync();
            return horario;
        }

        public async Task<HorarioDentista> ActualizarAsync(HorarioDentista horario)
        {
            _context.HorariosDentistas.Update(horario);
            await _context.SaveChangesAsync();
            return horario;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var horario = await _context.HorariosDentistas.FindAsync(id);

            if (horario == null)
                return false;

            _context.HorariosDentistas.Remove(horario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}