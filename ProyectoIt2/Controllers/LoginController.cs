using Data.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProyectoIt2.Services;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _loginService = new LoginService(httpClientFactory);
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> LoginLocal(LoginDto loginDto)
        {
            var resultadoUsuario = await _loginService.ObtenerUsuario(loginDto);

            if (resultadoUsuario != null)
            {
                var principalClaim = await _loginService.ClaimLogin(resultadoUsuario);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principalClaim, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(30)
                });

                return View("~/Views/Home/Index.cshtml");
            }

            return RedirectToAction("Index", "Login");
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
