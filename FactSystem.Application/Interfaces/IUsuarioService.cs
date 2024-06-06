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
        List<Usuario> GetAll();

        Usuario Create(Usuario usuario);

        Task<Response<Usuario>> Authenticate(string userName,string password);
    }
}
