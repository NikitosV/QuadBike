using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.ShoppingViewModel
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}