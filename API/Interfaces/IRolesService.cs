using Data.Entities;

namespace API.Interfaces
{
    public interface IRolesService
    {
        public Task<bool> GuardarRol(Roles rol);
        public Task<List<Roles>> BuscarRoles();
    }
}
