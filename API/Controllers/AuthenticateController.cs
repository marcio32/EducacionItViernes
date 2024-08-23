using API.Services;
using Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly AuthenticateService _authenticateService;

        public AuthenticateController()
        {
            _authenticateService = new AuthenticateService();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var validarUsuario = await _authenticateService.ValidarUsuario(loginDto);

            if (validarUsuario != null) {
                return Ok(validarUsuario);
            }

            return Unauthorized();
        }
    }
}
