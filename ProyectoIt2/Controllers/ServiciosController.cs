using Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly ServiciosService _serviciosService;
        public ServiciosController(IHttpClientFactory httpClientFactory)
        {
            _serviciosService = new ServiciosService(httpClientFactory);
        }
        public IActionResult Index() { 
            return View();
        }

        public async Task<IActionResult> ServiciosAddPartial([FromBody] ServiciosDto serviciosDto)
        {
            var serviciosViewModel = new ServiciosViewModels();
            if(serviciosDto != null)
            {
                serviciosViewModel = serviciosDto;
            }
            return PartialView("~/Views/Servicios/Partial/ServiciosAddPartial.cshtml", serviciosViewModel);
        }

        public async Task<IActionResult> GuardarServicio(ServiciosDto serviciosDto)
        {
            _serviciosService.GuardarServicio(serviciosDto, HttpContext.Session.GetString("Token"));
            return RedirectToAction("Index", "Servicios");
        }

        public async Task<IActionResult> EliminarServicio([FromBody] ServiciosDto serviciosDto)
        {
            _serviciosService.EliminarServicio(serviciosDto, HttpContext.Session.GetString("Token"));
            return RedirectToAction("Index", "Servicios");
        }
    }
}
 