using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.BikeViewModels
{
    public class ChangeBikeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MaxSpeed { get; set; }

        public string TypeEngine { get; set; }

        public int Power { get; set; }

        public int Fuel { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
    }
}
