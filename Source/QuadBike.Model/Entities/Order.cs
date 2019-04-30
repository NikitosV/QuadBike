using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.Model.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("OrderLines")]
        public List<OrderDetail> OrderLines { get; set; }

        public string Name { get; set; }

        //public int OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }
    }
}
