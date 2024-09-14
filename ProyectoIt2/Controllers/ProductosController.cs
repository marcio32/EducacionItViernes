using Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductosService _productosService;
        public ProductosController(IHttpClientFactory httpClientFactory)
        {
            _productosService = new ProductosService(httpClientFactory);
        }
        public IActionResult Index() { 
            return View();
        }

        public async Task<IActionResult> ProductosAddPartial([FromBody] ProductosDto productosDto)
        {
            var productosViewModel = new ProductosViewModels();
            if (productosDto != null)
            {
                productosViewModel = productosDto;
            }
            return PartialView("~/Views/Productos/Partial/ProductosAddPartial.cshtml", productosViewModel);
        }

        public async Task<IActionResult> GuardarProducto(ProductosDto productosDto)
        {
            await _productosService.GuardarProducto(productosDto, HttpContext.Session.GetString("Token"));
            return RedirectToAction("Index", "Productos");
        }

        public async Task<IActionResult> EliminarProducto([FromBody] ProductosDto productosDto)
        {
            await _productosService.EliminarProducto(productosDto, HttpContext.Session.GetString("Token"));
            return RedirectToAction("Index", "Productos");
        }
    }
}
 