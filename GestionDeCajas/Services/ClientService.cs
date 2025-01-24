using DataLayer;
using GestionDeCajas.Interfaces;
using GestionDeCajas.Utilities;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;

namespace GestionDeCajas.Services
{
    public class ClientService(CashAdminDbContext context) : IClient
    {
        public async Task<ClientModel> GetClient(string identificationNumber)
        {
            ClientModel? client = await context.Clients.FirstOrDefaultAsync(e => e.Equals(identificationNumber));
            return client ?? new ClientModel();
        }

        public async Task<SaveConfirmation> PostClient(ClientModel client)
        {
            ClientModel? existIdentification = await context.Clients.FirstOrDefaultAsync(e => e.identification == client.identification);
            //TODO: try the above query with a SP
           
            
            if (existIdentification is not null)
            {
                return new SaveConfirmation { CouldBeSaved = false, Message = "The identification number is already taken" };
            }
            await context.Clients.AddAsync(client);
            await context.SaveChangesAsync();
            return new SaveConfirmation { CouldBeSaved = true, Message = "Client was successfully saved" };

        }
    }
}
