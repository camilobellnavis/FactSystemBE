using FactSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactSystem.Infraestructure.Persistence.Configurations
{
    public class UsuarioEntityConfig
    {
        public  UsuarioEntityConfig(EntityTypeBuilder<Usuario> entity)
        {
            entity.ToTable("usuario");

            entity.Property(t => t.NombreUsuario)
                .HasColumnName("nombre_usuario")
                .HasMaxLength(255);

            entity.Property(t => t.Contraseña)
                .HasColumnName("contraseña")
                .HasMaxLength(255);

            entity.Property(t => t.Bloqueado)
                .HasColumnName("bloqueado")
                .HasColumnType("tinyint");
            
            entity.Property(t => t.IntentosFallidos)
                .HasColumnName("intentos_fallidos")
                .HasColumnType("int");

        }
    }
}

