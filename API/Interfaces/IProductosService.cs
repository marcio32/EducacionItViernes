using Data.Entities;

namespace API.Interfaces
{
    public interface IProductosService
    {
        public Task<bool> GuardarProducto(Productos producto);
        public Task<List<Productos>> BuscarProductos();
    }
}
