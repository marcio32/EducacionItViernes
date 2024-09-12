using Data.Base;
using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Web.ViewModels;

namespace Web.Services
{
    public class UsuariosService
    {

        private readonly BaseApi _baseApi;

        public UsuariosService(IHttpClientFactory httpClientFactory)
        {
            _baseApi = new BaseApi(httpClientFactory);
        }

        public async void GuardarUsuario(UsuariosDto usuarioDto, string token)
        {
            await _baseApi.PostToApi("Usuarios/CrearUsuario", usuarioDto, token);
        }

        public async void EliminarUsuario(UsuariosDto usuarioDto, string token)
        {
            usuarioDto.Activo = false;
            await _baseApi.PostToApi("Usuarios/CrearUsuario", usuarioDto, token);
        }

        public async Task<UsuariosViewModels> ListarRolesUsuarios([FromBody] UsuariosDto usuariosDto, string token)
        {
            var usuariosViewModel = new UsuariosViewModels();
            var roles = await _baseApi.GetToApi("Roles/BuscarRoles", token);
            var resultadoRoles = roles as OkObjectResult;

            if(usuariosDto != null)
            {
                usuariosViewModel = usuariosDto;
            }

            if(resultadoRoles != null)
            {
                var listaRoles = JsonConvert.DeserializeObject<List<Roles>>(resultadoRoles.Value.ToString());
                var listaItemsRoles = new List<SelectListItem>();
                foreach (var rol in listaRoles)
                {
                    listaItemsRoles.Add(new SelectListItem { Text = rol.Nombre, Value = rol.Id.ToString() });
                }
                usuariosViewModel.Lista_Roles = listaItemsRoles;
            }

            return usuariosViewModel;
        }
    }
}
