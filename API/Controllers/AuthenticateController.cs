using API.Services;
using Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly AuthenticateService _authenticateService;

        public AuthenticateController(IConfiguration configuration)
        {
            _authenticateService = new AuthenticateService(configuration);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authenticateService.CrearToken(loginDto);
            if (token != null) {
                return Ok(new JwtSecurityTokenHandler().WriteToken(token).ToString());
            }
            return Unauthorized();
        }
    }
}
