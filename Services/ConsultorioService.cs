using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Services
{
    public class ConsultorioService : IConsultorioService
    {
        private readonly IConsultorioRepository _repository;

        public ConsultorioService(IConsultorioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ConsultorioResponseDto>> ObtenerTodosAsync()
        {
            var lista = await _repository.ObtenerTodosAsync();

            return lista.Select(c => new ConsultorioResponseDto
            {
                Id = c.Id,
                Nombre = c.Nombre
            }).ToList();
        }

        public async Task<ConsultorioResponseDto?> ObtenerPorIdAsync(int id)
        {
            var consultorio = await _repository.ObtenerPorIdAsync(id);

            if (consultorio == null)
                return null;

            return new ConsultorioResponseDto
            {
                Id = consultorio.Id,
                Nombre = consultorio.Nombre
            };
        }

        public async Task<ConsultorioResponseDto> CrearAsync(ConsultorioCreateDto dto)
        {
            var existe = await _repository.ObtenerPorNombreAsync(dto.Nombre);

            if (existe != null)
                throw new Exception("El consultorio ya existe.");

            var consultorio = new Consultorio
            {
                Nombre = dto.Nombre
            };

            consultorio = await _repository.CrearAsync(consultorio);

            return new ConsultorioResponseDto
            {
                Id = consultorio.Id,
                Nombre = consultorio.Nombre
            };
        }

        public async Task<ConsultorioResponseDto?> ActualizarAsync(int id, ConsultorioUpdateDto dto)
        {
            var consultorio = await _repository.ObtenerPorIdAsync(id);

            if (consultorio == null)
                return null;

            consultorio.Nombre = dto.Nombre;

            await _repository.ActualizarAsync(consultorio);

            return new ConsultorioResponseDto
            {
                Id = consultorio.Id,
                Nombre = consultorio.Nombre
            };
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repository.EliminarAsync(id);
        }
    }
}