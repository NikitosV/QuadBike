using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuadBike.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuadBike.Model.Entities
{
    public class ShoppingCart
    {
        private readonly IQuadBikeContext _context;
        private ShoppingCart(IQuadBikeContext context)
        {
            _context = context;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;

            var context = services.GetService<IQuadBikeContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Bike bike, int amount)
        {
            var shoppingCartItem =
            _context.ShoppingCartItems.SingleOrDefault(
            s => s.Bike.Id == bike.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Bike = bike,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Bike bike)
        {
            var shoppingCartItem =
            _context.ShoppingCartItems.SingleOrDefault(
            s => s.Bike.Id == bike.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
            (ShoppingCartItems =
            _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
            .Include(s => s.Bike)
            .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _context
            .ShoppingCartItems
            .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
            .Select(c => c.Bike.Price * c.Amount).Sum();
            return total;
        }
    }
}
