using API.Services;
using Data.Dtos;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [Route("CrearUsuario")]
        public async Task<bool> CrearUsuario(CrearCuentaDto crearCuentaDto)
        {
            return await _service.GuardarUsuario(crearCuentaDto);
        }
    }
}
