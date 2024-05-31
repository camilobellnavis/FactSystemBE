using FactSystem.Application.Commons;
using FactSystem.Application.DTOs;
using FactSystem.Domain.Entities;

namespace FactSystem.Application.Interfaces
{
    public interface IClienteService
    {
        Task<Response<bool>> Create(Cliente customer);
        Task<Response<bool>> Update(Cliente customer);
        Task<Response<Cliente>> GetById(int customerId);
        Task<Response<List<Cliente>>> GetAll();
        Task<Response<bool>> Delete(int customerId);
    }
}
