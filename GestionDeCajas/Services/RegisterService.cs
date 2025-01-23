using DataLayer;
using GestionDeCajas.Authentication.Models;
using GestionDeCajas.Interfaces;
using GestionDeCajas.Utilities;
using ModelLayer.Models;

namespace GestionDeCajas.Services
{
    public class RegisterService : IRegister
    {
        private readonly CashAdminDbContext _dbContext;

        public RegisterService(CashAdminDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
