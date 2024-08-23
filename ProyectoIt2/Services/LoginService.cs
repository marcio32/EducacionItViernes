using Data.Base;
using Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoIt2.Services
{
    public class LoginService
    {
        private readonly BaseApi _baseApi;
        public LoginService(IHttpClientFactory httpClientFactory)
        {
            _baseApi = new BaseApi(httpClientFactory);
        }
        public async Task<OkObjectResult> ObtenerUsuario(LoginDto loginDto)
        {
            var usuario = await _baseApi.PostToApi("Authenticate/Login", loginDto);
            var resultadoUsuario = usuario as OkObjectResult;
            return resultadoUsuario;
        }
    }
}
