using GestionDeCajas.Authentication.Models;
using GestionDeCajas.Interfaces;
using GestionDeCajas.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;

namespace GestionDeCajas.Controllers
{
    [Authorize (Roles = AppRoles.Cajero)]
    [ApiController]
    [Route("api/[Controller]")]
    public class ClientController(IClient _client) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<ClientModel>> GetClient(string numberIdentification)
        {
            try
            {
                ClientModel client = await _client.GetClient(numberIdentification);
                if(client.ClientId == 0)
                {
                    return NotFound();
                }
                return Ok(client);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] ClientModel newClient)
        {
            try
            {
                SaveConfirmation saveConf = await _client.PostClient(newClient);
                return saveConf.CouldBeSaved ?
                    CreatedAtAction(nameof(GetClient), new { id = newClient.ClientId }, newClient) :
                    BadRequest(new { error = saveConf.Message });
            }
            catch (Exception ex)
            {
                return ValidationProblem("Unexpected error occurred, contact IT department", $"{ex.GetType()}", 500, ex.Message);
                
            }
        }
    }
}
