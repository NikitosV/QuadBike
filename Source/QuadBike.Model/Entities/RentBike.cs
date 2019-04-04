using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.Model.Entities
{
    [Table("RentBike")]
    public class RentBike
    {
        [Key]
        public int Id { get; set; }      //id

        [ForeignKey("BikeRentBike")]
        public int BikeId { get; set; }

        [ForeignKey("UserRentBike")]
        public int SimpleUserId { get; set; }

        public virtual MyUser MyUser { get; set; }

        public virtual Bike Bike { get; set; }
    }
}
