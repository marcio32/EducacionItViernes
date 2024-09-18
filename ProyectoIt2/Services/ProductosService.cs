using Data.Base;
using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class ProductosService : IProductosService
    {

        private readonly BaseApi _baseApi;

        public ProductosService(IHttpClientFactory httpClientFactory)
        {
            _baseApi = new BaseApi(httpClientFactory);
        }

        public async Task<IActionResult> GuardarProducto(ProductosDto productoDto, string token)
        {
            var producto = new Productos();
            if(productoDto.Imagen_Archivo != null)
            {
                using (var ms = new MemoryStream())
                {
                    productoDto.Imagen_Archivo.CopyTo(ms);
                    var imagenBytes = ms.ToArray();
                    productoDto.Imagen = Convert.ToBase64String(imagenBytes);
                }
                producto = productoDto;
            }
            return await _baseApi.PostToApi("Productos/GuardarProducto", productoDto, token);
        }

        public async Task<IActionResult> EliminarProducto(ProductosDto productoDto, string token)
        {
            productoDto.Activo = false;
            return await _baseApi.PostToApi("Productos/GuardarProducto", productoDto, token);
        }

    }
}
