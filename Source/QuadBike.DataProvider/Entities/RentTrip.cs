using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.DataProvider.Entities
{
    [Table("RentTrip")]
    public class RentTrip
    {
        [Key]
        public int Id { get; set; }         //id

        [ForeignKey("TripRentTrip")]
        public int TripId { get; set; }

        [ForeignKey("UserRentTrip")]
        public int UserId { get; set; }

        public virtual SimpleUser SimpleUser { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
