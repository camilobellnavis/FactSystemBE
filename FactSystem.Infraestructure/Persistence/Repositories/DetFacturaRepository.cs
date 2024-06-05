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
    public class DetFacturaRepository : IDetFacturaRepository
    {
        private readonly ApplicationDbContext _context;
        public DetFacturaRepository(ApplicationDbContext context)
        {

            _context = context;

        }
        public async Task<bool> Create(DetFactura detail)
        {
            await _context.AddAsync(detail);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        public async Task<bool> Update(DetFactura detail)
        {
            var entity = await _context.DetFacturas.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(detail.Id));
            if (entity == null)
            {
                return await Task.FromResult(false);
            }
            entity.CabFactura = detail.CabFactura;
            entity.Cantidad = detail.Cantidad;
            entity.CodigoProducto = detail.CodigoProducto;
            

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
        public async Task<DetFactura> GetById(int detailId)
        {
            return await _context.DetFacturas.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(detailId));

        }
        public async Task<List<DetFactura>> GetAll()
        {
            return await _context.DetFacturas.ToListAsync();
        }
        public async Task<bool> Delete(int detailId)
        {
            var entity = await _context.DetFacturas.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(detailId));

            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.Remove(entity);
            _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        public async Task<int> GetLastId()
        {
            return _context.DetFacturas.OrderByDescending(x => x.Id).FirstOrDefaultAsync().Result.Id;
        }



    }
}
