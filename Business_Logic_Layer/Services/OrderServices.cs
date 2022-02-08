﻿using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public OrderServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateOrder(OrderModel order)
        {
            Order orderEntity = AutoMappers<OrderModel,Order>.Map(order);
             _UnitOfWork.Order.Add(orderEntity);
            _UnitOfWork.Complete();
        }

        public void DeleteOrder(int id)
        {
            var orderToDelete = _UnitOfWork.Order.GetById(id);
             _UnitOfWork.Order.Delete(orderToDelete);
            _UnitOfWork.Complete();
        }

        public IEnumerable<OrderModel> GetOrders()
        {
            var orders = _UnitOfWork.Order.GetAll();
            IEnumerable<OrderModel> orderModels = AutoMappers<Order, OrderModel>.MapIQueryable(orders);
            return orderModels;
        }

        public OrderModel GetOrdersById(int id)
        {
            var orderEntity = _UnitOfWork.Order.GetById(id);
            OrderModel orderModel = AutoMappers<Order, OrderModel>.Map(orderEntity);
            return orderModel;
        }

        public void UpdateOrder()
        {
            _UnitOfWork.Complete();
            throw new NotImplementedException();
        }
    }
}
