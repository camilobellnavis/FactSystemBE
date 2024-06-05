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
    public class CabFacturaRepository : ICabFacturaRepository
    {
        private readonly ApplicationDbContext _context;
        public CabFacturaRepository(ApplicationDbContext context)
        {

            _context = context;

        }
        public async Task<bool> Create(CabFactura invoice)
        {
            await _context.AddAsync(invoice);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        public async Task<bool> Update(CabFactura invoice)
        {
            var entity = await _context.CabFacturas.AsNoTracking().SingleOrDefaultAsync(x => x.IdFactura.Equals(invoice.IdFactura));
            if (entity == null)
            {
                return await Task.FromResult(false);
            }
            entity.NumFactura = invoice.NumFactura;
            entity.DetFacturas = invoice.DetFacturas;
            entity.Total = invoice.Total;
            entity.SubTotal = invoice.SubTotal;
            entity.DniCliente = invoice.DniCliente;


            _context.Update(entity);
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
        public async Task<CabFactura> GetById(int invoiceId)
        {
            return await _context.CabFacturas.AsNoTracking().SingleOrDefaultAsync(x => x.IdFactura.Equals(invoiceId));

        }
        public async Task<List<CabFactura>> GetAll()
        {
            return await _context.CabFacturas.ToListAsync();
        }
        public async Task<bool> Delete(int invoiceId)
        {
            var entity = await _context.CabFacturas.AsNoTracking().SingleOrDefaultAsync(x => x.IdFactura.Equals(invoiceId));

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
            return  _context.CabFacturas.OrderByDescending(x => x.NumFactura).FirstOrDefaultAsync().Result.NumFactura;
        }

        public async Task<int> GetLastIdF()
        {
            return _context.CabFacturas.OrderByDescending(x => x.IdFactura).FirstOrDefaultAsync().Result.IdFactura;
        }
    }
}
