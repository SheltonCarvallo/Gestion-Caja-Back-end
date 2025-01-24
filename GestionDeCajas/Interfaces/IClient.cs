using GestionDeCajas.Utilities;
using ModelLayer.Models;

namespace GestionDeCajas.Interfaces
{
    public interface IClient
    {
        public Task<ClientModel> GetClient(string identificationNumber);
        public Task<SaveConfirmation> PostClient(ClientModel client);
    }
}
