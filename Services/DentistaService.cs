using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Services
{
    public class DentistaService : IDentistaService
    {
        private readonly IDentistaRepository _repository;
        private readonly IEspecialidadRepository _especialidadRepository;

        public DentistaService(
            IDentistaRepository repository,
            IEspecialidadRepository especialidadRepository)
        {
            _repository = repository;
            _especialidadRepository = especialidadRepository;
        }

        public async Task<List<DentistaResponseDto>> ObtenerTodosAsync()
        {
            var lista = await _repository.ObtenerTodosAsync();

            return lista.Select(d => new DentistaResponseDto
            {
                Id = d.Id,
                NombreCompleto = d.NombreCompleto,
                Telefono = d.Telefono,
                Correo = d.Correo,
                EspecialidadId = d.EspecialidadId,
                Especialidad = d.Especialidad.Nombre
            }).ToList();
        }

        public async Task<DentistaResponseDto?> ObtenerPorIdAsync(int id)
        {
            var dentista = await _repository.ObtenerPorIdAsync(id);

            if (dentista == null)
                return null;

            return new DentistaResponseDto
            {
                Id = dentista.Id,
                NombreCompleto = dentista.NombreCompleto,
                Telefono = dentista.Telefono,
                Correo = dentista.Correo,
                EspecialidadId = dentista.EspecialidadId,
                Especialidad = dentista.Especialidad.Nombre
            };
        }

        public async Task<DentistaResponseDto> CrearAsync(DentistaCreateDto dto)
        {
            var especialidad =
                await _especialidadRepository.ObtenerPorIdAsync(dto.EspecialidadId);

            if (especialidad == null)
                throw new Exception("La especialidad indicada no existe.");

            var dentista = new Dentista
            {
                NombreCompleto = dto.NombreCompleto,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                EspecialidadId = dto.EspecialidadId
            };

            dentista = await _repository.CrearAsync(dentista);

            return await ObtenerPorIdAsync(dentista.Id)
                ?? throw new Exception("Error al crear el dentista.");
        }

        public async Task<DentistaResponseDto?> ActualizarAsync(int id, DentistaUpdateDto dto)
        {
            var dentista = await _repository.ObtenerPorIdAsync(id);

            if (dentista == null)
                return null;

            var especialidad =
                await _especialidadRepository.ObtenerPorIdAsync(dto.EspecialidadId);

            if (especialidad == null)
                throw new Exception("La especialidad indicada no existe.");

            dentista.NombreCompleto = dto.NombreCompleto;
            dentista.Telefono = dto.Telefono;
            dentista.Correo = dto.Correo;
            dentista.EspecialidadId = dto.EspecialidadId;

            await _repository.ActualizarAsync(dentista);

            return await ObtenerPorIdAsync(id);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repository.EliminarAsync(id);
        }
    }
}