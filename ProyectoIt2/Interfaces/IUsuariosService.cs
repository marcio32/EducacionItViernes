using Data.Base;
using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IUsuariosService
    {
        public void GuardarUsuario(UsuariosDto usuarioDto, string token);
        public void EliminarUsuario(UsuariosDto usuarioDto, string token);
        public Task<UsuariosViewModels> ListarRolesUsuarios([FromBody] UsuariosDto usuariosDto, string token);

    }
}
