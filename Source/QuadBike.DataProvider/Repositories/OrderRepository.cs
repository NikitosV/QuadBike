using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
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

        public void CreateOrder(Order order, string accId, string userName)
        {
            order.OrderPlaced = DateTime.Now;
            order.Name = userName;

            _context.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    BikeId = shoppingCartItem.Bike.Id,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Bike.Price,
                    AccountId = accId
                };

                _context.OrderDetails.Add(orderDetail);
            }

            _context.SaveChanges();
        }
    }
}
