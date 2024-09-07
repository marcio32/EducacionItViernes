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
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosService _service;
        public UsuariosController()
        {
            _service = new UsuariosService();
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<bool> CrearUsuario(CrearCuentaDto crearCuentaDto)
        {
            return await _service.GuardarUsuario(crearCuentaDto);
        }

        [HttpGet]
        [Route("BuscarUsuarios")]
        public async Task<List<Usuarios>> BuscarUsuarios()
        {
            return await _service.BuscarUsuarios();
        }
    }
}
