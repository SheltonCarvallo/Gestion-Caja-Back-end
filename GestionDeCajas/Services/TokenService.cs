using GestionDeCajas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionDeCajas.Services
{
    public class TokenService : IToken
        
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<AppUserModel> userManager;
        public TokenService(IConfiguration configuration, UserManager<AppUserModel> userManager)
        {
                this.configuration = configuration;
                this.userManager = userManager;
          
        }
        public async Task<string> GenerateToken(AppUserModel appUserModel, string username)
        {
            string? secret = configuration["JwtConfig:Secret"];
            string? issuer = configuration["JwtConfig:ValidIssuer"];
            string? audience = configuration["JwtConfig:ValidAudiences"];

            if (secret is null || issuer is null || audience is null)
            {
                throw new ApplicationException("Jwt is not set in the appsettings.json");
            }

            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            IList<string> userRoles = await userManager.GetRolesAsync(appUserModel); // getting the roles
            List<Claim> claims = new List<Claim>
            {
                new(ClaimTypes.Name, username)
            };

            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
