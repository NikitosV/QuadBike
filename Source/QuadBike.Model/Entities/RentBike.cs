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

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }

        public virtual Account Account { get; set; }

        [ForeignKey("BikeId")]
        public int BikeId { get; set; }

        public virtual Bike Bike { get; set; }
    }
}