using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(Order order, string userName);
        Order Get(int id);
        List<OrderViewModel> OrdersForCurrentProvider(string id);
        List<OrderDetailViewModel> OrderDetailsOfOrderById(int orderId, string accId);
    }
}
