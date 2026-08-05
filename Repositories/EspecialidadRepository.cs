using Final_Web_Carlos.Data;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Carlos.Repositories
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Especialidad>> ObtenerTodasAsync()
        {
            return await _context.Especialidades.ToListAsync();
        }

        public async Task<Especialidad?> ObtenerPorIdAsync(int id)
        {
            return await _context.Especialidades.FindAsync(id);
        }

        public async Task<Especialidad?> ObtenerPorNombreAsync(string nombre)
        {
            return await _context.Especialidades
                .FirstOrDefaultAsync(e => e.Nombre == nombre);
        }

        public async Task<Especialidad> CrearAsync(Especialidad especialidad)
        {
            _context.Especialidades.Add(especialidad);
            await _context.SaveChangesAsync();
            return especialidad;
        }

        public async Task<Especialidad> ActualizarAsync(Especialidad especialidad)
        {
            _context.Especialidades.Update(especialidad);
            await _context.SaveChangesAsync();
            return especialidad;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var especialidad = await _context.Especialidades.FindAsync(id);

            if (especialidad == null)
                return false;

            _context.Especialidades.Remove(especialidad);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
