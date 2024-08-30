using Common.Helpers;
using Data.Base;
using Data.Dtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            loginDto.Password = EncryptHelper.Encriptar(loginDto.Password);
            var usuario = await _baseApi.PostToApi("Authenticate/Login", loginDto);
            var resultadoUsuario = usuario as OkObjectResult;
            return resultadoUsuario;
        }

        public async Task<OkObjectResult> GuardarUsuario(CrearCuentaDto crearUsuarioDto)
        {
            crearUsuarioDto.Clave = EncryptHelper.Encriptar(crearUsuarioDto.Clave);
            var response = await _baseApi.PostToApi("Usuarios/CrearUsuario", crearUsuarioDto);
            var responseLogin = response as OkObjectResult;

            return responseLogin;
        }

        public async Task<ClaimsPrincipal> ClaimLogin(OkObjectResult resultadoUsuario)
        {

            var principalClaim = new ClaimsPrincipal();
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            Claim claimNombre = new(ClaimTypes.Name, "Marcio");
            Claim claimRole = new(ClaimTypes.Role, "Admin");
            Claim claimEmail = new(ClaimTypes.Email, "marcioabriola@gmail.com");

            identity.AddClaim(claimNombre);
            identity.AddClaim(claimRole);
            identity.AddClaim(claimEmail);

            principalClaim.AddIdentity(identity);

            return principalClaim;
        }
    
        public async void EnviarMail(LoginDto loginDto)
        {

        }
    
    }
}
