using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Helpers;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Carlos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IJwtService _jwtService;

        public AuthController(
            IUsuarioService usuarioService,
            IJwtService jwtService)
        {
            _usuarioService = usuarioService;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Registrar un nuevo usuario.
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioRegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Datos inválidos.",
                    Errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList()
                });
            }

            try
            {
                var usuario = await _usuarioService.RegistrarAsync(dto);

                return Created("", new ApiResponse<UsuarioResponseDto>
                {
                    Success = true,
                    Message = Messages.RegistroExitoso,
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

        /// <summary>
        /// Iniciar sesión.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Datos inválidos."
                });
            }

            var usuario = await _usuarioService.ValidarCredencialesAsync(dto);

            if (usuario == null)
            {
                return Unauthorized(new ApiResponse<object>
                {
                    Success = false,
                    Message = Messages.CredencialesInvalidas
                });
            }

            var token = _jwtService.GenerarToken(usuario);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = Messages.LoginExitoso,
                Data = new
                {
                    Token = token,
                    Usuario = usuario.Nombre,
                    Correo = usuario.Correo
                }
            });
        }
    }
}
