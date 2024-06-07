using FactSystem.Application.Commons;
using FactSystem.Application.DTOs;
using FactSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactSystem.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Response<List<Usuario>>> GetAll();
        Task<Response<bool>> IncreaseAttempts(Usuario user);
        Task<Response<bool>> LockUser(Usuario user);
        Task<Response<Usuario>> GetById(string userId);
        Task<Response<bool>> Create(Usuario user);

        Task<Response<Usuario>> Authenticate(string userName,string password);
    }
}
