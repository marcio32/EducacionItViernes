using Data.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using ProyectoIt2.Services;
using ProyectoIt2.ViewModels;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;
        public LoginController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _loginService = new LoginService(httpClientFactory, configuration);
        }
        public IActionResult Index()
        {
            if (TempData["ErrorLogin"] != null)
            {
                ViewBag.ErrorLogin = TempData["ErrorLogin"].ToString();
            }
            return View();
        }

        public IActionResult CrearCuenta()
        {
            return View();
        }

        public IActionResult OlvidoClave()
        {
            return View();
        }

        public IActionResult RecuperarCuenta()
        {
            return View();
        }


        public async Task<ActionResult> LoginLocal(LoginDto loginDto)
        {
            var token = await _loginService.ObtenerUsuario(loginDto);

            if (token != null)
            {
                var homeViewModel = new HomeViewModel() {
                    Token = token.Value.ToString()
                };
                var principalClaim = await _loginService.ClaimLogin(token);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principalClaim, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(30)
                });

                HttpContext.Session.SetString("Token", token.Value.ToString());

                return View("~/Views/Home/Index.cshtml", homeViewModel);
            }

            return RedirectToAction("Index", "Login");
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        public async Task<ActionResult> CrearUsuario(CrearCuentaDto crearUsuarioDto)
        {
            var responseCuenta = await _loginService.GuardarUsuario(crearUsuarioDto, HttpContext.Session.GetString("Token"));

            if (responseCuenta != null && Convert.ToBoolean(responseCuenta.Value))
            {
                TempData["ErrorLogin"] = "Se creo el usuario correctamente";
            }
            else
            {
                TempData["ErrorLogin"] = "no se pudo crear el usuario. Contacte a sistemas";
            }

            return RedirectToAction("index", "Login");
        }
    
        public async Task<ActionResult> EnviarMail(LoginDto loginDto)
        {
            _loginService.EnviarMail(loginDto);
            TempData["Mail"] = loginDto.Mail;
            return RedirectToAction("RecuperarCuenta", "Login");
        }

        public async Task<ActionResult> CambiarClave(LoginDto loginDto)
        {
            var resultadoCuenta = await _loginService.CambiarClave(loginDto, TempData["Mail"].ToString());
            if (resultadoCuenta)
            {
                TempData["ErrorLogin"] = "Se ha cambiado la clave correctamente";
            }
            else
            {
                TempData["ErrorLogin"] = "El codigo ingresado no coincide con el enviado al mail";
            }

            return RedirectToAction("Index", "Login");
        }

        public async Task LoginGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var resultado = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = resultado.Principal.Identities.FirstOrDefault().Claims.Select(claim => new { claim.Value });


            var usuario = await _loginService.BuscarUsuario(claims.ToList()[4].Value);

            if(usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index", "Login");
            }
        }
    
    }
}
