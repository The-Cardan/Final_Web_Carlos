using Final_Web_Carlos.Data;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Carlos.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly ApplicationDbContext _context;

        public ServicioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> ObtenerTodosAsync()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<Servicio?> ObtenerPorIdAsync(int id)
        {
            return await _context.Servicios.FindAsync(id);
        }

        public async Task<Servicio?> ObtenerPorNombreAsync(string nombre)
        {
            return await _context.Servicios
                .FirstOrDefaultAsync(s => s.Nombre == nombre);
        }

        public async Task<Servicio> CrearAsync(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }

        public async Task<Servicio> ActualizarAsync(Servicio servicio)
        {
            _context.Servicios.Update(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio == null)
                return false;

            _context.Servicios.Remove(servicio);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}