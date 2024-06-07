using FactSystem.Domain.Entities;

namespace FactSystem.Application.Repositories
{
    public interface IUsuarioRepository
    {
        Task<bool> Create(Usuario userId);
        Task<bool> IncreaseAttempts(Usuario user);
        Task<bool> LockUser(Usuario user);
        Task<Usuario> GetById(string userId);
        Task<List<Usuario>> GetAll();
        Task<bool> Delete(int userId);
        Task<Usuario> Authenticate(string userName, string password);
    }
}
