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
    public class ServiciosService : IServiciosService
    {

        private readonly BaseApi _baseApi;

        public ServiciosService(IHttpClientFactory httpClientFactory)
        {
            _baseApi = new BaseApi(httpClientFactory);
        }

        public async void GuardarServicio(ServiciosDto servicioDto, string token)
        {
            await _baseApi.PostToApi("Servicios/GuardarServicio", servicioDto, token);
        }

        public async void EliminarServicio(ServiciosDto servicioDto, string token)
        {
            servicioDto.Activo = false;
            await _baseApi.PostToApi("Servicios/GuardarServicio", servicioDto, token);
        }

    }
}
