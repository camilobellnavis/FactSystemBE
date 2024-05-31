using FactSystem.Application.Commons;
using FactSystem.Domain.Entities;

namespace FactSystem.Application.Repositories
{
    public interface IProductoRepository
    {
        Task<bool> Create(Producto product);
        Task<bool> Update(Producto product);
        Task<Producto> GetById(int productId);
        Task<List<Producto>> GetAll();
        Task<bool> Delete(int productId);
    }
}
