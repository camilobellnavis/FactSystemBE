using FactSystem.Application.Commons;
using FactSystem.Application.Interfaces;
using FactSystem.Application.Repositories;
using FactSystem.Domain.Entities;
using System.Threading;

namespace FactSystem.Application.UsesCases
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Response<bool>> Create(Cliente customer)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _clienteRepository.Create(customer);
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
        public async Task<Response<bool>> Update(Cliente customer)
        {
            var response = new Response<bool>();
            try
            {
                response.Data =  await _clienteRepository.Update(customer);
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
        public async Task<Response<Cliente>> GetById(int customerId)
        {
            var response = new Response<Cliente>();
            try
            {
                var customer = await _clienteRepository.GetById(customerId);
                if (customer is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Cliente no existe...";
                    return response;
                }
                response.Data = customer;
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<List<Cliente>>> GetAll()
        {
            var response = new Response<List<Cliente>>(); 
            try
            {
                response.Data = await _clienteRepository.GetAll();
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
        public async Task<Response<bool>> Delete(int customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _clienteRepository.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
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
