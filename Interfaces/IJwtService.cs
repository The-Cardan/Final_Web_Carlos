using Final_Web_Carlos.Models;

namespace Final_Web_Carlos.Interfaces
{
    public interface IJwtService
    {
        string GenerarToken(Usuario usuario);
    }
}
