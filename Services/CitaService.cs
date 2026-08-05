using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Helpers;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IDentistaRepository _dentistaRepository;
        private readonly IMotivoRepository _motivoRepository;
        private readonly IServicioRepository _servicioRepository;
        private readonly IConsultorioRepository _consultorioRepository;
        private readonly IHorarioDentistaRepository _horarioRepository;

        public CitaService(
            ICitaRepository citaRepository,
            IPacienteRepository pacienteRepository,
            IDentistaRepository dentistaRepository,
            IMotivoRepository motivoRepository,
            IServicioRepository servicioRepository,
            IConsultorioRepository consultorioRepository,
            IHorarioDentistaRepository horarioRepository)
        {
            _citaRepository = citaRepository;
            _pacienteRepository = pacienteRepository;
            _dentistaRepository = dentistaRepository;
            _motivoRepository = motivoRepository;
            _servicioRepository = servicioRepository;
            _consultorioRepository = consultorioRepository;
            _horarioRepository = horarioRepository;
        }

        public async Task<List<CitaResponseDto>> ObtenerTodasAsync()
        {
            var citas = await _citaRepository.ObtenerTodasAsync();

            return citas.Select(ConvertirDto).ToList();
        }

        public async Task<CitaResponseDto?> ObtenerPorIdAsync(int id)
        {
            var cita = await _citaRepository.ObtenerPorIdAsync(id);

            if (cita == null)
                return null;

            return ConvertirDto(cita);
        }

        // ==========================
        // VALIDACIONES PRIVADAS
        // ==========================

        private async Task ValidarEntidades(CitaCreateDto dto)
        {
            if (await _pacienteRepository.ObtenerPorIdAsync(dto.PacienteId) == null)
                throw new Exception("El paciente no existe.");

            if (await _dentistaRepository.ObtenerPorIdAsync(dto.DentistaId) == null)
                throw new Exception("El dentista no existe.");

            if (await _motivoRepository.ObtenerPorIdAsync(dto.MotivoId) == null)
                throw new Exception("El motivo no existe.");

            if (await _servicioRepository.ObtenerPorIdAsync(dto.ServicioId) == null)
                throw new Exception("El servicio no existe.");

            if (await _consultorioRepository.ObtenerPorIdAsync(dto.ConsultorioId) == null)
                throw new Exception("El consultorio no existe.");
        }

        private void ValidarFecha(CitaCreateDto dto)
        {
            if (dto.Fecha.Date < DateTime.Today)
                throw new Exception("La fecha no puede ser anterior al día de hoy.");

            if (dto.Duracion <= 0)
                throw new Exception("La duración debe ser mayor que cero.");
        }

        private async Task ValidarDuplicado(CitaCreateDto dto)
        {
            bool existe = await _citaRepository.ExisteCitaAsync(
                dto.DentistaId,
                dto.Fecha,
                dto.Hora);

            if (existe)
                throw new Exception("El dentista ya tiene una cita en esa fecha y hora.");
        }

        private async Task ValidarHorario(CitaCreateDto dto)
        {
            var horarios = await _horarioRepository.ObtenerTodosAsync();

            var horario = horarios.FirstOrDefault(h =>
                h.DentistaId == dto.DentistaId &&
                (int)h.Dia == (int)dto.Fecha.DayOfWeek);

            if (horario == null)
                throw new Exception("El dentista no tiene horario disponible ese día.");

            if (dto.Hora < horario.HoraInicio || dto.Hora >= horario.HoraFin)
                throw new Exception("La hora está fuera del horario del dentista.");
        }

        public async Task<CitaResponseDto> CrearAsync(CitaCreateDto dto)
        {
            await ValidarEntidades(dto);

            ValidarFecha(dto);

            await ValidarDuplicado(dto);

            await ValidarHorario(dto);

            var cita = new Cita
            {
                PacienteId = dto.PacienteId,
                Fecha = dto.Fecha.Date,
                Hora = dto.Hora,
                Duracion = dto.Duracion,
                DentistaId = dto.DentistaId,
                MotivoId = dto.MotivoId,
                ServicioId = dto.ServicioId,
                ConsultorioId = dto.ConsultorioId
            };

            DateTime fechaHoraInicio = cita.Fecha.Date + cita.Hora;

            DateTime fechaHoraFin = fechaHoraInicio.AddMinutes(cita.Duracion);

            cita.Estado =
                CitaHelper.CalcularEstado(
                    fechaHoraInicio,
                    fechaHoraFin);

            cita.DiasHorasRestantes =
                CitaHelper.CalcularTiempoRestante(
                    fechaHoraInicio);

            cita = await _citaRepository.CrearAsync(cita);

            return ConvertirDto(
                await _citaRepository.ObtenerPorIdAsync(cita.Id)
                ?? throw new Exception("Error al crear la cita."));
        }

        public async Task<CitaResponseDto?> ActualizarAsync(int id, CitaUpdateDto dto)
        {
            var cita = await _citaRepository.ObtenerPorIdAsync(id);

            if (cita == null)
                return null;

            // Validar entidades relacionadas
            if (await _dentistaRepository.ObtenerPorIdAsync(dto.DentistaId) == null)
                throw new Exception("El dentista no existe.");

            if (await _motivoRepository.ObtenerPorIdAsync(dto.MotivoId) == null)
                throw new Exception("El motivo no existe.");

            if (await _servicioRepository.ObtenerPorIdAsync(dto.ServicioId) == null)
                throw new Exception("El servicio no existe.");

            if (await _consultorioRepository.ObtenerPorIdAsync(dto.ConsultorioId) == null)
                throw new Exception("El consultorio no existe.");

            cita.Fecha = dto.Fecha.Date;
            cita.Hora = dto.Hora;
            cita.Duracion = dto.Duracion;
            cita.DentistaId = dto.DentistaId;
            cita.MotivoId = dto.MotivoId;
            cita.ServicioId = dto.ServicioId;
            cita.ConsultorioId = dto.ConsultorioId;

            DateTime inicio = cita.Fecha.Date + cita.Hora;
            DateTime fin = inicio.AddMinutes(cita.Duracion);

            cita.Estado = CitaHelper.CalcularEstado(inicio, fin);

            cita.DiasHorasRestantes =
                CitaHelper.CalcularTiempoRestante(inicio);

            await _citaRepository.ActualizarAsync(cita);

            var citaActualizada = await _citaRepository.ObtenerPorIdAsync(id);

            if (citaActualizada == null)
                throw new Exception("No se pudo recuperar la cita actualizada.");

            return ConvertirDto(citaActualizada);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _citaRepository.EliminarAsync(id);
        }

        private static CitaResponseDto ConvertirDto(Cita cita)
        {
            return new CitaResponseDto
            {
                Id = cita.Id,
                Paciente = cita.Paciente.NombreCompleto,
                Dentista = cita.Dentista.NombreCompleto,
                Especialidad = cita.Dentista.Especialidad.Nombre,
                Motivo = cita.Motivo.Descripcion,
                Servicio = cita.Servicio.Nombre,
                Consultorio = cita.Consultorio.Nombre,
                Fecha = cita.Fecha,
                Hora = cita.Hora,
                Duracion = cita.Duracion,
                Estado = cita.Estado,
                DiasHorasRestantes = cita.DiasHorasRestantes

            };
        }
    }
}


