using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Carlos.Controllers
{
    [ApiController]
    [Route("api/citas")]
    [Authorize]
    public class CitasController : ControllerBase
    {
        private readonly ICitaService _service;

        public CitasController(ICitaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            return Ok(new ApiResponse<List<CitaResponseDto>>
            {
                Success = true,
                Message = "Lista de citas.",
                Data = await _service.ObtenerTodasAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var cita = await _service.ObtenerPorIdAsync(id);

            if (cita == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Cita no encontrada."
                });
            }

            return Ok(new ApiResponse<CitaResponseDto>
            {
                Success = true,
                Message = "Cita encontrada.",
                Data = cita
            });
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CitaCreateDto dto)
        {
            try
            {
                var cita = await _service.CrearAsync(dto);

                return Ok(new ApiResponse<CitaResponseDto>
                {
                    Success = true,
                    Message = "Cita creada correctamente.",
                    Data = cita
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
        public async Task<IActionResult> Actualizar(int id, CitaUpdateDto dto)
        {
            try
            {
                var cita = await _service.ActualizarAsync(id, dto);

                if (cita == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Cita no encontrada."
                    });
                }

                return Ok(new ApiResponse<CitaResponseDto>
                {
                    Success = true,
                    Message = "Cita actualizada correctamente.",
                    Data = cita
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
                    Message = "Cita no encontrada."
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Cita eliminada correctamente."
            });
        }
    }
}