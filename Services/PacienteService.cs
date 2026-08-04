using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PacienteResponseDto>> ObtenerTodosAsync()
        {
            var pacientes = await _repository.ObtenerTodosAsync();

            return pacientes.Select(p => new PacienteResponseDto
            {
                Id = p.Id,
                NombreCompleto = p.NombreCompleto,
                Cedula = p.Cedula,
                Telefono = p.Telefono,
                Correo = p.Correo,
                FechaNacimiento = p.FechaNacimiento
            }).ToList();
        }

        public async Task<PacienteResponseDto?> ObtenerPorIdAsync(int id)
        {
            var paciente = await _repository.ObtenerPorIdAsync(id);

            if (paciente == null)
                return null;

            return new PacienteResponseDto
            {
                Id = paciente.Id,
                NombreCompleto = paciente.NombreCompleto,
                Cedula = paciente.Cedula,
                Telefono = paciente.Telefono,
                Correo = paciente.Correo,
                FechaNacimiento = paciente.FechaNacimiento
            };
        }

        public async Task<PacienteResponseDto> CrearAsync(PacienteCreateDto dto)
        {
            var existe = await _repository.ObtenerPorCedulaAsync(dto.Cedula);

            if (existe != null)
                throw new Exception("Ya existe un paciente con esa cédula.");

            var paciente = new Paciente
            {
                NombreCompleto = dto.NombreCompleto,
                Cedula = dto.Cedula,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                FechaNacimiento = dto.FechaNacimiento
            };

            paciente = await _repository.CrearAsync(paciente);

            return new PacienteResponseDto
            {
                Id = paciente.Id,
                NombreCompleto = paciente.NombreCompleto,
                Cedula = paciente.Cedula,
                Telefono = paciente.Telefono,
                Correo = paciente.Correo,
                FechaNacimiento = paciente.FechaNacimiento
            };
        }

        public async Task<PacienteResponseDto?> ActualizarAsync(int id, PacienteUpdateDto dto)
        {
            var paciente = await _repository.ObtenerPorIdAsync(id);

            if (paciente == null)
                return null;

            paciente.NombreCompleto = dto.NombreCompleto;
            paciente.Cedula = dto.Cedula;
            paciente.Telefono = dto.Telefono;
            paciente.Correo = dto.Correo;
            paciente.FechaNacimiento = dto.FechaNacimiento;

            paciente = await _repository.ActualizarAsync(paciente);

            return new PacienteResponseDto
            {
                Id = paciente.Id,
                NombreCompleto = paciente.NombreCompleto,
                Cedula = paciente.Cedula,
                Telefono = paciente.Telefono,
                Correo = paciente.Correo,
                FechaNacimiento = paciente.FechaNacimiento
            };
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repository.EliminarAsync(id);
        }
    }
}