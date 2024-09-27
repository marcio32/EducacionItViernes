using Data.Dtos;
using Data.Entities;

namespace API.Interfaces
{
    public interface IUsuariosService
    {
        public Task<bool> GuardarUsuario(CrearCuentaDto crearCuentaDto);
        public Task<List<Usuarios>> BuscarUsuarios();
    }
}
