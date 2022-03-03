using Business_Logic_Layer.DBO.Clients;
using Business_Logic_Layer.DBO.Orders;
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
        [Route("GetOrderById")]
        public ActionResult<OrderViewModel> GetOrderById(int id)
        {
            var order = _orderServices.GetOrderById(id);
            if (order == null)
            {
                return NotFound("InvalidId");
            }
            return Ok(order);
        }

        [HttpPost, Route("UpdateOrder")]
        public void UpdateOrder([FromBody]OrderViewModel order)
        {
            _orderServices.UpdateOrder(order);
        }

        [HttpPost, Route("CreateOrder")]
        public void CreateOrder([FromBody] OrderViewModel order)
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

        [HttpGet]
        [Route("GetAllOrders")]
        public ActionResult<IEnumerable<OrdersInformationViewModel>> GetPagedOrders(int elementsPerPage, int pageNumber)
        {
            var allOrders = _orderServices.GetAllOrders().ToList();
            var clientsSelectList = _clientServices.GetClientsSelectList();
            var procedureTypesSelectList = _procedureTypeServices.GetProcedureTypesSelectList();
            double pagesCount = (double)allOrders.Count() / elementsPerPage;
            pagesCount = Math.Ceiling(pagesCount);

            List<OrdersInformationViewModel>[] pagedOrders = new List<OrdersInformationViewModel>[(int)pagesCount];
            for (int j = 0; j < pagedOrders.Length; j++)
            {
                pagedOrders[j] = new List<OrdersInformationViewModel>();
            }

            for (int i = 0; i < pagedOrders.Length; i++)
            {
                for (int j = 0; j < allOrders.Count(); j++)
                {
                    if (j != 0 && j % elementsPerPage == 0)
                    {
                        i++;
                    };
                    pagedOrders[i].Add(allOrders[j]);
                }
            }

            var orders = pagedOrders[pageNumber-1];

            return Ok(new { orders, clientsSelectList, procedureTypesSelectList, pagesCount, elementsPerPage, pageNumber });
        }
    }
}
