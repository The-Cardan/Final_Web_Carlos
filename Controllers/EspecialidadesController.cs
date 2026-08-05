using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Carlos.Controllers
{
    [ApiController]
    [Route("api/especialidades")]
    [Authorize]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadService _service;

        public EspecialidadesController(IEspecialidadService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            return Ok(new ApiResponse<List<EspecialidadResponseDto>>
            {
                Success = true,
                Message = "Lista de especialidades.",
                Data = await _service.ObtenerTodasAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var especialidad = await _service.ObtenerPorIdAsync(id);

            if (especialidad == null)
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Especialidad no encontrada."
                });

            return Ok(new ApiResponse<EspecialidadResponseDto>
            {
                Success = true,
                Message = "Especialidad encontrada.",
                Data = especialidad
            });
        }

        [HttpPost]
        public async Task<IActionResult> Crear(EspecialidadCreateDto dto)
        {
            try
            {
                var especialidad = await _service.CrearAsync(dto);

                return Ok(new ApiResponse<EspecialidadResponseDto>
                {
                    Success = true,
                    Message = "Especialidad creada correctamente.",
                    Data = especialidad
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
        public async Task<IActionResult> Actualizar(int id, EspecialidadUpdateDto dto)
        {
            var especialidad = await _service.ActualizarAsync(id, dto);

            if (especialidad == null)
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Especialidad no encontrada."
                });

            return Ok(new ApiResponse<EspecialidadResponseDto>
            {
                Success = true,
                Message = "Especialidad actualizada correctamente.",
                Data = especialidad
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _service.EliminarAsync(id);

            if (!eliminado)
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Especialidad no encontrada."
                });

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Especialidad eliminada correctamente."
            });
        }
    }
}