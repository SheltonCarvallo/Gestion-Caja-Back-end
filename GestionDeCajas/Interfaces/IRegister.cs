using GestionDeCajas.Authentication.Models;
using GestionDeCajas.Utilities;

namespace GestionDeCajas.Interfaces
{
    public interface IRegister
    {
        public Task<SaveConfirmation> PostUser(RegisterOrUpdateUserModel newAdmin, string role);
    }
}
