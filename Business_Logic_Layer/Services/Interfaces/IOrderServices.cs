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
        public OrderModel GetOrderById(int id);
        public void CreateOrder(OrderModel order);
        public void UpdateOrder(OrderModel order);
        public void DeleteOrder(int id);

        public List<DateTime> GetAvaliableServiceTimeOfEmployee(int id, DateTime chosenDate, int procedureId, double open, double close);
    }
}
