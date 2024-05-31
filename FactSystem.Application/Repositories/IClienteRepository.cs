using FactSystem.Domain.Entities;

namespace FactSystem.Application.Repositories
{
    public interface IClienteRepository
    {
        Task<bool> Create(Cliente customerId);
        Task<bool> Update(Cliente customer);
        Task<Cliente> GetById(int customerId);
        Task<List<Cliente>> GetAll();
        Task<bool> Delete(int customerId);
    }
}
