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
    public class CabFacturaService : ICabFacturaService
    {
        private readonly ICabFacturaRepository _cabFacturaRepository;
        private readonly IDetFacturaRepository _detFacturaRepository;

        public CabFacturaService(ICabFacturaRepository cabFacturaRepository, IDetFacturaRepository detFacturaRepository)
        {
            _cabFacturaRepository = cabFacturaRepository;
            _detFacturaRepository = detFacturaRepository;
        }
        public async Task<Response<bool>> Create(CabFactura invoice)
        {
            var response = new Response<bool>();
            try
            {

                if (invoice.DetFacturas != null && invoice.DetFacturas.Any())
                {
                    foreach (var detFactura in invoice.DetFacturas)
                    {
                        detFactura.CabFacturaNavigation = invoice;

                    }
                }
                response.Data = await _cabFacturaRepository.Create(invoice);
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
        public async Task<Response<bool>> Update(CabFactura invoice)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _cabFacturaRepository.Update(invoice);
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
        public async Task<Response<CabFactura>> GetById(int invoiceId)
        {
            var response = new Response<CabFactura>();
            try
            {
                var invoice = await _cabFacturaRepository.GetById(invoiceId);
                if (invoice is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Cliente no existe...";
                    return response;
                }
                response.Data = invoice;
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<List<CabFactura>>> GetAll()
        {
            var response = new Response<List<CabFactura>>();
            try
            {
                response.Data = await _cabFacturaRepository.GetAll();
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
        public async Task<Response<bool>> Delete(int invoiceId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _cabFacturaRepository.Delete(invoiceId);
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
                response.Data = await _cabFacturaRepository.GetLastId();
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

        public async Task<Response<int>> GetLastIdF()
        {
            var response = new Response<int>();
            try
            {
                response.Data = await _cabFacturaRepository.GetLastIdF();
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
