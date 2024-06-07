using FactSystem.Application.Repositories;
using FactSystem.Domain.Entities;
using FactSystem.Infraestructure.Persistence.Contexts;
using FactSystem.Infraestructure.Persistence.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace FactSystem.Infraestructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario { NombreUsuario = "bellnavis",Bloqueado = 0, Contraseña="camilo123",IntentosFallidos=0 },
            new Usuario { NombreUsuario = "cormane",Bloqueado = 0, Contraseña="valentina123",IntentosFallidos=0 },
            new Usuario { NombreUsuario = "morales",Bloqueado = 0, Contraseña="camilo123",IntentosFallidos=0 }
        };

        public async Task<Usuario> Authenticate(string userName, string  password)
        {
            return  _context.Usuarios.Where(x => x.NombreUsuario == userName && x.Contraseña == password).FirstOrDefault();
        }

        public async Task<bool> Create(Usuario user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<bool> IncreaseAttempts(Usuario user)
        {
            var entity = await _context.Usuarios.AsNoTracking().SingleOrDefaultAsync(x => x.NombreUsuario.Equals(user.NombreUsuario));
            if (entity == null)
            {
                return await Task.FromResult(false);
            }
            entity.IntentosFallidos = user.IntentosFallidos;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<bool> LockUser(Usuario user)
        {
            var entity = await _context.Usuarios.AsNoTracking().SingleOrDefaultAsync(x => x.NombreUsuario.Equals(user.NombreUsuario));
            if (entity == null)
            {
                return await Task.FromResult(false);
            }
            entity.Bloqueado = user.Bloqueado;

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public Task<bool> Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetById(string userId)
        {
            return await _context.Usuarios.AsNoTracking().SingleOrDefaultAsync(x => x.NombreUsuario.Equals(userId));
        }
    }
}
