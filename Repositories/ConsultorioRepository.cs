using Final_Web_Carlos.Data;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Carlos.Repositories
{
    public class ConsultorioRepository : IConsultorioRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsultorioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Consultorio>> ObtenerTodosAsync()
        {
            return await _context.Consultorios.ToListAsync();
        }

        public async Task<Consultorio?> ObtenerPorIdAsync(int id)
        {
            return await _context.Consultorios.FindAsync(id);
        }

        public async Task<Consultorio?> ObtenerPorNombreAsync(string nombre)
        {
            return await _context.Consultorios
                .FirstOrDefaultAsync(c => c.Nombre == nombre);
        }

        public async Task<Consultorio> CrearAsync(Consultorio consultorio)
        {
            _context.Consultorios.Add(consultorio);
            await _context.SaveChangesAsync();
            return consultorio;
        }

        public async Task<Consultorio> ActualizarAsync(Consultorio consultorio)
        {
            _context.Consultorios.Update(consultorio);
            await _context.SaveChangesAsync();
            return consultorio;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var consultorio = await _context.Consultorios.FindAsync(id);

            if (consultorio == null)
                return false;

            _context.Consultorios.Remove(consultorio);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}