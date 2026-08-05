using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Carlos.Controllers
{
    [ApiController]
    [Route("api/motivos")]
    [Authorize]
    public class MotivosController : ControllerBase
    {
        private readonly IMotivoService _service;

        public MotivosController(IMotivoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(new ApiResponse<List<MotivoResponseDto>>
            {
                Success = true,
                Message = "Lista de motivos.",
                Data = await _service.ObtenerTodosAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var motivo = await _service.ObtenerPorIdAsync(id);

            if (motivo == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Motivo no encontrado."
                });
            }

            return Ok(new ApiResponse<MotivoResponseDto>
            {
                Success = true,
                Message = "Motivo encontrado.",
                Data = motivo
            });
        }

        [HttpPost]
        public async Task<IActionResult> Crear(MotivoCreateDto dto)
        {
            try
            {
                var motivo = await _service.CrearAsync(dto);

                return Ok(new ApiResponse<MotivoResponseDto>
                {
                    Success = true,
                    Message = "Motivo creado correctamente.",
                    Data = motivo
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
        public async Task<IActionResult> Actualizar(int id, MotivoUpdateDto dto)
        {
            var motivo = await _service.ActualizarAsync(id, dto);

            if (motivo == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Motivo no encontrado."
                });
            }

            return Ok(new ApiResponse<MotivoResponseDto>
            {
                Success = true,
                Message = "Motivo actualizado correctamente.",
                Data = motivo
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
                    Message = "Motivo no encontrado."
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Motivo eliminado correctamente."
            });
        }
    }
}