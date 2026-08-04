using Final_Web_Carlos.DTOs;

namespace Final_Web_Carlos.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponseDto> RegistrarAsync(UsuarioRegisterDto dto);

        Task<UsuarioResponseDto?> LoginAsync(UsuarioLoginDto dto);

        Task<List<UsuarioResponseDto>> ObtenerUsuariosAsync();

        Task<UsuarioResponseDto?> ObtenerPorIdAsync(int id);

        Task<bool> EliminarAsync(int id);
    }
}
