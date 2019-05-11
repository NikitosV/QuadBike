using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Common.Filters.OrderFilter
{
    public class OrderFilterViewModel
    {
        public string SelectedName { get; private set; }    // введенное имя

        public OrderFilterViewModel(string name)
        {
            SelectedName = name;
        }
    }
}
