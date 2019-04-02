using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.DTO
{
    public class BikeDTO
    {
        public int Id { get; set; }         

        public int ProvideId { get; set; }

        public string Name { get; set; }     //Name

        public int MaxSpeed { get; set; }    //Speed

        public string TypeEngine { get; set; }   // Type of Engine

        public int Power { get; set; }       // power

        public int Fuel { get; set; }     // fuel

        public string Description { get; set; }    // description

        public int Price { get; set; }   // price
    }
}
