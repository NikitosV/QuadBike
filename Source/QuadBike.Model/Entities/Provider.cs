using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.Model.Entities
{
    [Table("Provider")]
    public class Provider
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string CompanyName { get; set; }

        [MaxLength(50)]
        public string Adress { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        //public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }

        public virtual ICollection<Bike> Bikes { get; set; }
    }
}
