using Data.Dtos;
using Data.Entities;

namespace Web.Interfaces
{
    public interface IRecuperarCuentaService
    {
        public Task<Usuarios> BuscarUsuariosByMail(LoginDto loginDto);

        public bool GuardarUsuarios(Usuarios usuarios);
        
    }
}
