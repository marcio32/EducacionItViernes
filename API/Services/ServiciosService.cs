using Common.Helpers;
using Data.Dtos;
using Data.Entities;
using Data.Manager;
using API.Interfaces;

namespace API.Services
{
    public class ServiciosService : IServiciosService
    {
        private readonly ServiciosManager _manager;
        private Servicios _servicio;

        public ServiciosService() 
        {
            _manager = new ServiciosManager();
            _servicio = new Servicios();
        }

        public async Task<bool> GuardarServicio (Servicios servicio)
        {
             return await _manager.GuardarServicio(servicio);
        }

        public async Task<List<Servicios>> BuscarServicios()
        {
            return await _manager.BuscarListaAsync();
        }
    }
}
