using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.OrderViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuadBike.DataProvider.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IQuadBikeContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(IQuadBikeContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order, string userName)
        {
            order.Name = userName;
            order.OrderPlaced = DateTime.Now;

            _context.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    BikeId = shoppingCartItem.Bike.Id,
                    OrderId = order.Id,
                    Price = shoppingCartItem.Bike.Price,
                    AccountProviderId = shoppingCartItem.Bike.AccountId
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }

        public Order Get(int id)
        {
            return _context.Orders.Find(id);
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _context.Orders;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetail()
        {
            return _context.OrderDetails;
        }

        public IEnumerable<OrderViewModel> OrdersForCurrentProvider(string id)
        {
            var res = (from order in _context.Orders
                       join OrderDetail in _context.OrderDetails on order.Id equals OrderDetail.OrderId
                       select new OrderViewModel()
                       {
                           Id = order.Id,
                           Name = order.Name,
                           OrderPlaced = order.OrderPlaced,
                           AccountProviderId = OrderDetail.AccountProviderId
                       }).Where(ordDetail => ordDetail.AccountProviderId.Equals(id)).Distinct().ToList();
            return res;
        }

        public List<OrderDetailViewModel> OrderDetailsOfOrderById(int orderId, string accId)
        {
            var res = (from orderDetail in _context.OrderDetails
                       join bike in _context.Bikes on orderDetail.BikeId equals bike.Id
                       where orderDetail.OrderId == orderId && bike.AccountId == accId
                       select new OrderDetailViewModel()
                       {
                           AccountProviderId = bike.AccountId,
                           BikeName = bike.Name,
                           TypeEngine = bike.TypeEngine,
                           Fuel = bike.Fuel,
                           MaxSpeed = bike.MaxSpeed,
                           BikeImg = bike.BikeImg,
                           Description = bike.Description,
                           OrderId = orderDetail.OrderId,
                           Amount = orderDetail.Amount,
                           Price = bike.Price
                       }).ToList();
            return res;
        }

        public void DeleteOrderById(int? orderId)
        {
            Order order = _context.Orders.Find(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
        }
    }
}