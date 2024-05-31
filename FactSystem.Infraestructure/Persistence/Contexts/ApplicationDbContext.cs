using FactSystem.Domain.Entities;
using FactSystem.Infraestructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace FactSystem.Infraestructure.Persistence.Contexts
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<CabFactura> CabFacturas { get; set; }
        public virtual DbSet<DetFactura> DetFacturas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelConfigurationBuilder(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ModelConfigurationBuilder(ModelBuilder modelBuilder)
        {
            new CabFacturaEntityConfig(modelBuilder.Entity<CabFactura>());
            new ClienteEntityConfig(modelBuilder.Entity<Cliente>());
            new DetFacturaEntityConfig(modelBuilder.Entity<DetFactura>());
            new ProductoEntityConfig(modelBuilder.Entity<Producto>());
            new UsuarioEntityConfig(modelBuilder.Entity<Usuario>());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
