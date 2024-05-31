using System.ComponentModel.DataAnnotations;

namespace FactSystem.Domain.Entities
{
    public class CabFactura
    {
        [Key]
        public int IdFactura { get; set; }
        public int NumFactura { get; set; }
        public string DniCliente { get; set; }
        public double Impuesto { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public virtual ICollection<DetFactura> DetFacturas { get; set; }
    }
}
