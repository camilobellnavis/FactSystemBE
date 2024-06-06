using FactSystem.Application.Commons;
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

        public async Task<Response<Usuario>> Authenticate(string userName,string password)
        {
            var response = new Response<Usuario>();
            try
            {
                var user = await _usuarioRepository.Authenticate(userName,password);
                if (user is null)
                {
                    response.IsSuccess = true;
                    response.Message = "User no existe...";
                    return response;
                }
                else
                {
                    response.Data = user;
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";

                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
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
