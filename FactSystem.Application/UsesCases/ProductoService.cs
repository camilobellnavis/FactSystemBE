using FactSystem.Application.Commons;
using FactSystem.Application.Interfaces;
using FactSystem.Application.Repositories;
using FactSystem.Domain.Entities;

namespace FactSystem.Application.UsesCases
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<Response<bool>> Create(Producto product)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _productoRepository.Create(product);
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
        public async Task<Response<bool>> Update(Producto product)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _productoRepository.Update(product);
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
        public async Task<Response<Producto>> GetById(int productId)
        {
            var response = new Response<Producto>();
            try
            {
                var product = await _productoRepository.GetById(productId);
                if (product is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Producto no existe...";
                    return response;
                }
                response.Data = product;
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<List<Producto>>> GetAll()
        {
            var response = new Response<List<Producto>>();
            try
            {
                response.Data = await _productoRepository.GetAll();
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
        public async Task<Response<bool>> Delete(int productId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _productoRepository.Delete(productId);
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
