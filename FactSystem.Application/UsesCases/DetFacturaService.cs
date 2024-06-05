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
    public class DetFacturaService : IDetFacturaService
    {
        private readonly IDetFacturaRepository _detFacturaRepository;

        public DetFacturaService(IDetFacturaRepository detFacturaRepository)
        {
            _detFacturaRepository = detFacturaRepository;
        }
        public async Task<Response<bool>> Create(DetFactura detail)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _detFacturaRepository.Create(detail);
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
        public async Task<Response<bool>> Update(DetFactura detail)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _detFacturaRepository.Update(detail);
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
        public async Task<Response<DetFactura>> GetById(int detailId)
        {
            var response = new Response<DetFactura>();
            try
            {
                var detail = await _detFacturaRepository.GetById(detailId);
                if (detail is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Cliente no existe...";
                    return response;
                }
                response.Data = detail;
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<List<DetFactura>>> GetAll()
        {
            var response = new Response<List<DetFactura>>();
            try
            {
                response.Data = await _detFacturaRepository.GetAll();
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
        public async Task<Response<bool>> Delete(int detailId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _detFacturaRepository.Delete(detailId);
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
        public async Task<Response<int>> GetLastId()
        {
            var response = new Response<int>();
            try
            {
                response.Data = await _detFacturaRepository.GetLastId();
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




    }
}
