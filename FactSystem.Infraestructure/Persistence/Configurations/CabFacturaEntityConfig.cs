using FactSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactSystem.Infraestructure.Persistence.Configurations
{
    public class CabFacturaEntityConfig
    {
        public CabFacturaEntityConfig(EntityTypeBuilder<CabFactura> entity)
        {
            entity.ToTable("cab_factura");

            entity.Property(t => t.IdFactura)
               .HasColumnName("id_factura");

            entity.Property(t => t.NumFactura)
               .HasColumnName("num_factura")
               .HasAnnotation("SqlServer:Identity", "10001, 1");

            entity.Property(t => t.DniCliente)
               .HasColumnName("dni_cliente")
               .HasMaxLength(255);

            entity.Property(t => t.Impuesto)
               .HasColumnName("impuesto")
               .HasColumnType("decimal(10,2)");

            entity.Property(t => t.SubTotal)
               .HasColumnName("subtotal")
               .HasColumnType("decimal(10,2)");

            entity.Property(t => t.Total)
               .HasColumnName("total")
               .HasColumnType("decimal(10,2)");
        }
    }
}
