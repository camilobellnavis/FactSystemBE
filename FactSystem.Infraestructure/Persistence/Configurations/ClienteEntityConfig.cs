using FactSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactSystem.Infraestructure.Persistence.Configurations
{
    public class ClienteEntityConfig
    {
        public ClienteEntityConfig(EntityTypeBuilder<Cliente> entity)
        {
            entity.ToTable("cliente");

            entity.Property(t => t.IdCliente)
                .HasColumnName("id_cliente");

            entity.Property(t => t.Activo)
                .HasColumnName("activo")
                .HasColumnType("tinyint");

            entity.Property(t => t.Correo)
                .HasColumnName("correo")
                .HasMaxLength(255);

            entity.Property(t => t.Direccion)
                .HasColumnName("direccion")
                .HasMaxLength(255);

            entity.Property(t => t.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasColumnType("date");

            entity.Property(t => t.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(255);

            entity.Property(t => t.Identificacion)
                .HasColumnName("identificacion")
                .HasMaxLength(15);

        }
    }
}
