using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.DataProvider.Entities
{
    [Table("Trip")]
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TripProvider")]
        public int ProvideId { get; set; }

        [MaxLength(50)]
        public string TripName { get; set; }     //Name of Trip

        [MaxLength(50)]
        public string Type { get; set; }     //Type

        public int Distance { get; set; }      // distance

        public int AmountOfPeople { get; set; }     // amount of people at trip

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }    //Start trip

        [DataType(DataType.Date)]
        public DateTime EndTrip { get; set; }    //End trip

        [MaxLength(200)]
        public string Description { get; set; }  // description

        public bool IsActivate { get; set; }   // is activate of trip

        public virtual Provider Provider { get; set; }

        public virtual RentTrip RentTrip { get; set; }
    }
}
