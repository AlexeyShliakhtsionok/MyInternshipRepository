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

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
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
            return Ok(orders);
        }
    }
}
