using GeoToDo.Business.Interfaces;
using GeoToDo.Business.Settings;
using GeoToDo.Business.StringInfos;
using GeoToDo.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GeoToDo.Business.Concrete
{
    class JwtManager : IJwtService
    {
        public JwtToken GenerateJwt(AppUser appUser, List<AppRole> roles)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: JwtInfo.Issuer, audience: JwtInfo.Audience, claims: GetClaims(appUser, roles), notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(JwtInfo.TokenExpiration), signingCredentials: credentials);

            JwtToken jwtToken = new JwtToken();
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            jwtToken.Token = handler.WriteToken(jwtSecurityToken);

            return jwtToken;
        }

        private static List<Claim> GetClaims(AppUser appUser, List<AppRole> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,appUser.Email),
                new Claim(ClaimTypes.NameIdentifier,appUser.Id.ToString())
            };

            if (roles?.Count > 0)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }

            return claims;
        }
    }
}
