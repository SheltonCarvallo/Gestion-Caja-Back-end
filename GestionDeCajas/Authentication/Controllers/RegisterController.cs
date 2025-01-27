using GestionDeCajas.Interfaces;
using GestionDeCajas.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionDeCajas.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController(IRegister register) : ControllerBase
    {
        [HttpPost("register-administrador")]
        public async Task<IActionResult> RegisterAdministrator([FromBody] RegisterOrUpdateUserModel registerOrUpdateUserModel)
        {
            SaveConfirmation saveConfirmation = await register.RegisterUserWithRole(registerOrUpdateUserModel, AppRoles.Administrador);

            if (saveConfirmation.CouldBeSaved == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok(new { saveConfirmation.Message });
            }
        }

        [HttpPost("register-manager")]
        [Authorize(Roles = AppRoles.Administrador)]
        public async Task<IActionResult> RegisterManager([FromBody] RegisterOrUpdateUserModel registerOrUpdateUserModel)
        {
            SaveConfirmation saveConfirmation = await register.RegisterUserWithRole(registerOrUpdateUserModel, AppRoles.Gestor);

            if (saveConfirmation.CouldBeSaved == false)
            {
                return BadRequest();
            }
            else
            {
                return Created();
            }
        }

        [HttpPost("register-cashier")]
        [Authorize(Roles = AppRoles.Administrador)]
        public async Task<IActionResult> RegisterCashier([FromBody] RegisterOrUpdateUserModel registerOrUpdateUserModel)
        {
            SaveConfirmation saveConfirmation = await register.RegisterUserWithRole(registerOrUpdateUserModel, AppRoles.Cajero);

            if (saveConfirmation.CouldBeSaved == false)
            {
                return BadRequest();
            }
            else
            {
                return Created();
            }
        }
    }
}