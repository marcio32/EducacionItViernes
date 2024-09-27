using API.Services;
using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServiciosController : ControllerBase
    {
        private readonly ServiciosService _service;
        public ServiciosController()
        {
            _service = new ServiciosService();
        }

        [HttpPost]
        [Route("GuardarServicio")]
        public async Task<bool> GuardarServicio(Servicios servicio)
         {
            return await _service.GuardarServicio(servicio);
        }

        [HttpGet]
        [Route("BuscarServicios")]
        public async Task<List<Servicios>> BuscarServicios() 
        {
            return await _service.BuscarServicios();
        }
    }
}
