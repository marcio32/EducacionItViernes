using Data.Base;
using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class RolesService : IRolesService
    {

        private readonly BaseApi _baseApi;

        public RolesService(IHttpClientFactory httpClientFactory)
        {
            _baseApi = new BaseApi(httpClientFactory);
        }

        public async void GuardarRol(RolesDto rolDto, string token)
        {
            await _baseApi.PostToApi("Roles/GuardarRol", rolDto, token);
        }

        public async void EliminarRol(RolesDto rolDto, string token)
        {
            rolDto.Activo = false;
            await _baseApi.PostToApi("Roles/GuardarRol", rolDto, token);
        }

    }
}
