using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.DataProvider.Entities
{
    [Table("RentBike")]
    public class RentBike
    {
        [Key]
        public int Id { get; set; }      //id

        [ForeignKey("BikeRentBike")]
        public int BikeId { get; set; }

        [ForeignKey("UserRentBike")]
        public int UserId { get; set; }

        public int Price { get; set; }   // price

        public virtual User User { get; set; }

        public virtual Bike Bike { get; set; }
    }
}
