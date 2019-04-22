using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.Model.Entities
{
    [Table("RentTrip")]
    public class RentTrip
    {
        [Key]
        public int Id { get; set; }         //id

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }

        public virtual Account Account { get; set; }

        [ForeignKey("TripId")]
        public int TripId { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
