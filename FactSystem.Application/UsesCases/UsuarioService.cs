using AutoMapper;
using FactSystem.Application.Commons;
using FactSystem.Application.DTOs.Enums;
using FactSystem.Application.Interfaces;
using FactSystem.Application.Repositories;
using FactSystem.Domain.Entities;
using FactSystem.Domain.Enums;
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
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Response<Usuario>> Authenticate(string userName,string password)
        {
            var response = new Response<Usuario>();
            try
            {
                var userIdExist = await _usuarioRepository.GetById(userName);
                if (userIdExist is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Ususario no existe...";
                    return response;
                }
                else
                {
                    var user = await _usuarioRepository.Authenticate(userName,password);
                    if (user is null)
                    {
                        await IncreaseAttempts(userIdExist);
                        response.IsSuccess = true;
                        response.Message = "Contraseña invalida...";
                        return response;
                    }
                    user.IntentosFallidos = 0;
                    user.Bloqueado = 0;
                    response.Data = user;
                    response.IsSuccess = true;
                    response.Message = "Autenticación Exitosa!!!";

                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> IncreaseAttempts(Usuario user)
        {
            var response = new Response<bool>();
            try
            {
                user.Bloqueado = _mapper.Map<Status>(StatusDto.Inactive);

                if (user.IntentosFallidos < 3)
                {
                    user.IntentosFallidos = user.IntentosFallidos + 1;
                }
                else
                {
                    await LockUser(user);
                    response.IsSuccess = true;
                    return response;
                }
                response.Data = await _usuarioRepository.IncreaseAttempts(user);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }


        public async Task<Response<List<Usuario>>> GetAll()
        {
            var response = new Response<List<Usuario>>();
            try
            {
                response.Data = await _usuarioRepository.GetAll();
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta con éxito";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<Usuario>> GetById(string userId)
        {
            var response = new Response<Usuario>();
            try
            {
                var user = await _usuarioRepository.GetById(userId);
                if (user is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Usuario no existe...";
                    return response;
                }
                response.Data = user;
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Create(Usuario user)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _usuarioRepository.Create(user);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> LockUser(Usuario user)
        {
            var response = new Response<bool>();
            try
            {

                response.Data = await _usuarioRepository.LockUser(user);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Bloqueo Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
    }
}
