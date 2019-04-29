using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.ViewModel.TripViewModels
{
    public class ChangeTripViewModel
    {
        public int Id { get; set; }

        public string TripName { get; set; }

        public string Type { get; set; }

        public int Distance { get; set; }

        public int AmountOfPeople { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndTrip { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public IFormFile TripImg { get; set; }
    }
}
