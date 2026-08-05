using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;

        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ServicioResponseDto>> ObtenerTodosAsync()
        {
            var lista = await _repository.ObtenerTodosAsync();

            return lista.Select(s => new ServicioResponseDto
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Precio = s.Precio
            }).ToList();
        }

        public async Task<ServicioResponseDto?> ObtenerPorIdAsync(int id)
        {
            var servicio = await _repository.ObtenerPorIdAsync(id);

            if (servicio == null)
                return null;

            return new ServicioResponseDto
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Precio = servicio.Precio
            };
        }

        public async Task<ServicioResponseDto> CrearAsync(ServicioCreateDto dto)
        {
            var existe = await _repository.ObtenerPorNombreAsync(dto.Nombre);

            if (existe != null)
                throw new Exception("El servicio ya existe.");

            var servicio = new Servicio
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio
            };

            servicio = await _repository.CrearAsync(servicio);

            return new ServicioResponseDto
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Precio = servicio.Precio
            };
        }

        public async Task<ServicioResponseDto?> ActualizarAsync(int id, ServicioUpdateDto dto)
        {
            var servicio = await _repository.ObtenerPorIdAsync(id);

            if (servicio == null)
                return null;

            servicio.Nombre = dto.Nombre;
            servicio.Precio = dto.Precio;

            await _repository.ActualizarAsync(servicio);

            return new ServicioResponseDto
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Precio = servicio.Precio
            };
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repository.EliminarAsync(id);
        }
    }
}