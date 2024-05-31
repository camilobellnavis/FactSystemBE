using FactSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactSystem.Infraestructure.Persistence.Configurations
{
    public class ProductoEntityConfig
    {
        public  ProductoEntityConfig(EntityTypeBuilder<Producto> entity)
        {
            entity.ToTable("producto");

            entity.Property(t => t.IdProducto)
                .HasColumnName("id_producto");

            entity.Property(t => t.Activo)
                .HasColumnName("activo")
                .HasColumnType("tinyint");

            entity.Property(t => t.Codigo)
                .HasColumnName("codigo")
                .HasMaxLength(15);


            entity.Property(t => t.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasColumnType("date");

            entity.Property(t => t.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(255);

            entity.Property(t => t.Precio)
                .HasColumnName("precio")
                .HasColumnType("decimal");

            entity.Property(t => t.Inventario)
                .HasColumnName("inventario")
                .HasColumnType("int");

        }
    }
}
