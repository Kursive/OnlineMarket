using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;
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

        public JwtProvider(IOptions<JwtOptions> jwtOptions) => _jwtOptions = jwtOptions.Value;

        public string GenerateToken(User user)
        {
           var claims = new[]
           {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
            new Claim(ClaimTypes.Name, user.Name),                    
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role,user.Role.ToString())
           };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
         issuer: _jwtOptions.Issuer,
        audience: _jwtOptions.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpiresHours),
        signingCredentials: signingCredentials
          );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
