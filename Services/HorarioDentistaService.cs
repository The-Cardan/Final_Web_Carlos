using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Services
{
    public class HorarioDentistaService : IHorarioDentistaService
    {
        private readonly IHorarioDentistaRepository _repository;
        private readonly IDentistaRepository _dentistaRepository;

        public HorarioDentistaService(
            IHorarioDentistaRepository repository,
            IDentistaRepository dentistaRepository)
        {
            _repository = repository;
            _dentistaRepository = dentistaRepository;
        }

        public async Task<List<HorarioDentistaResponseDto>> ObtenerTodosAsync()
        {
            var lista = await _repository.ObtenerTodosAsync();

            return lista.Select(h => new HorarioDentistaResponseDto
            {
                Id = h.Id,
                DentistaId = h.DentistaId,
                Dentista = h.Dentista.NombreCompleto,
                Dia = h.Dia,
                HoraInicio = h.HoraInicio,
                HoraFin = h.HoraFin
            }).ToList();
        }

        public async Task<HorarioDentistaResponseDto?> ObtenerPorIdAsync(int id)
        {
            var horario = await _repository.ObtenerPorIdAsync(id);

            if (horario == null)
                return null;

            return new HorarioDentistaResponseDto
            {
                Id = horario.Id,
                DentistaId = horario.DentistaId,
                Dentista = horario.Dentista.NombreCompleto,
                Dia = horario.Dia,
                HoraInicio = horario.HoraInicio,
                HoraFin = horario.HoraFin
            };
        }

        public async Task<HorarioDentistaResponseDto> CrearAsync(HorarioDentistaCreateDto dto)
        {
            var dentista = await _dentistaRepository.ObtenerPorIdAsync(dto.DentistaId);

            if (dentista == null)
                throw new Exception("El dentista no existe.");

            if (dto.HoraInicio >= dto.HoraFin)
                throw new Exception("La hora de inicio debe ser menor que la hora de fin.");

            var horario = new HorarioDentista
            {
                DentistaId = dto.DentistaId,
                Dia = dto.Dia,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin
            };

            horario = await _repository.CrearAsync(horario);

            return await ObtenerPorIdAsync(horario.Id)
                ?? throw new Exception("Error al crear el horario.");
        }

        public async Task<HorarioDentistaResponseDto?> ActualizarAsync(int id, HorarioDentistaUpdateDto dto)
        {
            var horario = await _repository.ObtenerPorIdAsync(id);

            if (horario == null)
                return null;

            if (dto.HoraInicio >= dto.HoraFin)
                throw new Exception("La hora de inicio debe ser menor que la hora de fin.");

            horario.Dia = dto.Dia;
            horario.HoraInicio = dto.HoraInicio;
            horario.HoraFin = dto.HoraFin;

            await _repository.ActualizarAsync(horario);

            return await ObtenerPorIdAsync(id);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repository.EliminarAsync(id);
        }
    }
}