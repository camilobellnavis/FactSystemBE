using FactSystem.Application.Commons;
using FactSystem.Domain.Entities;

namespace FactSystem.Application.Interfaces
{
    public interface IProductoService
    {
        Task<Response<bool>> Create(Producto product);
        Task<Response<bool>> Update(Producto product);
        Task<Response<Producto>> GetById(int productId);
        Task<Response<List<Producto>>> GetAll();
        Task<Response<bool>> Delete(int productId);
    }
}
