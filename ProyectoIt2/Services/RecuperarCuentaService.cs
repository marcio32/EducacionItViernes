using Data.Dtos;
using Data.Entities;
using Data.Manager;

namespace Web.Services
{
    public class RecuperarCuentaService
    {
        private readonly RecuperarCuentaManager _manager;
        private Usuarios _usuarios;

        public RecuperarCuentaService()
        {
            _manager = new RecuperarCuentaManager();
            _usuarios = new Usuarios();
        }

        public async Task<Usuarios> BuscarUsuariosByMail(LoginDto loginDto)
        {
            return _manager.BuscarListaAsync().Result.FirstOrDefault(x => x.Mail == loginDto.Mail);
        }

        public bool GuardarUsuarios(Usuarios usuarios)
        {
            return _manager.Guardar(usuarios, usuarios.Id).Result;
        }

    }
}
