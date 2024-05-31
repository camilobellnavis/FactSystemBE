using FactSystem.Application.Interfaces;
using FactSystem.Application.Repositories;
using FactSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactSystem.Application.UsesCases
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Create(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public  List<Usuario> GetAll()
        {
            var usuarios = _usuarioRepository.GetAll();
            
            return usuarios;
        }
    }
}
