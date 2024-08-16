using Microsoft.AspNetCore.Mvc;

namespace ProyectoIt2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
