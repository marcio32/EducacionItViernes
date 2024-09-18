using Data.Base;
using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Interfaces
{
    public interface IProductosService
    {
        public Task<IActionResult> GuardarProducto(ProductosDto productoDto, string token);

        public Task<IActionResult> EliminarProducto(ProductosDto productoDto, string token);

    }
}
