using FactSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactSystem.Application.Repositories
{
    public interface ICabFacturaRepository
    {
        Task<bool> Create(CabFactura invoice);
        Task<bool> Update(CabFactura invoice);
        Task<CabFactura> GetById(int invoiceId);
        Task<List<CabFactura>> GetAll();
        Task<bool> Delete(int invoiceId);
        Task<int> GetLastId();
        Task<int> GetLastIdF();
    }
}
