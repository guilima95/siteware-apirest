using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyFinance.API.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyFinance.API.Auth
{
    public class GenerateToken
    {
        private readonly IConfiguration configuration;

        public GenerateToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetToken(UserResolver user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("JWT:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
