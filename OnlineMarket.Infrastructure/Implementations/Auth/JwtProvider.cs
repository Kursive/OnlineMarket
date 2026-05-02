using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;
using OnlineMarket.Domain.Enums;
using OnlineMarket.Infrastructure.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Infrastructure.Implementations.Service
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        private readonly RolePermissionsOptions _rolePermissions;

        public JwtProvider(IOptions<JwtOptions> jwtOptions, IOptions<RolePermissionsOptions> rolePermissions)
        {
            _jwtOptions = jwtOptions.Value;
            _rolePermissions = rolePermissions.Value;
        }

        public string GenerateToken(User user)
        {
           var claims = new List<Claim> 
           {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()), 
            new (ClaimTypes.Name, user.Name),                    
            new (ClaimTypes.Email, user.Email),
            new (ClaimTypes.Role, user.Role.ToString())
           };

            var permission = _rolePermissions.GetPermission(user.Role.ToString());
            foreach (Permissions permissions in Enum.GetValues<Permissions>())
            {
                if (permissions == Permissions.None)
                    continue;
            }

            if(permission.HasFlag(permission))
            {
                claims.Add(new Claim("permission", permission.ToString()));
            }


            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256);


             var token = new JwtSecurityToken(
                 issuer: _jwtOptions.Issuer,
                 audience: _jwtOptions.Audience,
                 claims: claims,
                 expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpiresHours),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
