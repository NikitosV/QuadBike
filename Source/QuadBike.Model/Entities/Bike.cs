using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.Model.Entities
{
    [Table("Bike")]
    public class Bike
    {
        [Key]
        public int Id { get; set; }           //Id

        [MaxLength(50)]
        public string Name { get; set; }     //Name

        public int MaxSpeed { get; set; }    //Speed

        [MaxLength(50)]
        public string TypeEngine { get; set; }   // Type of Engine

        public int Power { get; set; }       // power

        public int Fuel { get; set; }     // fuel

        [MaxLength(200)]
        public string Description { get; set; }    // description

        public int Price { get; set; }   // price

        [ForeignKey("ProviderId")]
        public int ProviderId { get; set; }

        public virtual Provider Provider { get; set; }

        public virtual ICollection<RentBike> RentBikes { get; set; }
    }
}
