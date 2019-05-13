using QuadBike.Common.Filters.OrderFilter;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.OrderViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<OrderViewModel> Orders { get; set; }
        public DateTime OrderPlaced { get; set; }
        public string AccountProviderId { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public OrderFilterViewModel OrderFilterViewModel { get; set; }
        public OrderSortViewModel OrderSortViewModel { get; set; }
    }
}