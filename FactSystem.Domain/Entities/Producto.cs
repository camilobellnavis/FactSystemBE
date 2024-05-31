using FactSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FactSystem.Domain.Entities
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public Status Activo { get; set;}
        public string Codigo { get; set;}
        public DateTime FechaCreacion { get; set;}
        public string Nombre { get; set; }
        public double Precio { get; set;}
        public int Inventario { get; set; }
    }
}
