using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuariosService _usuariosService;
        public UsuariosController()
        {
            _usuariosService = new UsuariosService();
        }
        public IActionResult Index() { 
            return View();
        }

        public async Task<IActionResult> UsuariosAddPartial()
        {
            return PartialView("~/Views/Usuarios/Partial/UsuariosAddPartial.cshtml");
        }
    }
}
