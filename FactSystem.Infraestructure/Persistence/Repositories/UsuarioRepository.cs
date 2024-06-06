using FactSystem.Application.Repositories;
using FactSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactSystem.Infraestructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario { NombreUsuario = "bellnavis",Bloqueado = 0, Contraseña="camilo123",IntentosFallidos=0 },
            new Usuario { NombreUsuario = "cormane",Bloqueado = 0, Contraseña="valentina123",IntentosFallidos=0 },
            new Usuario { NombreUsuario = "morales",Bloqueado = 0, Contraseña="camilo123",IntentosFallidos=0 }
        };

        public async Task<Usuario> Authenticate(string userName, string  password)
        {
            return  usuarios.Where(x => x.NombreUsuario == userName && x.Contraseña == password).FirstOrDefault();
        }

        public Usuario Create(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            return usuarios;
        }
    }
}
