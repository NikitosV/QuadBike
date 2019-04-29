using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Common.Filters.BikeFilter
{
    public class BikeFilterViewModel
    {
        public string SelectedName { get; private set; }    // введенное имя

        public BikeFilterViewModel(string name)
        {
            SelectedName = name;
        }
    }
}
