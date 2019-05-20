using Microsoft.AspNetCore.Http;
using QuadBike.Common.Filters.BikeFilter;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.BikeViewModels
{
    public class IndexBikeViewModel
    {
        public int Id { get; set; }

        public byte[] BikeImg { get; set; }
        
        public string Name { get; set; }

        public int MaxSpeed { get; set; }

        public string TypeEngine { get; set; }

        public int Power { get; set; }

        public int Fuel { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string AccountId { get; set; }
   
        public string Email { get; set; }

        public BikeFilterViewModel BikeFilterViewModel { get; set; }
    }
}
