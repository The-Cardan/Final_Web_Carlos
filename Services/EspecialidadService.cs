using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Services
{
    public class EspecialidadService : IEspecialidadService
    {
        private readonly IEspecialidadRepository _repository;

        public EspecialidadService(IEspecialidadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EspecialidadResponseDto>> ObtenerTodasAsync()
        {
            var lista = await _repository.ObtenerTodasAsync();

            return lista.Select(e => new EspecialidadResponseDto
            {
                Id = e.Id,
                Nombre = e.Nombre
            }).ToList();
        }

        public async Task<EspecialidadResponseDto?> ObtenerPorIdAsync(int id)
        {
            var especialidad = await _repository.ObtenerPorIdAsync(id);

            if (especialidad == null)
                return null;

            return new EspecialidadResponseDto
            {
                Id = especialidad.Id,
                Nombre = especialidad.Nombre
            };
        }

        public async Task<EspecialidadResponseDto> CrearAsync(EspecialidadCreateDto dto)
        {
            var existe = await _repository.ObtenerPorNombreAsync(dto.Nombre);

            if (existe != null)
                throw new Exception("La especialidad ya existe.");

            var especialidad = new Especialidad
            {
                Nombre = dto.Nombre
            };

            especialidad = await _repository.CrearAsync(especialidad);

            return new EspecialidadResponseDto
            {
                Id = especialidad.Id,
                Nombre = especialidad.Nombre
            };
        }

        public async Task<EspecialidadResponseDto?> ActualizarAsync(int id, EspecialidadUpdateDto dto)
        {
            var especialidad = await _repository.ObtenerPorIdAsync(id);

            if (especialidad == null)
                return null;

            especialidad.Nombre = dto.Nombre;

            especialidad = await _repository.ActualizarAsync(especialidad);

            return new EspecialidadResponseDto
            {
                Id = especialidad.Id,
                Nombre = especialidad.Nombre
            };
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repository.EliminarAsync(id);
        }
    }
}