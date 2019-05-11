using QuadBike.DataProvider.Interfaces;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Get(int id)
        {
            return _orderRepository.Get(id);
        }

        public IEnumerable<OrderViewModel> OrdersForCurrentProvider(string id)
        {
            var res = _orderRepository.OrdersForCurrentProvider(id);
            return res;
        }

        public List<OrderDetailViewModel> OrderDetailsOfOrderById(int orderId, string accId)
        {
            var res = _orderRepository.OrderDetailsOfOrderById(orderId, accId);
            return res;
        }

        public void CreateOrder(Order order, string userName)
        {
            _orderRepository.CreateOrder(order, userName);
        }

        public void DeleteOrderById(int? orderId)
        {
            _orderRepository.DeleteOrderById(orderId);
        }
    }
}
