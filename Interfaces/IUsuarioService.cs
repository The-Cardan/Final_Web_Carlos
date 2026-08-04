using Final_Web_Carlos.DTOs;
using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponseDto> RegistrarAsync(UsuarioRegisterDto dto);

        Task<UsuarioResponseDto?> LoginAsync(UsuarioLoginDto dto);

        Task<List<UsuarioResponseDto>> ObtenerUsuariosAsync();

        Task<UsuarioResponseDto?> ObtenerPorIdAsync(int id);

        Task<bool> EliminarAsync(int id);
        Task<Usuario?> ValidarCredencialesAsync(UsuarioLoginDto dto);
    }
}
