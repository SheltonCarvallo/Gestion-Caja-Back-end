using GestionDeCajas.Authentication.Models;
using GestionDeCajas.Interfaces;
using GestionDeCajas.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionDeCajas.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController(UserManager<AppUserModel> userManager, IConfiguration configuration, IRegister administrador) : ControllerBase
    {
        [HttpPost("register-administrador")]
        public Task<IActionResult> RegisterAdministrator([FromBody] RegisterOrUpdateUserModel registerOrUpdateUserModel)
        {
            return RegisterUserWithRole(registerOrUpdateUserModel, AppRoles.Administrador);
        }

        [HttpPost("register-manager")]
        [Authorize(Roles = AppRoles.Administrador)]
        public Task<IActionResult> RegisterManager([FromBody] RegisterOrUpdateUserModel registerOrUpdateUserModel)
        {
            return RegisterUserWithRole(registerOrUpdateUserModel, AppRoles.Gestor);
        }

        [HttpPost("register-cashier")]
        [Authorize(Roles = AppRoles.Administrador)]
        public Task<IActionResult> RegisterCashier([FromBody] RegisterOrUpdateUserModel registerOrUpdateUserModel)
        {
            return RegisterUserWithRole(registerOrUpdateUserModel, AppRoles.Cajero);
        }
        private async Task<IActionResult> RegisterUserWithRole(RegisterOrUpdateUserModel newUser, string userRole)
        {
            AppUserModel? existUsername = await userManager.FindByNameAsync(newUser.UserName.Normalize());
            AppUserModel? existEmail = await userManager.FindByEmailAsync(newUser.Email);

            if (existUsername != null ||  existEmail != null) 
            {
                ModelState.AddModelError("Register error", "Username or Email are already taken");
                return BadRequest(ModelState);
            }

            AppUserModel appUserModel = new AppUserModel()
            {
                UserName = newUser.UserName,
                Email = newUser.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            // save new user in the Auth database
            IdentityResult newUserResult = await userManager.CreateAsync(appUserModel, newUser.Password);

            // save user role
            IdentityResult roleResult = await userManager.AddToRoleAsync(appUserModel, userRole);

            if (newUserResult.Succeeded && roleResult.Succeeded)
            {
                SaveConfirmation saveConfirmationDbCashAdmin = await administrador.PostUser(newUser, userRole);
                AppUserModel? createdUser = await userManager.FindByNameAsync(appUserModel.UserName);
                string? token = await GenerateToken(createdUser!, appUserModel.UserName);
                return Ok(new { token });
            }

            // If there are any errors, add them to the ModelState object
            // and return the error to the client
            foreach (IdentityError error in newUserResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            foreach (IdentityError error in roleResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return BadRequest(ModelState);
        }


        private async Task<string?> GenerateToken(AppUserModel appUserModel, string username)
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