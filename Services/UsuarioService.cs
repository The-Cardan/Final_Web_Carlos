using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Helpers;
using Final_Web_Carlos.Interfaces;
using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public async Task<UsuarioResponseDto> RegistrarAsync(UsuarioRegisterDto dto)
        {
            bool existe = await _usuarioRepository
                .ExisteCorreoAsync(dto.Correo);

            if (existe)
            {
                throw new Exception(Messages.CorreoExistente);
            }


            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };


            var nuevoUsuario = await _usuarioRepository
                .CrearAsync(usuario);


            return new UsuarioResponseDto
            {
                Id = nuevoUsuario.Id,
                Nombre = nuevoUsuario.Nombre,
                Correo = nuevoUsuario.Correo
            };
        }



        public async Task<UsuarioResponseDto?> LoginAsync(
            UsuarioLoginDto dto)
        {
            var usuario = await _usuarioRepository
                .ObtenerPorCorreoAsync(dto.Correo);


            if (usuario == null)
                return null;


            bool passwordCorrecta =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    usuario.Password);


            if (!passwordCorrecta)
                return null;


            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo
            };
        }



        public async Task<List<UsuarioResponseDto>> ObtenerUsuariosAsync()
        {
            var usuarios = await _usuarioRepository
                .ObtenerTodosAsync();


            return usuarios.Select(u => new UsuarioResponseDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Correo = u.Correo

            }).ToList();
        }



        public async Task<UsuarioResponseDto?> ObtenerPorIdAsync(int id)
        {
            var usuario = await _usuarioRepository
                .ObtenerPorIdAsync(id);


            if (usuario == null)
                return null;


            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo
            };
        }



        public async Task<bool> EliminarAsync(int id)
        {
            return await _usuarioRepository
                .EliminarAsync(id);
        }
    }
}
