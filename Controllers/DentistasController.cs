using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Carlos.Controllers
{
    [ApiController]
    [Route("api/dentistas")]
    [Authorize]
    public class DentistasController : ControllerBase
    {
        private readonly IDentistaService _service;

        public DentistasController(IDentistaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(new ApiResponse<List<DentistaResponseDto>>
            {
                Success = true,
                Message = "Lista de dentistas.",
                Data = await _service.ObtenerTodosAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var dentista = await _service.ObtenerPorIdAsync(id);

            if (dentista == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Dentista no encontrado."
                });
            }

            return Ok(new ApiResponse<DentistaResponseDto>
            {
                Success = true,
                Message = "Dentista encontrado.",
                Data = dentista
            });
        }

        [HttpPost]
        public async Task<IActionResult> Crear(DentistaCreateDto dto)
        {
            try
            {
                var dentista = await _service.CrearAsync(dto);

                return Ok(new ApiResponse<DentistaResponseDto>
                {
                    Success = true,
                    Message = "Dentista registrado correctamente.",
                    Data = dentista
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
        public async Task<IActionResult> Actualizar(int id, DentistaUpdateDto dto)
        {
            try
            {
                var dentista = await _service.ActualizarAsync(id, dto);

                if (dentista == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Dentista no encontrado."
                    });
                }

                return Ok(new ApiResponse<DentistaResponseDto>
                {
                    Success = true,
                    Message = "Dentista actualizado correctamente.",
                    Data = dentista
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool eliminado = await _service.EliminarAsync(id);

            if (!eliminado)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Dentista no encontrado."
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Dentista eliminado correctamente."
            });
        }
    }
}