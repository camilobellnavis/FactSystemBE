using FactSystem.Application.Commons;
using FactSystem.Application.Repositories;
using FactSystem.Domain.Entities;
using FactSystem.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactSystem.Infraestructure.Persistence.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductoRepository(ApplicationDbContext context)
        {

            _context = context;

        }
        public async Task<bool> Create(Producto product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        public async Task<bool> Update(Producto product)
        {
            var entity = await _context.Productos.AsNoTracking().SingleOrDefaultAsync(x => x.IdProducto.Equals(product.IdProducto));
            if (entity == null)
            {
                return await Task.FromResult(false);
            }
            entity.Nombre = product.Nombre;
            entity.FechaCreacion = product.FechaCreacion;
            entity.Precio = product.Precio;
            entity.Inventario = product.Inventario;
            entity.Activo = product.Activo;
            entity.Codigo = product.Codigo;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
        public async Task<Producto> GetById(int productId)
        {
            return await _context.Productos.AsNoTracking().SingleOrDefaultAsync(x => x.IdProducto.Equals(productId));
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }
        public async Task<bool> Delete(int productId)
        {
            var entity = await _context.Productos.AsNoTracking().SingleOrDefaultAsync(x => x.IdProducto.Equals(productId));

            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.Remove(entity);
            _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }



    }
}
