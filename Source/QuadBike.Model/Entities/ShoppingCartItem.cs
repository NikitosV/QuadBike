using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.Entities
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public Bike Bike { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}