using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Common.Filters.TripFilter
{
    public class TripFilterViewModel
    {
        public string SelectedName { get; private set; }    // введенное имя

        public TripFilterViewModel(string name)
        {
            SelectedName = name;
        }
    }
}
