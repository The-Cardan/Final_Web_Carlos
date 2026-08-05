using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Carlos.Controllers
{
    [ApiController]
    [Route("api/consultorios")]
    [Authorize]
    public class ConsultoriosController : ControllerBase
    {
        private readonly IConsultorioService _service;

        public ConsultoriosController(IConsultorioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(new ApiResponse<List<ConsultorioResponseDto>>
            {
                Success = true,
                Message = "Lista de consultorios.",
                Data = await _service.ObtenerTodosAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var consultorio = await _service.ObtenerPorIdAsync(id);

            if (consultorio == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Consultorio no encontrado."
                });
            }

            return Ok(new ApiResponse<ConsultorioResponseDto>
            {
                Success = true,
                Message = "Consultorio encontrado.",
                Data = consultorio
            });
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ConsultorioCreateDto dto)
        {
            try
            {
                var consultorio = await _service.CrearAsync(dto);

                return Ok(new ApiResponse<ConsultorioResponseDto>
                {
                    Success = true,
                    Message = "Consultorio creado correctamente.",
                    Data = consultorio
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
        public async Task<IActionResult> Actualizar(int id, ConsultorioUpdateDto dto)
        {
            var consultorio = await _service.ActualizarAsync(id, dto);

            if (consultorio == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Consultorio no encontrado."
                });
            }

            return Ok(new ApiResponse<ConsultorioResponseDto>
            {
                Success = true,
                Message = "Consultorio actualizado correctamente.",
                Data = consultorio
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
                    Message = "Consultorio no encontrado."
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Consultorio eliminado correctamente."
            });
        }
    }
}