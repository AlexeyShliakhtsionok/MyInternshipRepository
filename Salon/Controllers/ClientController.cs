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
        private readonly IOrderServices _orderServices;

        public ClientController(IClientServices clientServices, IOrderServices orderServices)
        {
            _clientServices = clientServices;
            _orderServices = orderServices;
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
        [Route("GetClientByEmail")]
        public ActionResult<ClientModel> GetClientByEmail(string email)
        {
            var client = _clientServices.GetClientByEmail(email);
            if (client == null)
            {
                return NotFound("Sorry, but client with corresponding e-mail doesn't exist.");
            }

            return Ok(client);
        }

        [HttpGet]
        [Route("GetAllClients")]
        public ActionResult<IEnumerable<ClientModel>> GetClients()
        {
            var clients = _clientServices.GetAllClients();
            var orders = _orderServices.GetOrders();
            return Ok(new { clients, orders });
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
