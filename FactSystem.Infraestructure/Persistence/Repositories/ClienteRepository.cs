using FactSystem.Application.Repositories;
using FactSystem.Domain.Entities;
using FactSystem.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FactSystem.Infraestructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context) {
            
            _context = context;

        }
        public async Task<bool> Create(Cliente customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        public async Task<bool> Update(Cliente customer)
        {
            var entity = await _context.Clientes.AsNoTracking().SingleOrDefaultAsync(x => x.IdCliente.Equals(customer.IdCliente));
            if (entity == null)
            {
                return await Task.FromResult(false);
            }
            entity.Nombre = customer.Nombre;
            entity.Identificacion = customer.Identificacion;
            entity.Correo = customer.Correo;
            entity.Direccion = customer.Direccion;
            entity.FechaCreacion = customer.FechaCreacion;
            entity.Activo = customer.Activo;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
        public async Task<Cliente> GetById(int customerId)
        {
            return await _context.Clientes.AsNoTracking().SingleOrDefaultAsync(x => x.IdCliente.Equals(customerId));
        }
        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<bool> Delete(int customerId)
        {
            var entity = await _context.Clientes.AsNoTracking().SingleOrDefaultAsync(x => x.IdCliente.Equals(customerId));

            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }



    }
}
