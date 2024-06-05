using System.ComponentModel.DataAnnotations;

namespace FactSystem.Domain.Entities
{
    public class DetFactura
    {
        [Key]
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int CodigoProducto { get; set; }
        public int CabFactura { get; set; }
        public virtual CabFactura? CabFacturaNavigation { get; set; }
    }
}
