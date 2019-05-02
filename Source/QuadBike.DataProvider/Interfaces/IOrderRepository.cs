using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.OrderViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuadBike.DataProvider.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order, string userName);
        IEnumerable<Order> GetAllOrder();
        IEnumerable<OrderDetail> GetAllOrderDetail();
        List<OrderViewModel> OrdersForCurrentProvider(string id);
    }
}
