using Data.Base;
using Data.Dtos;

namespace Web.Interfaces
{
    public interface IRolesService
    {
        public void GuardarRol(RolesDto rolDto, string token);
        public void EliminarRol(RolesDto rolDto, string token);
    }
}
