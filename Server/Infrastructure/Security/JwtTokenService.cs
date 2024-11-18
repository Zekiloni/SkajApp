using Microsoft.IdentityModel.Tokens;
using Server.Core.Entities;
using Server.Ports.Inbound;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Server.Infrastructure.Security
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            SymmetricSecurityKey? securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim>? claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var Sectoken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);

            string? token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return token;
        }
    }
}
