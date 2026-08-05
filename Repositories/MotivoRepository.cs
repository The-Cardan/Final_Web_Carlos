using Final_Web_Carlos.Data;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Carlos.Repositories
{
    public class MotivoRepository : IMotivoRepository
    {
        private readonly ApplicationDbContext _context;

        public MotivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Motivo>> ObtenerTodosAsync()
        {
            return await _context.Motivos.ToListAsync();
        }

        public async Task<Motivo?> ObtenerPorIdAsync(int id)
        {
            return await _context.Motivos.FindAsync(id);
        }

        public async Task<Motivo?> ObtenerPorDescripcionAsync(string descripcion)
        {
            return await _context.Motivos
                .FirstOrDefaultAsync(m => m.Descripcion == descripcion);
        }

        public async Task<Motivo> CrearAsync(Motivo motivo)
        {
            _context.Motivos.Add(motivo);
            await _context.SaveChangesAsync();
            return motivo;
        }

        public async Task<Motivo> ActualizarAsync(Motivo motivo)
        {
            _context.Motivos.Update(motivo);
            await _context.SaveChangesAsync();
            return motivo;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var motivo = await _context.Motivos.FindAsync(id);

            if (motivo == null)
                return false;

            _context.Motivos.Remove(motivo);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}