using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.OrderViewModels
{
    public class OrderDetailViewModel
    {
        public string BikeName { get; set; }
        public int MaxSpeed { get; set; }
        public int Fuel { get; set; }
        public string TypeEngine { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int OrderId { get; set; }
        public byte[] BikeImg { get; set; }
        public int Amount { get; set; }
        public string AccountProviderId { get; set; }
    }
}
