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

        public IEnumerable<Order> GetAllOrder()                             // read all
        {
            return _context.Orders;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetail()                             // read all
        {
            return _context.OrderDetails;
        }

        public List<OrderViewModel> OrdersForCurrentProvider(string id)
        {
            var res = _context.Orders.Join(_context.OrderDetails, p => p.Id, c => c.OrderId, (p, c) => new OrderViewModel() // результат
            {
                Id = p.Id,
                Name = p.Name,
                OrderPlaced = p.OrderPlaced,
                AccountProviderId = c.AccountProviderId
            }).Where(a => a.AccountProviderId.Equals(id)).ToList();
            return res;
        }

        //public DateTime OrderPlaced { get; set; }
        //public int Price { get; set; }
        //public int Amount { get; set; }
    }
}
