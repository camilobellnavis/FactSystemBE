﻿using FactSystem.Domain.Entities;

namespace FactSystem.Application.Repositories
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        Usuario Create(Usuario usuario);
    }
}
