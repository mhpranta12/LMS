using LMS.Application;
using LMS.Application.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Utilities
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _settings;
        public JwtTokenGenerator(IOptions<JwtSettings> setting)
        {
            _settings = setting.Value;
        }

        public string GenerateToken(Guid userId, string email, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub,userId.ToString()),
                new (JwtRegisteredClaimNames.Email,email),
                new (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
