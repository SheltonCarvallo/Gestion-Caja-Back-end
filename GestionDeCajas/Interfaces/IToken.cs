using ModelLayer.Models;

namespace GestionDeCajas.Interfaces
{
    public interface IToken
    {
        public Task<string> GenerateToken(AppUserModel appUserModel, string username);
    }
}
