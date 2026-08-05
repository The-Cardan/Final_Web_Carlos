using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Carlos.Controllers
{
    [ApiController]
    [Route("api/horarios")]
    [Authorize]
    public class HorariosDentistasController : ControllerBase
    {
        private readonly IHorarioDentistaService _service;

        public HorariosDentistasController(IHorarioDentistaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(new ApiResponse<List<HorarioDentistaResponseDto>>
            {
                Success = true,
                Message = "Lista de horarios.",
                Data = await _service.ObtenerTodosAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var horario = await _service.ObtenerPorIdAsync(id);

            if (horario == null)
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Horario no encontrado."
                });

            return Ok(new ApiResponse<HorarioDentistaResponseDto>
            {
                Success = true,
                Message = "Horario encontrado.",
                Data = horario
            });
        }

        [HttpPost]
        public async Task<IActionResult> Crear(HorarioDentistaCreateDto dto)
        {
            try
            {
                var horario = await _service.CrearAsync(dto);

                return Ok(new ApiResponse<HorarioDentistaResponseDto>
                {
                    Success = true,
                    Message = "Horario creado correctamente.",
                    Data = horario
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
        public async Task<IActionResult> Actualizar(int id, HorarioDentistaUpdateDto dto)
        {
            try
            {
                var horario = await _service.ActualizarAsync(id, dto);

                if (horario == null)
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Horario no encontrado."
                    });

                return Ok(new ApiResponse<HorarioDentistaResponseDto>
                {
                    Success = true,
                    Message = "Horario actualizado correctamente.",
                    Data = horario
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
            var eliminado = await _service.EliminarAsync(id);

            if (!eliminado)
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Horario no encontrado."
                });

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Horario eliminado correctamente."
            });
        }
    }
}