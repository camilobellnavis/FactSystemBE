using FactSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactSystem.Infraestructure.Persistence.Configurations
{
    public class DetFacturaEntityConfig 
    {
        public  DetFacturaEntityConfig(EntityTypeBuilder<DetFactura> entity)
        {
            entity.ToTable("det_factura");

            entity.HasOne(x => x.CabFacturaNavigation)
                .WithMany(x => x.DetFacturas)
                .HasForeignKey(x => x.CabFactura)
                .HasConstraintName("FK_DetFactura_CabFactura")
                .OnDelete(DeleteBehavior.ClientSetNull); ;

            entity.Property(t => t.Id)
               .HasColumnName("id");

            entity.Property(t => t.Cantidad)
               .HasColumnName("cantidad");

            entity.Property(t => t.CodigoProducto)
               .HasColumnName("codigo_producto");

            entity.Property(t => t.CabFactura)
               .HasColumnName("cab_factura");

        }
    }
}
