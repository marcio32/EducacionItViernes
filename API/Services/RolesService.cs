using Data.Entities;
using Data.Manager;

namespace API.Services
{
    public class RolesService
    {

        private readonly RolesManager _manager;

        public RolesService()
        {
            _manager = new RolesManager();
        }

        public async Task<List<Roles>> BuscarRoles()
        {
            return await _manager.BuscarListaAsync();
        }
    }
}
