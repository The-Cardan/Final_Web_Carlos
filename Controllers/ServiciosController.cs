using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Carlos.Controllers
{
    [ApiController]
    [Route("api/servicios")]
    [Authorize]
    public class ServiciosController : ControllerBase
    {
        private readonly IServicioService _service;

        public ServiciosController(IServicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(new ApiResponse<List<ServicioResponseDto>>
            {
                Success = true,
                Message = "Lista de servicios.",
                Data = await _service.ObtenerTodosAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var servicio = await _service.ObtenerPorIdAsync(id);

            if (servicio == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Servicio no encontrado."
                });
            }

            return Ok(new ApiResponse<ServicioResponseDto>
            {
                Success = true,
                Message = "Servicio encontrado.",
                Data = servicio
            });
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ServicioCreateDto dto)
        {
            try
            {
                var servicio = await _service.CrearAsync(dto);

                return Ok(new ApiResponse<ServicioResponseDto>
                {
                    Success = true,
                    Message = "Servicio creado correctamente.",
                    Data = servicio
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
        public async Task<IActionResult> Actualizar(int id, ServicioUpdateDto dto)
        {
            var servicio = await _service.ActualizarAsync(id, dto);

            if (servicio == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Servicio no encontrado."
                });
            }

            return Ok(new ApiResponse<ServicioResponseDto>
            {
                Success = true,
                Message = "Servicio actualizado correctamente.",
                Data = servicio
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
                    Message = "Servicio no encontrado."
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Servicio eliminado correctamente."
            });
        }
    }
}