using API.Services;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosService _productosService;

        public ProductosController()
        {
            _productosService = new ProductosService();
        }

        [HttpGet]
        [Route("BuscarProductos")]
        public async Task<List<Productos>> BuscarProductos()
        {
            return await _productosService.BuscarProductos();
        } 

        [HttpPost]
        [Route("GuardarProducto")]
        public async Task<bool> GuardarProducto(Productos producto)
        {
            return await _productosService.GuardarProducto(producto);
        }
    }
}
