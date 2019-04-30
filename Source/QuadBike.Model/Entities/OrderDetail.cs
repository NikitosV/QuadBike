using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.Model.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OderDetailId { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        [ForeignKey("BikeId")]
        public int BikeId { get; set; }

        [ForeignKey("AccountId")]
        public string AccountId { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }

        public virtual Bike Bike { get; set; }

        public virtual Order Order { get; set; }

        public virtual Account Account { get; set; }
    }
}
