using Common.Helpers;
using Data.Base;
using Data.Dtos;
using Data.Entities;
using Data.Manager;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using Web.Services;

namespace ProyectoIt2.Services
{
    public class LoginService
    {
        private readonly BaseApi _baseApi;
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;
        private readonly RecuperarCuentaService _recuperarCuentaService;
        public LoginService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _baseApi = new BaseApi(httpClientFactory);
            _configuration = configuration;
            _smtpClient = new SmtpClient();
            _recuperarCuentaService = new RecuperarCuentaService();
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
            var resultadoCuenta = false;
            var guid = Guid.NewGuid();
            var numeros = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(numeros.Substring(0, 6));
            var random = new Random(seed);
            var codigo = random.Next(000000,999999);

            var usuario = await _recuperarCuentaService.BuscarUsuarios(loginDto);
            if(usuario != null)
            {
                usuario.Codigo = codigo;
                resultadoCuenta = _recuperarCuentaService.GuardarUsuarios(usuario);
            }

            if (resultadoCuenta)
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(_configuration["ConfiguracionMail:Usuario"]);
                mail.To.Add(loginDto.Mail);
                mail.Subject = ("Codigo de recuperacion Proyecto IT");
                mail.Body = CuerpoMail(codigo);
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;

                _smtpClient.Host = _configuration["ConfiguracionMail:DireccionServidor"];
                _smtpClient.Port = int.Parse(_configuration["ConfiguracionMail:Puerto"]);
                _smtpClient.EnableSsl = bool.Parse(_configuration["ConfiguracionMail:Ssl"]);
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential(_configuration["ConfiguracionMail:Usuario"], _configuration["ConfiguracionMail:Clave"]);
            
                _smtpClient.Send(mail);
            }
        }

        public static string CuerpoMail(int codigo)
        {
            var mensaje = "<strong>A continuacion se mostrara un codigo que debera ingresar en la web de Proyecto IT </strong>";
            mensaje += $"<strong>{codigo}</strong>";
            return mensaje;
        }

        public async Task<bool> CambiarClave(LoginDto loginDto, string mail)
        {
            loginDto.Mail = mail;
            var resultadoCuenta = false;
            var usuario = await _recuperarCuentaService.BuscarUsuarios(loginDto);
            if(usuario != null)
            {
                usuario.Clave = EncryptHelper.Encriptar(loginDto.Password);
                usuario.Codigo = null;
                resultadoCuenta = _recuperarCuentaService.GuardarUsuarios(usuario);
            }

            return resultadoCuenta;
        }

        public async Task<Usuarios?> BuscarUsuario(string mail)
        {
            var loginDto = new LoginDto();
            loginDto.Mail = mail;
            var usuario = await _recuperarCuentaService.BuscarUsuarios(loginDto);

            return usuario;
        }
    }
}
