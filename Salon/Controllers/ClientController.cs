using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientServices;

        public ClientController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        [HttpPost]
        [Route("DeleteClientById")]
        public void DeleteClient(int id)
        {
            _clientServices.DeleteClient(id);
        }

        [HttpGet]
        [Route("GetClientById")]
        public ActionResult<ClientModel> GetClientById(int id)
        {
            var client = _clientServices.GetClientById(id);
            if (client == null)
            {
                return NotFound("InvalidId");
            }

            return Ok(client);
        }

        [HttpGet]
        [Route("GetAllClients")]
        public ActionResult<IEnumerable<ClientModel>> GetClients()
        {
            var clients = _clientServices.GetAllClients();
            return Ok(clients);
        }

        [HttpPost]
        [Route("CreateClient")]
        public void CreateClient([FromBody] ClientModel clientInput)
        {
            _clientServices.CreateClient(clientInput);
        }

        [HttpPost]
        [Route("UpdateClient")]
        public void UpdateClient([FromBody] ClientModel clientInput)
        {
            _clientServices.UpdateClient(clientInput);
        }


    }
}
