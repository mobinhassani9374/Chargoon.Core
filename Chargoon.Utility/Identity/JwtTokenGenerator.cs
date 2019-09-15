using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chargoon.Utility.Identity
{
    public class JwtTokenGenerator
    {
        private readonly JwtTokenModel jwtTokenModel;
        public JwtTokenGenerator(IOptions<JwtTokenModel> options)
        {
            jwtTokenModel = options.Value;
        }
        public string Generate()
        {
            var claims = new List<Claim>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenModel.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtTokenModel.Issuer,
                audience: jwtTokenModel.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
