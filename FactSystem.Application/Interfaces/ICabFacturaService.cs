using FactSystem.Application.Commons;
using FactSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactSystem.Application.Interfaces
{
    public interface ICabFacturaService
    {
        Task<Response<bool>> Create(CabFactura invoice);
        Task<Response<bool>> Update(CabFactura invoice);
        Task<Response<CabFactura>> GetById(int invoiceId);
        Task<Response<List<CabFactura>>> GetAll();
        Task<Response<bool>> Delete(int invoiceId);
        Task<Response<int>> GetLastId();
        Task<Response<int>> GetLastIdF();
    }
}
