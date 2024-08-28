using Data.Dtos;
using Data.Entities;
using Data.Manager;

namespace API.Services
{
    public class UsuariosService
    {
        private readonly UsuariosManager _manager;
        private Usuarios _usuario;

        public UsuariosService()
        {
            _manager = new UsuariosManager();
            _usuario = new Usuarios();
        }

        public async Task<bool> GuardarUsuario (CrearCuentaDto crearCuentaDto)
        {
            _usuario = crearCuentaDto;
            return await _manager.Guardar(_usuario, _usuario.Id);
        }
    }
}
