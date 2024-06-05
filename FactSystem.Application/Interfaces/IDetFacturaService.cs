using FactSystem.Application.Commons;
using FactSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactSystem.Application.Interfaces
{
    public interface IDetFacturaService
    {
        Task<Response<bool>> Create(DetFactura detail);
        Task<Response<bool>> Update(DetFactura detail);
        Task<Response<DetFactura>> GetById(int detailId);
        Task<Response<List<DetFactura>>> GetAll();
        Task<Response<bool>> Delete(int detailId);
        Task<Response<int>> GetLastId();
    }
}
