using API.Interfaces;
using Data.Entities;
using Data.Manager;

namespace API.Services
{
    public class RolesService : IRolesService
    {

        private readonly RolesManager _manager;

        public RolesService()
        {
            _manager = new RolesManager();
        }

        public async Task<bool> GuardarRol (Roles rol)
        {
            return await _manager.Guardar(rol, rol.Id);
        } 

        public async Task<List<Roles>> BuscarRoles()
        {
            return await _manager.BuscarListaAsync();
        }
    }
}
