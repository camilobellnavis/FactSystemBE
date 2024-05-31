using FactSystem.Application.DTOs.Enums;

namespace FactSystem.Application.DTOs
{
    public class UsuarioDto
    {
        public string NombreUsuario { get; set; }
        public StatusDto Bloqueado { get; set; }
        public int IntentosFallidos { get; set; }
        public string Contraseña { get; set; }
    }
}
