using Business_Logic_Layer.Models;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IOrderServices
    {
        public IEnumerable<OrderModel> GetOrders();
        public OrderModel GetOrdersById(int id);
        public void CreateOrder(OrderModel order);
        public void UpdateOrder();
        public void DeleteOrder(int id);
    }
}
