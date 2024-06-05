using FactSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactSystem.Application.Repositories
{
    public interface IDetFacturaRepository
    {
        Task<bool> Create(DetFactura detail);
        Task<bool> Update(DetFactura detail);
        Task<DetFactura> GetById(int detailId);
        Task<List<DetFactura>> GetAll();
        Task<bool> Delete(int detailId);
        Task<int> GetLastId();
    }
}
