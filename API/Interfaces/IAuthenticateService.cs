using Data.Dtos;
using Data.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace API.Interfaces
{
    public interface IAuthenticateService
    {
        public Task<JwtSecurityToken> CrearToken(LoginDto loginDto);
        public Task<Usuarios> ValidarUsuario(LoginDto loginDto);
    }
}
