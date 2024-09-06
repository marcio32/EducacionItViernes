using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class DecryptJwtHelper
    {

        public static IEnumerable<Claim> DesencriptarJwtToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var claimsJwt = jsonToken.Claims;
            return claimsJwt;
        }
    }
}
