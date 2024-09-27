using Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class RolesController : Controller
    {
        private readonly RolesService _rolesService;
        public RolesController(IHttpClientFactory httpClientFactory)
        {
            _rolesService = new RolesService(httpClientFactory);
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RolesAddPartial([FromBody] RolesDto rolDto)
        {
            var rolesViewModel = new RolesViewModels();
            if(rolDto != null)
            {
                rolesViewModel = rolDto;
            } 
            return PartialView("~/Views/Roles/Partial/RolesAddPartial.cshtml", rolesViewModel);
        }

        public async Task<IActionResult> GuardarRol(RolesDto rolDto)
        {
            _rolesService.GuardarRol(rolDto, HttpContext.Session.GetString("Token"));
            return RedirectToAction("Index", "Roles");
        }

        public async Task<IActionResult> EliminarRol([FromBody] RolesDto rolDto)
        {
            _rolesService.EliminarRol(rolDto, HttpContext.Session.GetString("Token"));
            return RedirectToAction("Index", "Roles");
        }
    }
}
