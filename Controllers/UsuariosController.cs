using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Helpers;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Carlos.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var usuarios =
                await _usuarioService.ObtenerUsuariosAsync();

            return Ok(new ApiResponse<List<UsuarioResponseDto>>
            {
                Success = true,
                Message = "Lista de usuarios.",
                Data = usuarios
            });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var usuario =
                await _usuarioService.ObtenerPorIdAsync(id);

            if (usuario == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = Messages.RegistroNoEncontrado
                });
            }

            return Ok(new ApiResponse<UsuarioResponseDto>
            {
                Success = true,
                Message = "Usuario encontrado.",
                Data = usuario
            });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(
            int id,
            [FromBody] UsuarioUpdateDto dto)
        {
            try
            {
                var usuario =
                    await _usuarioService.ActualizarAsync(id, dto);

                if (usuario == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = Messages.RegistroNoEncontrado
                    });
                }

                return Ok(new ApiResponse<UsuarioResponseDto>
                {
                    Success = true,
                    Message = Messages.RegistroActualizado,
                    Data = usuario
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado =
                await _usuarioService.EliminarAsync(id);

            if (!eliminado)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = Messages.RegistroNoEncontrado
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = Messages.RegistroEliminado
            });
        }
    }
}
