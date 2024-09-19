using Data.Base;
using Data.Dtos;

namespace Web.Interfaces
{
    public interface IServiciosService
    {
        public void GuardarServicio(ServiciosDto servicioDto, string token);
        public void EliminarServicio(ServiciosDto servicioDto, string token);
    }
}
