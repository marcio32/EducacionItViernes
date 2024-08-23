using Data;
using Data.Dtos;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AuthenticateService
    {
        private static ApplicationDbContext _contextInstance;

        public AuthenticateService()
        {
            _contextInstance = new ApplicationDbContext();
        }

        public async Task<Usuarios> ValidarUsuario(LoginDto loginDto)
        {
            var validarUsuario = await _contextInstance.Usuarios.FirstAsync(x => x.Mail == loginDto.Mail && x.Clave == loginDto.Password);
            return validarUsuario;
        }

    }
}
