using API.Services;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController 
    {
        private readonly RolesService _service;

        public RolesController()
        {
            _service = new RolesService();
        }

        [HttpPost]
        [Route("GuardarRol")]
        public async Task<bool> GuardarRol (Roles rol)
        {
            return await _service.GuardarRol(rol);
        }

        [HttpGet]
        [Route("BuscarRoles")]
        public async Task<List<Roles>> BuscarRoles()
        {
            return await _service.BuscarRoles();
        }
    }
}
