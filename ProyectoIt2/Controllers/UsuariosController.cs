using Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        private readonly UsuariosService _usuariosService;
        public UsuariosController(IHttpClientFactory httpClientFactory)
        {
            _usuariosService = new UsuariosService(httpClientFactory);
        }

      
        public IActionResult Index() { 
            return View();
        }

        public async Task<IActionResult> UsuariosAddPartial([FromBody] UsuariosDto usuariosDto)
        {
            var usuariosViewModel = await _usuariosService.ListarRolesUsuarios(usuariosDto, HttpContext.Session.GetString("Token"));
            return PartialView("~/Views/Usuarios/Partial/UsuariosAddPartial.cshtml", usuariosViewModel);
        }

        public async Task<IActionResult> GuardarUsuario(UsuariosDto usuariosDto)
        {
            _usuariosService.GuardarUsuario(usuariosDto, HttpContext.Session.GetString("Token"));
            return RedirectToAction("Index", "Usuarios");
        }

        public async Task<IActionResult> EliminarUsuario([FromBody] UsuariosDto usuariosDto)
        {
            _usuariosService.EliminarUsuario(usuariosDto, HttpContext.Session.GetString("Token"));
            return RedirectToAction("Index", "Usuarios");
        }
    }
}
 