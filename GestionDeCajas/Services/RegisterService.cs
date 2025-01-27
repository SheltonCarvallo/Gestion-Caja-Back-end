using DataLayer;
using GestionDeCajas.Interfaces;
using GestionDeCajas.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;

namespace GestionDeCajas.Services
{
    public class RegisterService : IRegister
    {
        private readonly CashAdminDbContext _dbContext;
        private readonly UserManager<AppUserModel> userManager;
        private readonly IToken _token;
        public RegisterService(CashAdminDbContext dbContext, UserManager<AppUserModel> userManager, IToken token)
        {
            _dbContext = dbContext;
            this.userManager = userManager;
            _token = token;
        }

        public async Task<SaveConfirmation> PostUser(RegisterOrUpdateUserModel newAdmin, string role)
        {
            int roleId = 0;
         
            switch (role)
            {
                case "Administrador":
                    roleId = 1;
                    break;
                case "Gestor":
                    roleId = 2;
                    break;
                case "Cajero":
                    roleId = 3;
                    break;
                case "Cliente":
                    roleId = 4;
                    break;

            }

            UserModel userModel = new UserModel()
            {
                UserName = newAdmin.UserName,
                Email = newAdmin.Email,
                RolId = roleId,
                CreationDate = DateTime.Now,
                UserStatusId = "A",
            };

            await _dbContext.Users.AddAsync(userModel);
            await _dbContext.SaveChangesAsync();
            return new SaveConfirmation {CouldBeSaved = true };
        }

        public async Task<SaveConfirmation> RegisterUserWithRole(RegisterOrUpdateUserModel newUser, string userRole)
        {
            AppUserModel? existUsername = await userManager.FindByNameAsync(newUser.UserName.Normalize());
            AppUserModel? existEmail = await userManager.FindByEmailAsync(newUser.Email);

            if (existUsername != null || existEmail != null)
            {
                //ModelState.AddModelError("Register error", "Username or Email are already taken");
                return new SaveConfirmation {CouldBeSaved = false, Message = "Username or Email are already taken" };
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
                SaveConfirmation saveConfirmationDbCashAdmin = await PostUser(newUser, userRole);
                AppUserModel? createdUser = await userManager.FindByNameAsync(appUserModel.UserName);
                string? token = await _token.GenerateToken(createdUser!, appUserModel.UserName);
                return  new SaveConfirmation { CouldBeSaved = true, Message = token }  ;
            }

            return new SaveConfirmation { CouldBeSaved = false };

            // If there are any errors, add them to the ModelState object
            // and return the error to the client
            /*foreach (IdentityError error in newUserResult.Errors)
            {

                ModelState.AddModelError("", error.Description);
            }

            foreach (IdentityError error in roleResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return BadRequest(ModelState);*/
        }
    }
}
