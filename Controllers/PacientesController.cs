using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Carlos.Controllers
{
    [ApiController]
    [Route("api/pacientes")]
    [Authorize]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacientesController(IPacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var pacientes = await _service.ObtenerTodosAsync();

            return Ok(new ApiResponse<List<PacienteResponseDto>>
            {
                Success = true,
                Message = "Lista de pacientes.",
                Data = pacientes
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var paciente = await _service.ObtenerPorIdAsync(id);

            if (paciente == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Paciente no encontrado."
                });
            }

            return Ok(new ApiResponse<PacienteResponseDto>
            {
                Success = true,
                Message = "Paciente encontrado.",
                Data = paciente
            });
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PacienteCreateDto dto)
        {
            try
            {
                var paciente = await _service.CrearAsync(dto);

                return Ok(new ApiResponse<PacienteResponseDto>
                {
                    Success = true,
                    Message = "Paciente registrado correctamente.",
                    Data = paciente
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, PacienteUpdateDto dto)
        {
            var paciente = await _service.ActualizarAsync(id, dto);

            if (paciente == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Paciente no encontrado."
                });
            }

            return Ok(new ApiResponse<PacienteResponseDto>
            {
                Success = true,
                Message = "Paciente actualizado correctamente.",
                Data = paciente
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool eliminado = await _service.EliminarAsync(id);

            if (!eliminado)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Paciente no encontrado."
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Paciente eliminado correctamente."
            });
        }
    }
}