using FactSystem.Application.Interfaces;
using FactSystem.Application.Repositories;
using FactSystem.Application.UsesCases;
using FactSystem.Infraestructure.Persistence.Contexts;
using FactSystem.Infraestructure.Persistence.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FactSystem.Infraestructure.Persistence
{
    public static class ConfigureServices
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "(localdb)\\Servidor";
            connectionStringBuilder.InitialCatalog = "SystemFactDB";
            connectionStringBuilder.IntegratedSecurity = true;
            var cs = connectionStringBuilder.ConnectionString;

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(cs,
                    builder => builder.MigrationsAssembly("FactSystem.Api")));

            
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IDetFacturaRepository, DetFacturaRepository>();
            services.AddScoped<IDetFacturaService, DetFacturaService>();
            services.AddScoped<ICabFacturaService, CabFacturaService>();
            services.AddScoped<ICabFacturaRepository, CabFacturaRepository>();
            services.AddSingleton<IConfiguration>(configuration);
            

            return services;
        }
    }
}
