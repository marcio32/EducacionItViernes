using Common.Helpers;
using Data.Base;
using Data.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using Web.Services;

namespace Web.Interfaces
{
    public interface ILoginService
    {
        public Task<OkObjectResult> ObtenerUsuario(LoginDto loginDto);

        public Task<OkObjectResult> GuardarUsuario(CrearCuentaDto crearUsuarioDto, string token);

        public Task<ClaimsPrincipal> ClaimLogin(OkObjectResult token);

        public void EnviarMail(LoginDto loginDto);

        public Task<bool> CambiarClave(LoginDto loginDto, string mail);

        public Task<Usuarios?> BuscarUsuario(string mail);

    }
}
