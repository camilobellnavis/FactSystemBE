using FactSystem.Application.DTOs.Enums;

namespace FactSystem.Application.DTOs
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public StatusDto Activo { get; set; }
    }
}
