using GestionDeCajas.Utilities;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;

namespace GestionDeCajas.Interfaces
{
    public interface IRegister
    {
        public Task<SaveConfirmation> PostUser(RegisterOrUpdateUserModel newAdmin, string role);
        public Task<SaveConfirmation> RegisterUserWithRole(RegisterOrUpdateUserModel newUser, string userRole);

    }
}
