using Data.Dtos;
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

            if(resultadoUsuario != null)
            {
                return View("~/Views/Home/Index.cshtml");
            }
         
            return RedirectToAction("Index", "Login");
                           }
    }
}
