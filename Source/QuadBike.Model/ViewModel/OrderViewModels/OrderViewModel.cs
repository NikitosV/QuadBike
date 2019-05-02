using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.OrderViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public DateTime OrderPlaced { get; set; }
        public string AccountProviderId { get; set; }
    }
}