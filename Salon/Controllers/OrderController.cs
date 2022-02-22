using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        private readonly IClientServices _clientServices;
        private readonly IEmployeeServices _employeeServices;
        private readonly IProcedureServices _procedureServices;
        private readonly IProcedureTypeServices _procedureTypeServices;

        public OrderController(IOrderServices orderServices, IClientServices clientServices,
            IEmployeeServices employeeServices, IProcedureServices procedureServices, IProcedureTypeServices procedureTypeServices)
        {
            _orderServices = orderServices;
            _clientServices = clientServices;
            _employeeServices = employeeServices;
            _procedureServices = procedureServices;
            _procedureTypeServices = procedureTypeServices;
        }

        [HttpPost]
        [Route("DeleteOrderById")]
        public void DeleteOrder(int id)
        {
            _orderServices.DeleteOrder(id);
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public ActionResult<IEnumerable<OrderModel>> GetAllOrders()
        {
            var orders = _orderServices.GetOrders();
            var employees = _employeeServices.GetAllEmployees();
            var clients = _clientServices.GetAllClients();
            var procedures = _procedureServices.GetAllProcedures();
            var procedureTypes = _procedureTypeServices.GetProcedureTypesSelectList(_procedureTypeServices.GetProcedureTypes().ToList());
            return Ok( new { orders, employees, clients, procedures, procedureTypes});
        }

        [HttpGet]
        [Route("GetOrderById")]
        public ActionResult<OrderModel> GetOrderById(int id)
        {
            var order = _orderServices.GetOrderById(id);
            if (order == null)
            {
                return NotFound("InvalidId");
            }
            return Ok(order);
        }

        [HttpPost, Route("UpdateOrder")]
        public void UpdateOrder([FromBody]OrderModel order)
        {
            _orderServices.UpdateOrder(order);
        }

        [HttpPost, Route("CreateOrder")]
        public void CreateOrder([FromBody]OrderModel order)
        {
            _orderServices.CreateOrder(order);
        }

        [HttpGet, Route("GetScheduleOfEmployee")]
        public ActionResult GetSchedule(int id, DateTime chosenDate, int procedureId, double open, double close)
        {
            var avaliableSchedule = _orderServices
                .GetAvaliableServiceTimeOfEmployee( id, chosenDate, procedureId, open,  close); 
            return Ok( avaliableSchedule);
        }


    }
}
