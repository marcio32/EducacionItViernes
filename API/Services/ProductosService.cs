using Data.Entities;
using Data.Manager;
using API.Interfaces;

namespace API.Services
{
    public class ProductosService : IProductosService
    {
        private readonly ProductosManager _productosManager;

        public ProductosService()
        {
            _productosManager = new ProductosManager();
        }

        public async Task<bool>GuardarProducto (Productos producto)
        {
            return await _productosManager.Guardar(producto, producto.Id);
        }

        public async Task<List<Productos>> BuscarProductos()
        {
            return await _productosManager.BuscarListaAsync();
        }
    }
}
