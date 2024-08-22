using Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> LoginLocal(LoginDto loginDto)
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
