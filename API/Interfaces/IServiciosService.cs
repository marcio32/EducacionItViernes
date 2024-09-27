using Data.Dtos;
using Data.Entities;

namespace API.Interfaces
{
    public interface IServiciosService
    {
        public Task<bool> GuardarServicio(Servicios servicio);
        public Task<List<Servicios>> BuscarServicios();
    }
}
