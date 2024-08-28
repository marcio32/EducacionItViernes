using API.Services;
using Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
    }
}
