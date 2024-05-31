using FactSystem.Application.DTOs.Enums;

namespace FactSystem.Application.DTOs
{
    public class ProductoDto
    {
        public int IdProducto { get; set; }
        public StatusDto Activo { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Inventario { get; set; }
    }
}
