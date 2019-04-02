using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.DTO
{
    public class TripDTO
    {
        public int Id { get; set; }

        public int ProvideId { get; set; }

        public string TripName { get; set; }     //Name of Trip

        public string Type { get; set; }     //Type

        public int Distance { get; set; }      // distance

        public int AmountOfPeople { get; set; }     // amount of people at trip

        public DateTime StartDate { get; set; }    //Start trip

        public DateTime EndTrip { get; set; }    //End trip

        public string Description { get; set; }  // description

        public int Price { get; set; }    //price

        public bool IsActivate { get; set; }   // is activate of trip
    }
}
