using GA.WebAPI.Models;

namespace GA.WebAPI.Service
{
    public class UsuarioService
    {
        public static Usuario RetornarUsuario(int id)
        {
            return new Usuario { Id = id, Nome = $"Usuario - {id}" };
        }
    }
}