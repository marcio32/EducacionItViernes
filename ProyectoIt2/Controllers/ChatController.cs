using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Chat()
        {
            return View();
        }
    }
}
