using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuadBike.DataProvider.Entities
{
    [Table("Provider")]
    public class Provider
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AccProvider")]
        public int AccountId { get; set; }

        [MaxLength(50)]
        public string CompanyName { get; set; }

        [MaxLength(50)]
        public string Adress { get; set; }

        [StringLength(13)]
        public string Mobile { get; set; }

        public byte[] Logo { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public Account Account { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }

        public virtual ICollection<Bike> Bikes { get; set; }
    }
}
