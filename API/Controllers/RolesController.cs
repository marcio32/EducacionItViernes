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


        [HttpGet]
        [Route("BuscarRoles")]
        public async Task<List<Roles>> BuscarRoles()
        {
            return await _service.BuscarRoles();
        }
    }
}
