using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Services
{
    public class MotivoService : IMotivoService
    {
        private readonly IMotivoRepository _repository;

        public MotivoService(IMotivoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MotivoResponseDto>> ObtenerTodosAsync()
        {
            var lista = await _repository.ObtenerTodosAsync();

            return lista.Select(m => new MotivoResponseDto
            {
                Id = m.Id,
                Descripcion = m.Descripcion
            }).ToList();
        }

        public async Task<MotivoResponseDto?> ObtenerPorIdAsync(int id)
        {
            var motivo = await _repository.ObtenerPorIdAsync(id);

            if (motivo == null)
                return null;

            return new MotivoResponseDto
            {
                Id = motivo.Id,
                Descripcion = motivo.Descripcion
            };
        }

        public async Task<MotivoResponseDto> CrearAsync(MotivoCreateDto dto)
        {
            var existe = await _repository.ObtenerPorDescripcionAsync(dto.Descripcion);

            if (existe != null)
                throw new Exception("El motivo ya existe.");

            var motivo = new Motivo
            {
                Descripcion = dto.Descripcion
            };

            motivo = await _repository.CrearAsync(motivo);

            return new MotivoResponseDto
            {
                Id = motivo.Id,
                Descripcion = motivo.Descripcion
            };
        }

        public async Task<MotivoResponseDto?> ActualizarAsync(int id, MotivoUpdateDto dto)
        {
            var motivo = await _repository.ObtenerPorIdAsync(id);

            if (motivo == null)
                return null;

            motivo.Descripcion = dto.Descripcion;

            await _repository.ActualizarAsync(motivo);

            return new MotivoResponseDto
            {
                Id = motivo.Id,
                Descripcion = motivo.Descripcion
            };
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repository.EliminarAsync(id);
        }
    }
}
