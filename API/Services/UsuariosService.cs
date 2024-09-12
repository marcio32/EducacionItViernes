using Common.Helpers;
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
            _usuario.Clave = _manager.BuscarListaAsync().Result.Where(x => x.Id == _usuario.Id).FirstOrDefault()?.Clave == _usuario.Clave ? _usuario.Clave : EncryptHelper.Encriptar(_usuario.Clave);
             return await _manager.Guardar(_usuario, _usuario.Id);
        }

        public async Task<List<Usuarios>> BuscarUsuarios()
        {
            return await _manager.BuscarListaAsync();
        }
    }
}
